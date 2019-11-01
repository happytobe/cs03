using TC_CS03_API.Contracts;
using TC_CS03_API.DTO;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TC_CS03_API.Installers
{
    public class RegisterModelValidators : IServiceRegistration
    {
        /// <summary>
        /// Responsible for registering all validators for DTO models
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            //Register DTO Validators
            services.AddTransient<IValidator<ReviewRatingTypeDTO>, ReviewRatingTypeDTOValidator>();
            services.AddTransient<IValidator<ReviewDTO>, ReviewDTOValidator>();
        }
    }
}
