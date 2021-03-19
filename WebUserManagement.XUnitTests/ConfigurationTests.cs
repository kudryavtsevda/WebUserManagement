using FluentAssertions;
using System;
using System.Configuration;
using Xunit;
using Xunit.Abstractions;

namespace WebUserManagement.XUnitTests
{
    public class ConfigurationTests
    {
        [Fact]
        public void Can_Get_Configuration()
        {
            var configHelper = new ConfigurationHelper();
            var config = configHelper.GetConfiguration();

            config.Should().NotBeNull("Configuration cannot be null");
            config.Connection.Should().NotBeNull("Connection can not be null")
                .And.Should().NotBeSameAs(string.Empty,"Connection can not be null");            
        }
    }
}
