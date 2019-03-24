using System.Threading.Tasks;
using Bank.DAL.Models;

namespace Bank.BL.Services.Abstract
{
    public interface IUserService
    {
        Client GetUserByUserNameAndPassword(string userName, string password);
        
        Client GetUserByUserName(string userName);

        Task AuthenticateAsync(Client client);

        Client Create(Client client);
    }
}