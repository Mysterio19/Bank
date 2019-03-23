using System.IO;
using Bank.DAL;
using Bank.Web;
using Bank.Web.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using Shouldly;
using Xunit;

namespace Bank.Tests
{
    
    public class StartupTests
    {    
        [Fact]
        public void ServiceProviderTesting()
        {
            var startup = new Startup();

            var serviceCollection = new ServiceCollection();
            startup.ConfigureServices(serviceCollection);

            var provider = serviceCollection.BuildServiceProvider();

            provider.GetService<IOptions<AppSettings>>().ShouldNotBeNull();
        }
    }
}