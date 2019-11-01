using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TC_CS03_API.Contracts
{
    /// <summary>
    /// Interface used by services that are added in IServiceCollection
    /// </summary>
    public interface IServiceRegistration
    {
        void RegisterAppServices(IServiceCollection services, IConfiguration configuration);
    }
}
