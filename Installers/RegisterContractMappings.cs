using TC_CS03_API.Contracts;
using TC_CS03_API.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TC_CS03_API.Installers
{
    public class RegisterContractMappings : IServiceRegistration
    {
        /// <summary>
        /// Responsible for registering all interface mappings between contract repositories and concrete classes that implement the contracts
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            //Register Interface Mappings for Repositories
            services.AddTransient<IReviewRatingTypeManager, ReviewRatingTypeManager>();
            services.AddTransient<IReviewManager, ReviewManager>();
        }
    }
}
