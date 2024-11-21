using LivrosApp.DOMAIN.Interfaces.Repositories;
using LivrosApp.DOMAIN.Interfaces.Services;
using LivrosApp.Infra.DATA.Repositories;

namespace LivrosApp.API.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection (IServiceCollection services)

        {
            services.AddTransient<ILivroService, LivroService>();
            services.AddTransient<ILivrosRepository, LivroRepository>();
        }
    }
}
