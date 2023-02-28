using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesApplication.Interfaces;

namespace NotesPersistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
           IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<NotesDbContext>(options =>
                {
                    options.UseNpgsql(connectionString);
                });

            services.AddTransient<INotesDbContext>(s => s.GetRequiredService<NotesDbContext>());

            return services;
        }
    }
}
