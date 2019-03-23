using System.ComponentModel.DataAnnotations;
using Bank.DAL.Models;
using static Bank.Common.Constants.ErrorMessages;

namespace Bank.Web.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password does not equal to ConfirmPassword")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string INN { get; set; }

        public Client To()
        {
            return new Client
            {
                UserName = UserName,
                Password = Password,
                IsBlocked = false,
                IsCompany = false,
                INN = INN,
                LastName = LastName,
                FirstName = FirstName
            };
        }
    }
    
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName required")]
        public string UserName { get; set; }
         
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}