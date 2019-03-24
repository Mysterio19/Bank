using System.Linq;
using Bank.BL.Services.Abstract;
using Bank.Web.Extensions;
using Bank.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICardService _cardService;

        public HomeController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new OverallViewModel();

            model.Cards = _cardService.GetAll(User.GetId()).Select(CardViewModel.From).ToList();

            return View(model);
        }
    }
}