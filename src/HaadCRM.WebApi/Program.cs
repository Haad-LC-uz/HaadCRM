using HaadCRM.Data.Contexts;
using HaadCRM.Service.Helpers;
using HaadCRM.Service.Mappers;
using HaadCRM.WebApi.Extensions;
using HaadCRM.WebApi.Helpers;
using HaadCRM.WebApi.MiddleWares;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
    options.Conventions.Add(new RouteTokenTransformerConvention(new RouteHelper())));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenJwt();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<HaadDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddAuthorization();
builder.Services.AddJwtService(builder.Configuration);

builder.Services.AddServices();
builder.Services.AddValidators();
builder.Services.AddMemoryCache();


EnvironmentHelper.WebRootPath = builder.Environment.WebRootPath;

var app = builder.Build();

//using var scope = app.Services.CreateScope();
//HttpContextHelper.ContextAccessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
//var context = scope.ServiceProvider.GetRequiredService<HaadDbContext>();
//context.Database.EnsureCreated();
//context.Database.Migrate();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<HaadDbContext>();

    dbContext.Database.EnsureCreated();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();       

app.UseMiddleware<ExceptionHandlerMiddleWare>();

app.Run();