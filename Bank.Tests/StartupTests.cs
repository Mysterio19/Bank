using System.IO;
using Bank.BL.Services.Abstract;
using Bank.BL.Services.Concrete;
using Bank.DAL;
using Bank.DAL.Models;
using Bank.Web;
using Bank.Web.Common;
using Microsoft.AspNetCore.Http;
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
            
            provider.GetService<IUserService>().ShouldNotBeNull();
            provider.GetService<IUserService>().ShouldBeOfType<UserService>();
            
            provider.GetService<IDepositService>().ShouldNotBeNull();
            provider.GetService<IDepositService>().ShouldBeOfType<DepositService>();

            provider.GetService<IHttpContextAccessor>().ShouldNotBeNull();
            provider.GetService<IHttpContextAccessor>().ShouldBeOfType<HttpContextAccessor>();
            
            provider.GetService<BankDbContext>().ShouldNotBeNull();
            
            provider.GetService<ICardService>().ShouldNotBeNull();
            provider.GetService<ICardService>().ShouldBeOfType<CardService>();
            
            provider.GetService<ICommentService>().ShouldNotBeNull();
            provider.GetService<ICommentService>().ShouldBeOfType<CommentService>();

            provider.GetService<ISendMoneyService>().ShouldNotBeNull();
            provider.GetService<ISendMoneyService>().ShouldBeOfType<SendMoneyService>();

            provider.GetService<ILoanService>().ShouldNotBeNull();
            provider.GetService<ILoanService>().ShouldBeOfType<LoanService>();
        }
    }
}