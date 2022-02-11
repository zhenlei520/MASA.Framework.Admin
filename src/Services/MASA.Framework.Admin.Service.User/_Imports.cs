global using FluentValidation;
global using FluentValidation.AspNetCore;
global using MASA.BuildingBlocks.Data.UoW;
global using MASA.BuildingBlocks.DDD.Domain.Entities.Auditing;
global using MASA.BuildingBlocks.DDD.Domain.Repositories;
global using MASA.BuildingBlocks.Dispatcher.Events;
global using MASA.Contrib.Data.UoW.EF;
global using MASA.Contrib.DDD.Domain;
global using MASA.Contrib.DDD.Domain.Repository.EF;
global using MASA.Contrib.Dispatcher.Events;
global using MASA.Contrib.Dispatcher.IntegrationEvents.Dapr;
global using MASA.Contrib.Dispatcher.IntegrationEvents.EventLogs.EF;
global using MASA.Contrib.ReadWriteSpliting.CQRS.Queries;
global using MASA.Contrib.Service.MinimalAPIs;
global using MASA.Framework.Admin.Contracts.Base.Commands;
global using MASA.Framework.Admin.Contracts.Base.Const;
global using MASA.Framework.Admin.Contracts.Base.Enum;
global using MASA.Framework.Admin.Contracts.Base.Extensions.Exceptions;
global using MASA.Framework.Admin.Contracts.Base.Response;
global using MASA.Framework.Admin.Contracts.User;
global using MASA.Framework.Admin.Contracts.User.Enum;
global using MASA.Framework.Admin.Contracts.User.Request;
global using MASA.Framework.Admin.Contracts.User.Response;
global using MASA.Framework.Admin.Service.User.Application.Users.Commands;
global using MASA.Framework.Admin.Service.User.Application.Users.Queres;
global using MASA.Framework.Admin.Service.User.Domain.Aggregate;
global using MASA.Framework.Admin.Service.User.Domain.Repository;
global using MASA.Framework.Admin.Service.User.Extensions.Middleware;
global using MASA.Framework.Admin.Service.User.Extensions.Middleware.GlobalException;
global using MASA.Framework.Admin.Service.User.Infrastructure;
global using MASA.Framework.Admin.Service.User.Infrastructure.Extensions;
global using MASA.Framework.Admin.Service.User.Services;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.OpenApi.Models;
