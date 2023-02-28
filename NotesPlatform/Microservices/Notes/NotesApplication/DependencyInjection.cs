using Microsoft.Extensions.DependencyInjection;

namespace NotesApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            return services;
        }
    }
}
