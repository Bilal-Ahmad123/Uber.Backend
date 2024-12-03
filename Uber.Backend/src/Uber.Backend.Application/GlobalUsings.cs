global using System.Collections.Generic;
global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;
global using System.Reflection;

global using Microsoft.Extensions.Logging;
global using Microsoft.EntityFrameworkCore;
global using FluentValidation;
global using FluentResults;
global using MediatR;
global using Mapster;
global using MapsterMapper;
global using System.Linq.Expressions;
global using Ardalis.Specification;
global using FluentValidation.Results;
global using MassTransit;
global using MediatR.Pipeline;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Uber.Backend.Application.TodoItems.Specifications;
global using Uber.Backend.Common;

global using Uber.Backend.Domain.AggregatesModel.ToDoAggregates.Entities;
global using Uber.Backend.Domain.Events;
global using Uber.Backend.Events.ToDoItem.Create;
