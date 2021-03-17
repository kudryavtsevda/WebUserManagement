using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace WebUserManagement.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var str = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
    }
}
