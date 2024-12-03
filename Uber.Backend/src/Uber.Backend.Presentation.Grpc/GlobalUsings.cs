﻿global using System;
global using System.ServiceModel;
global using System.Threading.Tasks;
global using System.Collections.Generic;
global using System.Linq;
global using System.Reflection;
global using System.Runtime.CompilerServices;
global using Microsoft.AspNetCore.Routing;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;

global using Mapster;
global using MapsterMapper;
global using FluentResults;
global using ProtoBuf;
global using MediatR;
global using NKZSoft.Service.Configuration.Grpc.Extensions;
global using Uber.Backend.Application.Common.Paging;
global using Uber.Backend.Application.TodoItems.Models;
global using Uber.Backend.Application.TodoItems.Queries.GetItem;
global using Uber.Backend.Application.TodoItems.Queries.GetPage;
global using OpenTelemetry.Trace;
