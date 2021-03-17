using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUserManagement.Tests
{
    public class ConfigurationHelper
    {
        /// <summary>
        /// C'tor
        /// </summary>
        public ConfigurationHelper()
        { }
        /// <summary>
        /// Get configuration root
        /// </summary>
        /// <param name="outputPath"></param>
        
        /// <summary>
        /// Get TestConfiguration
        /// </summary>
        public TestConfiguration GetConfiguration(string basePath)
        {
            var configuration = new TestConfiguration();
            var iConfigRoot = GetConfigurationRoot(basePath);
            iConfigRoot
                .GetSection("DapperTesting")
                .Bind(configuration);
            return configuration;
        }
    }
}
