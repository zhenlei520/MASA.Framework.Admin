﻿using MASA.Framework.Admin.Service.Blogs.Domain.Entities;
using MASA.Framework.Admin.Service.Blogs.Model.BlogAdvertisingPictures.Options;
using MASA.Framework.Admin.Service.Blogs.Model.BlogAdvertisingPictures.ViewModel;
using MASA.Framework.Data.EntityFrameworkCore;

namespace MASA.Framework.Admin.Service.Blogs.Domain.IRepositorys
{
    public interface IBlogAdvertisingPicturesRepository
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        Task<BlogAdvertisingPictures> CreateAsync(BlogAdvertisingPictures entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(BlogAdvertisingPictures entity);

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task RemoveAsync(params Guid[] ids);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<PageResult<BlogAdvertisingPicturesListViewModel>> GetListAsync(GetBlogAdvertisingPicturesOption options);
    }
}
