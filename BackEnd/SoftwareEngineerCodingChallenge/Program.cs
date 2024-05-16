using Microsoft.AspNetCore.Http.Features;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SoftwareEngineerCodingChallenge.Models;
using System.Reflection;
using SoftwareEngineerCodingChallenge.Models.Interface;
using AutoMapper;
using SoftwareEngineerCodingChallenge.Services.Interface;
using SoftwareEngineerCodingChallenge.Services;

namespace SoftwareEngineerCodingChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Services.AddSingleton<IConfiguration>(options =>
            {
                var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
                return configurationBuilder.Build();
            });
            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });
            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersCountLimit = int.MaxValue;
            });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IAppDbContext, AppDbContext>();
            builder.Services.AddTransient<ICustomerService, CustomerService>();
            builder.Services.AddSingleton(new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new MappingProfile());
            }).CreateMapper());
            builder.Services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            string dbConnectionString = builder.Configuration.GetConnectionString("SoftwareEngineerCodingChallenge");
            builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            {
                options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name);
                });
            });
            builder.Services.AddMvc();
            var app = builder.Build();
            using (IServiceScope scope = app.Services.CreateScope())
            {
                try
                {
                    AppDbContext dbContext = (AppDbContext)scope.ServiceProvider.GetService<IAppDbContext>();
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error ocurred while migrating or initializing the database");
                }
            }
            app.UseCors(options =>
            {
                options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
            app.UseStaticFiles();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}