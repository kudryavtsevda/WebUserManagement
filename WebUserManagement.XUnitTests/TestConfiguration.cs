namespace WebUserManagement.XUnitTests
{
    public class TestConfiguration
    {
        public TestConfiguration(string connectionString)
        {
            Connection = connectionString;
        }
        public string Connection { get;  }
    }
}
