using Microsoft.Extensions.DependencyInjection;
using NotesApi.Models;
using NotesApplication.Interfaces;
using NotesApplication.Services;
using NotesPersistence;
using System.Text.Json;

namespace NotesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddPersistence(builder.Configuration);

            using (var serviceProvider = builder.Services.BuildServiceProvider())
            {
                var context = serviceProvider.GetRequiredService<NotesDbContext>();
                DbInitializer.Initialize(context);
            }

            builder.Services.AddScoped<INotesService>(s => new NotesService(s.GetRequiredService<ILogger<Program>>(), s.GetRequiredService<INotesDbContext>()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}