﻿global using Dapr;
global using Dapr.Client;
global using Dapr.Extensions.Configuration;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.SignalR;
global using Microsoft.eShopOnDapr.BuildingBlocks.EventBus;
global using Microsoft.eShopOnDapr.BuildingBlocks.EventBus.Abstractions;
global using Microsoft.eShopOnDapr.BuildingBlocks.EventBus.Events;
global using Microsoft.eShopOnDapr.Services.Ordering.API;
global using Microsoft.eShopOnDapr.Services.Ordering.API.Controllers;
global using Microsoft.eShopOnDapr.Services.Ordering.API.Infrastructure.Filters;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using System.IdentityModel.Tokens.Jwt;