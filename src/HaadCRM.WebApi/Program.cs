using HaadCRM.Data.Contexts;
using HaadCRM.Service.Helpers;
using HaadCRM.Service.Mappers;
using HaadCRM.WebApi.Extensions;
using HaadCRM.WebApi.MiddleWares;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PathHelper = HaadCRM.Service.Helpers.PathHelper;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGenJwt();
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddDbContext<HaadDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddValidators();

        builder.Services.AddJwtService(builder.Configuration);

        builder.Services.AddServices();
        builder.Services.AddProblemDetails();

        builder.Services.AddSwaggerGenJwt();
        builder.Services.AddMemoryCache();
        builder.Services.AddHttpContextAccessor();

        var app = builder.Build();

        HttpContextHelper.ContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
        PathHelper.WebRootPath = Path.GetFullPath("wwwroot");

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
    }
}