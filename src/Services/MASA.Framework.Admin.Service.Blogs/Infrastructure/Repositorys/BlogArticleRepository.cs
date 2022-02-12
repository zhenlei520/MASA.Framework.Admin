﻿using System.Linq.Expressions;

namespace MASA.Framework.Admin.Service.Blogs.Infrastructure.Repositorys
{
    public class BlogArticleRepository : IBlogArticleRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogArticleRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext ?? throw new ArgumentNullException(nameof(blogDbContext));
        }

        /// <summary>
        /// 博客列表
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<PagingResult<BlogInfoListViewModel>> GetListAsync(GetBlogArticleOptions options)
        {
            System.Linq.Expressions.Expression<Func<BlogInfoListViewModel, bool>> where = blogInfo => true;

            where = where.And(!string.IsNullOrEmpty(options.Title),
                    blogInfo => blogInfo.title.Contains(options.Title))
                .And(options.State.HasValue, blogInfo => blogInfo.state == options.State)
                .And(options.ReleaseStartTime.HasValue, blogInfo => blogInfo.ReleaseTime >= options.ReleaseStartTime)
                .And(options.ReleaseEndTime.HasValue, blogInfo => blogInfo.ReleaseTime < options.ReleaseEndTime)
                .And(options.TypeId.HasValue, blogInfo => blogInfo.typeId == options.TypeId.Value);

            var query = from blogInfo in _blogDbContext.BlogInfoes
                        join blogType in _blogDbContext.BlogTypes on blogInfo.TypeId equals blogType.Id into leftBlogType
                        from blogType in leftBlogType.DefaultIfEmpty()
                        select new BlogInfoListViewModel()
                        {
                            id = blogInfo.Id,
                            typeId = blogInfo.TypeId,
                            title = blogInfo.Title,
                            state = blogInfo.State,
                            typeName = blogType.TypeName,
                            content = blogInfo.Content,
                            visits = blogInfo.Visits,
                            commentCount = blogInfo.CommentCount,
                            approvedCount = blogInfo.ApprovedCount,
                            remark = blogInfo.Remark,
                            ReleaseTime = blogInfo.ReleaseTime,
                        };

            return await query.Where(where).OrderByDescending(x => x.ReleaseTime).PagingAsync(options.PageIndex, options.PageSize);
        }

        /// <summary>
        /// 博客详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BlogInfoListViewModel> GetInfoAsync(Guid id)
        {
            var data = await (from blogInfo in _blogDbContext.BlogInfoes
                              join blogType in _blogDbContext.BlogTypes on blogInfo.TypeId equals blogType.Id
                              into leftBlogType
                              from blogType in leftBlogType.DefaultIfEmpty()
                              where blogInfo.Id == id
                              select new BlogInfoListViewModel()
                              {
                                  id = blogInfo.Id,
                                  typeId = blogInfo.TypeId,
                                  title = blogInfo.Title,
                                  state = blogInfo.State,
                                  typeName = blogType.TypeName,
                                  content = blogInfo.Content,
                                  visits = blogInfo.Visits,
                                  commentCount = blogInfo.CommentCount,
                                  approvedCount = blogInfo.ApprovedCount,
                                  remark = blogInfo.Remark,
                                  ReleaseTime = blogInfo.CreationTime
                              }).FirstOrDefaultAsync();

            return data;
        }

        /// <summary>
        /// 新增博客
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BlogInfo> CreateAsync(BlogInfo model)
        {
            try
            {
                var result = await _blogDbContext.BlogInfoes.AddAsync(model);

                await _blogDbContext.SaveChangesAsync();
                _blogDbContext.Database.CurrentTransaction?.Commit();

                return result.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// 更新博客
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateAsync(BlogInfo model)
        {
            var blogInfo = await _blogDbContext.BlogInfoes.FindAsync(model.Id);

            if (blogInfo != null)
            {
                // TODO: mapping

                blogInfo.Content = model.Content;
                blogInfo.Remark = model.Remark;
                blogInfo.State = model.State;
                blogInfo.Title = model.Title;
                blogInfo.IsShow = model.IsShow;
                blogInfo.TypeId = model.TypeId;

                _blogDbContext.Update(blogInfo);
                await _blogDbContext.SaveChangesAsync();
                _blogDbContext.Database.CurrentTransaction?.Commit();
            }
        }

        /// <summary>
        /// 删除博客
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task RemoveAsync(params Guid[] ids)
        {
            var blogInfos = await _blogDbContext.BlogInfoes.Where(type => ids.Contains(type.Id)).ToListAsync();

            foreach (var blogInfo in blogInfos)
            {
                blogInfo.IsDeleted = true;
                blogInfo.DeletionTime = DateTime.UtcNow;
            }

            _blogDbContext.UpdateRange(blogInfos);
            await _blogDbContext.SaveChangesAsync();
            _blogDbContext.Database.CurrentTransaction?.Commit();
        }

        /// <summary>
        /// 获取用户个人列表
        /// </summary>
        /// <param name="opions"></param>
        /// <returns></returns>
        public async Task<PagingResult<BlogInfoListViewModel>> GetBlogArticleByUser(GetBlogArticleUserOptions options)
        {
            var query = from blogInfo in _blogDbContext.BlogInfoes
                        join blogType in _blogDbContext.BlogTypes on blogInfo.TypeId equals blogType.Id into leftBlogType
                        from blogType in leftBlogType.DefaultIfEmpty()
                        where blogInfo.CreatorUserId == options.Author &&
                            (string.IsNullOrWhiteSpace(options.Title) || blogInfo.Title.Contains(options.Title))
                        select new BlogInfoListViewModel()
                        {
                            id = blogInfo.Id,
                            typeId = blogInfo.TypeId,
                            title = blogInfo.Title,
                            state = blogInfo.State,
                            typeName = blogType.TypeName,
                            content = blogInfo.Content,
                            visits = blogInfo.Visits,
                            commentCount = blogInfo.CommentCount,
                            approvedCount = blogInfo.ApprovedCount,
                            remark = blogInfo.Remark,
                            ReleaseTime = blogInfo.CreationTime
                        };

            var pageResult = await query.OrderByDescending(x => x.ReleaseTime).PagingAsync(options.PageIndex, options.PageSize);

            return new PagingResult<BlogInfoListViewModel>()
            {
                Data = pageResult.Data,
                Page = pageResult.Page,
                Size = pageResult.Size,
                TotalCount = pageResult.TotalCount
            };
        }

        /// <summary>
        /// 追加阅读数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddVisits(AddBlogVisitModel model)
        {
            var blogInfo = await _blogDbContext.BlogInfoes.FindAsync(model.BlogId);

            if (blogInfo != null)
            {
                blogInfo.Visits++;
                _blogDbContext.Update(blogInfo);
                await _blogDbContext.SaveChangesAsync();
                _blogDbContext.Database.CurrentTransaction?.Commit();
            }
        }

        /// <summary>
        /// 追加评论数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isAdd">false:减少</param>
        /// <returns></returns>
        public async Task AddCommentCount(Guid id, bool isAdd)
        {
            var blogInfo = await _blogDbContext.BlogInfoes.FindAsync(id);
            if (blogInfo != null)
            {
                blogInfo.CommentCount = isAdd ?
                    blogInfo.CommentCount + 1 : blogInfo.CommentCount - 1;
                if (blogInfo.CommentCount >= 0)
                {
                    _blogDbContext.BlogInfoes.Update(blogInfo);

                    await _blogDbContext.SaveChangesAsync();
                    _blogDbContext.Database.CurrentTransaction?.Commit();
                }
            }
        }

        public Task<bool> ExistAsync(Guid id)
        {
            return _blogDbContext.BlogInfoes.AnyAsync(b => b.Id == id);
        }

        public Task<BlogInfo?> GetAsync(Guid id)
        {
            return _blogDbContext.BlogInfoes.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
