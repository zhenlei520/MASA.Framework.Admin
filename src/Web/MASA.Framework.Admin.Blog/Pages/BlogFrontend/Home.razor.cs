﻿using MASA.Framework.Admin.Blog.Data.Blog;
using MASA.Framework.Admin.Caller;
using MASA.Framework.Admin.Contracts.Blogs.BlogAdvertisingPictures.Enums;

namespace MASA.Framework.Admin.Blog.Pages.BlogFrontend
{
    public partial class Home
    {
        private int _page = 1;
        private int _pageCount = 1;
        private bool _showWrite = false;
        private CreateBlogInfoModel _options = new() { State = StateTypes.Reviewed };
        private List<(Guid, string)> _typeList = new();

        public PagingResult<BlogInfoHomeListViewModel> Blogs { get; set; } =
            new PagingResult<BlogInfoHomeListViewModel>();

        public List<BlogAdvertisingPicturesListViewModel> Ad { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            await FetchBlogs();
        }


        [Inject] protected BlogCaller BlogCaller { get; set; }


        private async Task FetchBlogs()
        {
            Blogs = await BlogCaller.ArticleService.BlogArticleHomeAsync(new GetBlogArticleHomeOptions()
            {
                PageIndex = _page,
                PageSize = 10
            });
            if (Blogs.TotalCount > 0)
            {
                _pageCount = Convert.ToInt32(Math.Ceiling((Decimal)Blogs.TotalCount / Convert.ToDecimal(Blogs.Size)));
            }
        }

        protected override async void OnInitialized()
        {
            //分类
            var typesResult = await BlogCaller.BlogTypeService.PagingAsync(new GetBlogTypePagingOption()
                { PageIndex = 1, PageSize = int.MaxValue });
            if (typesResult.Data is not null)
            {
                _typeList = typesResult.Data.Select(m => (m.Id, m.TypeName)).ToList();
            }
        }

        private void ToWrite()
        {
            _showWrite = true;
        }

        public async Task SubmitBlog()
        {
            await BlogCaller.ArticleService.CreateAsync(_options);
            _showWrite = false;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <returns></returns>
        private async Task Cancel()
        {
            _showWrite = true;
        }

        /// <summary>
        /// 获取首页广告位
        /// </summary>
        private async Task GetAdAsync()
        {
            await BlogCaller.AdvertisingPicturesService.GetList(new()
            {
                Types = new()
                {
                    BlogAdvertisingPicturesTypes.Home,
                    BlogAdvertisingPicturesTypes.HomeLowerRight
                }
            });
        }
    }
}