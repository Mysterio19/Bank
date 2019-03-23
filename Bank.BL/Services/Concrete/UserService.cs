using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Bank.BL.Services.Abstract;
using Bank.DAL.Models;
using Bank.DAL.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using static Bank.Common.Constants.ErrorMessages;

namespace Bank.BL.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<UserService> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IUnitOfWork uow, ILoggerFactory loggerFactory, IHttpContextAccessor contextAccessor)
        {
            _uow = uow;
            _contextAccessor = contextAccessor;
            _logger = loggerFactory.CreateLogger<UserService>();
        }

        public Client GetUserByUserName(string userName)
        {
            return _uow.Repository<Client>().GetQueryable().SingleOrDefault(client => client.UserName == userName && !client.IsBlocked);
        }

        public Client Create(Client client)
        {
            if (client == null)
                throw new ArgumentException(ParameterIsRequired(nameof(client)));
            
            if (string.IsNullOrWhiteSpace(client.UserName))
                throw new ArgumentException(ParameterIsRequired(nameof(client.UserName)));

            if (string.IsNullOrWhiteSpace(client.Password))
                throw new ArgumentException(ParameterIsRequired(nameof(client.Password)));
            
            if (string.IsNullOrWhiteSpace(client.INN))
               throw new ArgumentException(ParameterIsRequired(nameof(client.INN)));
           
            var existedClient = GetUserByUserName(client.UserName);
            
            if(existedClient != null)
                throw new ArgumentException("UserName has already exist");
            
            _uow.Repository<Client>().Add(client);
            _uow.SaveChanges();

            return client;
        }
        
        public async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public void Block(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException(ParameterIsRequired(nameof(userName)));
            
            var existedClient = GetUserByUserName(userName);
            
            if(existedClient == null)
                throw new ArgumentException("UserName does not exist");

            existedClient.IsBlocked = true;
            _uow.SaveChanges();
        }
    }
}