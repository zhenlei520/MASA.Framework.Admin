﻿namespace MASA.Framework.Admin.Contracts.Blogs
{
    public class AddBlogVisitModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid BlogId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid UserId { get; set; }
    }
}