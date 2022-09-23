using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationApp.Configuration
{
    public class ServiceConfigurationValidator : IValidateOptions<ServiceConfiguration>
    {
        public ValidateOptionsResult Validate(string name, ServiceConfiguration options)
        {
            var validationResult = "";//TODO https://youtu.be/xFcnetdso-0?t=786

            if (string.IsNullOrEmpty(options.ApiKey))
            {
                validationResult += "Api key is missing";
            }

            if (!string.IsNullOrEmpty(validationResult))
            {
                return ValidateOptionsResult.Fail(validationResult);
            }

            return ValidateOptionsResult.Success;
        }
    }
}
