using ApiExceptions.Middlewares;
using NotesApplication.Interfaces;
using NotesApplication.Services;
using NotesPersistence;
using Serilog;
using ILogger = Serilog.ILogger;

namespace NotesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureAppServices(builder.Services, builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseSerilog();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()
                || app.Environment.IsStaging())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCustomExceptionHandler();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void ConfigureAppServices(IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
               .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Error)
               .WriteTo.File(Path.Combine("Logs","NotesApiLog-.txt"), rollingInterval: RollingInterval.Day)
               .CreateLogger();

            services.AddPersistence(configuration);

            services.AddSingleton<ILogger>(Log.Logger);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var context = serviceProvider.GetRequiredService<NotesDbContext>();
                DbInitializer.Initialize(context);
            }

            services.AddScoped<INotesService>(s => new NotesService(s.GetRequiredService<ILogger>(), s.GetRequiredService<INotesDbContext>()));

        }
    }
}