using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesApplication.Interfaces;

namespace NotesPersistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
           IConfiguration configuration, bool isDevelopment = false)
        {
            var connectionString = configuration["DbConnection"];

            if (isDevelopment)
            {
                services.AddDbContext<NotesDbContext>(options =>
                {
                    options.UseSqlite(connectionString);
                });
            }
            else
            {
                services.AddEntityFrameworkNpgsql()
                .AddDbContext<NotesDbContext>(options =>
                {
                    options.UseNpgsql(connectionString);
                });
            }            

            services.AddTransient<INotesDbContext>(s => s.GetRequiredService<NotesDbContext>());

            return services;
        }
    }
}
