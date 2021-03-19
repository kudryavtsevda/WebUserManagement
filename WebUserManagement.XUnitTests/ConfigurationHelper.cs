using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUserManagement.XUnitTests
{
    public class ConfigurationHelper
    {
        public TestConfiguration GetConfiguration()
        {
            return new TestConfiguration(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
        }
    }
}
