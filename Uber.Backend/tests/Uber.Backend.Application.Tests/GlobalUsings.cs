﻿global using Xunit;
global using MediatR;
global using Moq;
global using FluentAssertions;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Uber.Backend.Application.Common.Paging;
global using Uber.Backend.Application.Common.Repositories.PostgreSql;
global using Uber.Backend.Application.Tests.Common;
global using Uber.Backend.Application.TodoItems.Commands.Create;
global using Uber.Backend.Application.TodoItems.Commands.Delete;
global using Uber.Backend.Application.TodoItems.Models;
global using Uber.Backend.Application.TodoItems.Queries.GetPage;
global using Uber.Backend.Persistence.PostgreSQL.Repositories;
