// Global using directives

global using System.Security.Claims;
global using System.Text;
global using FlockWise.API.Middleware;
global using FlockWise.Application.Interfaces;
global using FlockWise.Application.Models.Flock;
global using FlockWise.Application.Models.Requests;
global using FlockWise.Application.Models.User;
global using FlockWise.Application.Services;
global using FlockWise.Core.Entities;
global using FlockWise.Infrastructure.Options;
global using FlockWise.Infrastructure.Persistence;
global using FlockWise.Infrastructure.Repositories;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;