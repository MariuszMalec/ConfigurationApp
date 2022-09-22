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
            throw new NotImplementedException();//TODO https://youtu.be/xFcnetdso-0?t=786
        }
    }
}
