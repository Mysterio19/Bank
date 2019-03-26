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
        private readonly IDepositService _depositService;

        public HomeController(ICardService cardService, IDepositService depositService)
        {
            _cardService = cardService;
            _depositService = depositService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new OverallViewModel();

            model.Cards = _cardService.GetAll(User.GetId()).Select(CardViewModel.From).ToList();
            model.Deposits = _depositService.ViewAllByUserId(User.GetId()).Select(DepositModel.From).ToList();

            return View(model);
        }
    }
}