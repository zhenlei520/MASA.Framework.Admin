global using FluentValidation;
global using FluentValidation.AspNetCore;
global using Masa.BuildingBlocks.Data.Contracts.DataFiltering;
global using Masa.BuildingBlocks.Data.UoW;
global using Masa.BuildingBlocks.Ddd.Domain.Entities;
global using Masa.BuildingBlocks.Ddd.Domain.Entities.Auditing;
global using Masa.BuildingBlocks.Ddd.Domain.Repositories;
global using Masa.BuildingBlocks.Dispatcher.Events;
global using Masa.Contrib.Data.Contracts.EF;
global using Masa.Contrib.Data.EntityFrameworkCore;
global using Masa.Contrib.Data.EntityFrameworkCore.SqlServer;
global using Masa.Contrib.Data.UoW.EF;
global using Masa.Contrib.Ddd.Domain;
global using Masa.Contrib.Ddd.Domain.Repository.EF;
global using Masa.Contrib.Dispatcher.Events;
global using Masa.Contrib.Dispatcher.IntegrationEvents.Dapr;
global using Masa.Contrib.Dispatcher.IntegrationEvents.EventLogs.EF;
global using Masa.Contrib.ReadWriteSpliting.Cqrs.Commands;
global using Masa.Contrib.ReadWriteSpliting.Cqrs.Queries;
global using Masa.Contrib.Service.MinimalAPIs;
global using Masa.Framework.Admin.Infrastructure.Configurations.Response;
global using Masa.Framework.Admin.Service.LogStatistics.Application.OperationLogs.Commands;
global using Masa.Framework.Admin.Service.LogStatistics.Application.OperationLogs.Queries;
global using Masa.Framework.Admin.Service.LogStatistics.Application.Statistics.Commands;
global using Masa.Framework.Admin.Service.LogStatistics.Domain.Aggregates;
global using Masa.Framework.Admin.Service.LogStatistics.Domain.Repositories;
global using Masa.Framework.Admin.Service.LogStatistics.Infrastructure;
global using Masa.Framework.Admin.Service.LogStatistics.Infrastructure.Const;
global using Masa.Framework.Admin.Service.LogStatistics.Infrastructure.Extensions;
global using Masa.Framework.Admin.Service.LogStatistics.Infrastructure.Jobs;
global using Masa.Framework.Admin.Service.LogStatistics.Infrastructure.Middlewares;
global using Masa.Framework.Admin.Service.LogStatistics.Infrastructure.Models;
global using Masa.Framework.Admin.Service.LogStatistics.Services;
global using Masa.Framework.Sdks.Authentication.Internal.Enum;
global using Masa.Framework.Sdks.Authentication.Request.LogStatistics;
global using Masa.Framework.Sdks.Authentication.Response.LogStatistics;
global using Masa.Utils.Exceptions.Extensions;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.OpenApi.Models;
global using Quartz;
global using Quartz.Impl;
global using Quartz.Spi;
global using System.Reflection;
