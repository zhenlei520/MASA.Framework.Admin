﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MASA.Framework.Admin.Service.Blogs.Domain.Entities
{
    /// <summary>
    /// 广告图片
    /// </summary>
    public class BlogAdvertisingPictures : EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Required]
        [StringLength(36)]
        public Guid Id { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        [Required]
        [StringLength(500)]
        public string Pic { get; set; } = string.Empty;

        /// <summary>
        /// 类型：1 首页 2文章列表
        /// </summary>
        [Required]
        [DefaultValue(1)]
        public short Type { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        [DefaultValue(1)]

        public int Sort { get; set; }

        /// <summary>
        /// 状态：true启用 false停用
        /// </summary>
        public bool Status { get; set; }
    }
}
