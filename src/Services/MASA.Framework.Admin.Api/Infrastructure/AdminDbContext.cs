﻿using MASA.Framework.Admin.Service.Api.Infrastructure.Entities;

namespace MASA.Framework.Admin.Service.Infrastructure
{
    public class AdminDbContext : IntegrationEventLogContext
    {
        public AdminDbContext(MasaDbContextOptions<AdminDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreatingExecuting(ModelBuilder builder)
        {
            builder.Entity<User>()
                .Property(t => t.ModificationTime)
                .HasDefaultValueSql("SYSDATETIME()");
        }

        public DbSet<User> Users { get; set; } = default!;
    }
}