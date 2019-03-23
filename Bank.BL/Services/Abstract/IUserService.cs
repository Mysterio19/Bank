using System.Threading.Tasks;
using Bank.DAL.Models;

namespace Bank.BL.Services.Abstract
{
    public interface IUserService
    {
        Client GetUserByUserName(string userName);
        
        Task Authenticate(string userName);

        Client Create(Client client);
    }
}