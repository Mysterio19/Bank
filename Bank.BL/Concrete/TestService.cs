using Bank.BL.Abstract;
using Bank.DAL;
using Bank.DAL.Models;
using Bank.DAL.Repositories;
using System;

namespace Bank.BL.Concrete
{
    public class TestService : IService // this service is just for the test
    {
        private IRepository<Client> _repo = new RepositoryBase<Client>(new BankDbContext()); 

        public object DoIt(object param)
        {
            _repo.Add(new Client
            {
                
            });
            throw new NotImplementedException();
        }
    }
}
