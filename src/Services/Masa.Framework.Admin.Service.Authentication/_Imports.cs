global using Dapr;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using Masa.BuildingBlocks.Data.UoW;
global using Masa.BuildingBlocks.Ddd.Domain.Entities;
global using Masa.BuildingBlocks.Ddd.Domain.Entities.Full;
global using Masa.BuildingBlocks.Ddd.Domain.Events;
global using Masa.BuildingBlocks.Ddd.Domain.Repositories;
global using Masa.BuildingBlocks.Dispatcher.Events;
global using Masa.Contrib.Data.Contracts.EF;
global using Masa.Contrib.Data.EntityFrameworkCore;
global using Masa.Contrib.Data.EntityFrameworkCore.SqlServer;
global using Masa.Contrib.Data.UoW.EF;
global using Masa.Contrib.Ddd.Domain;
global using Masa.Contrib.Ddd.Domain.Events;
global using Masa.Contrib.Ddd.Domain.Repository.EF;
global using Masa.Contrib.Dispatcher.Events;
global using Masa.Contrib.Dispatcher.IntegrationEvents.Dapr;
global using Masa.Contrib.Dispatcher.IntegrationEvents.EventLogs.EF;
global using Masa.Contrib.ReadWriteSpliting.Cqrs.Commands;
global using Masa.Contrib.ReadWriteSpliting.Cqrs.Queries;
global using Masa.Contrib.Service.MinimalAPIs;
global using Masa.Framework.Admin.Contracts.Authentication;
global using Masa.Framework.Admin.Infrastructure.Configurations.Const;
global using Masa.Framework.Admin.Infrastructure.Configurations.Response;
global using Masa.Framework.Admin.Service.Authentication.Application.Permissions.Commands;
global using Masa.Framework.Admin.Service.Authentication.Application.Permissions.Queries;
global using Masa.Framework.Admin.Service.Authentication.Application.Roles.Commands;
global using Masa.Framework.Admin.Service.Authentication.Application.Roles.Queries;
global using Masa.Framework.Admin.Service.Authentication.Application.Roles.Queries.Cache;
global using Masa.Framework.Admin.Service.Authentication.Domain.Aggregates.PermissionAggregate;
global using Masa.Framework.Admin.Service.Authentication.Domain.Aggregates.RoleAggregate;
global using Masa.Framework.Admin.Service.Authentication.Domain.Enum;
global using Masa.Framework.Admin.Service.Authentication.Domain.Events;
global using Masa.Framework.Admin.Service.Authentication.Domain.Repositories;
global using Masa.Framework.Admin.Service.Authentication.Domain.Services;
global using Masa.Framework.Admin.Service.Authentication.Infrastructure;
global using Masa.Framework.Admin.Service.Authentication.Infrastructure.Cache;
global using Masa.Framework.Admin.Service.Authentication.Infrastructure.EntityConfigurations;
global using Masa.Framework.Admin.Service.Authentication.Infrastructure.Extensions;
global using Masa.Framework.Admin.Service.Authentication.Infrastructure.Middleware;
global using Masa.Framework.Admin.Service.Authentication.Response.Permission;
global using Masa.Framework.Admin.Service.Authentication.Response.Role;
global using Masa.Utils.Caching.Core.Interfaces;
global using Masa.Utils.Caching.DistributedMemory.DependencyInjection;
global using Masa.Utils.Caching.Redis.DependencyInjection;
global using Masa.Utils.Exceptions.Extensions;
global using Masa.Utils.Extensions.Expressions;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.OpenApi.Models;
global using System.Linq.Expressions;
global using System.Text.Json;
global using CacheConst = Masa.Framework.Admin.Service.Authentication.Infrastructure.Const;
