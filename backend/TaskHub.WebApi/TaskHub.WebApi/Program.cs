using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskHub.WebApi.Context;
using TaskHub.WebApi.Mappings;
using TaskHub.WebApi.Repository;
using TaskHub.WebApi.Repository.Interfaces;
using TaskHub.WebApi.Services;
using TaskHub.WebApi.Services.Interfaces;
using TaskHub.WebApi.DTOs;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// mapper
builder.Services.AddAutoMapper(typeof(TaskItemProfile));
builder.Services.AddAutoMapper(typeof(TaskStatusProfile));

// repository
builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
builder.Services.AddScoped<ITaskStatusRepository, TaskStatusRepository>();

// services
builder.Services.AddScoped<ITaskItemServices, TaskItemServices>();
builder.Services.AddScoped<ITaskStatusServices, TaskStatusServices>();

// auth 
builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "TaskHub.Api",
                        ValidateAudience = true,
                        ValidAudience = "TaskHub.Client",
                        ValidateLifetime = false, //test
                        IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes("3a58c48f6d0673c9145faca10577845d432a47cef9731c01317933dc06fe406d")),
                        ValidateIssuerSigningKey = true
                    };
                });

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(e => e.Value?.Errors.Count > 0)
            .ToDictionary(
                e => e.Key,
                e => e.Value?.Errors.Select(er => er.ErrorMessage).ToArray()
            );

        var response = new ApiResponseDto<Dictionary<string, string[]>>
        {
            StatusCode = 400,
            Message = "Invalid Data",
            Data = errors 
        };

        return new BadRequestObjectResult(response);
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
