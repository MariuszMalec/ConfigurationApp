using ConfigurationApp.Configuration;
using Microsoft.Extensions.Options;

namespace ConfigurationApp.Services
{
    public class SampleService
    {
        private ServiceConfiguration _serviceConfiguration;

        public SampleService(IOptions<ServiceConfiguration> serviceConfigurationOptions)
        {
            //2
            //check if variable from apppsettings.json is empty ale trzeba powielac jesli chcemu uzyc w innym servisie
            //if (serviceConfigurationOptions is null)
            //{
            //    throw new ArgumentNullException("serviceconfiguration.Value is missing!");
            //}
            //if (string.IsNullOrEmpty(serviceConfigurationOptions.Value.ApiKey))
            //{
            //    throw new ArgumentNullException("serviceconfiguration.Value.ApiKey is missing!");
            //}

            _serviceConfiguration = serviceConfigurationOptions.Value;
        }

        public ServiceConfiguration GetOptions()
        {
            return _serviceConfiguration;
        }
    }
}
