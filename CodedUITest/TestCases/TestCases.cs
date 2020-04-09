using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUITest
{
    [DeploymentItem("configuration.json")]
    [CodedUITest]
    public class TestCases
    {
        public IConfiguration Configuration { get; private set; }

        public TestContext TestContext { get; set; }
       
        [TestInitialize]
        public void Setup()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("configuration.json").Build();
        }
       
        [TestMethod]
        public void TestOpenApplication()
        {
            Actions
                .OpenApplication(Configuration)
                .OpenNewProject(Configuration);
        }
    }
}