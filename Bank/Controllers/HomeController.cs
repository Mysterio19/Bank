using System.Linq;
using Bank.BL.Services.Abstract;
using Bank.Web.Extensions;
using Bank.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bank.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICardService _cardService;
        private readonly IDepositService _depositService;
        
        private ILogger<HomeController> _logger;

        public HomeController(ICardService cardService, IDepositService depositService, ILogger<HomeController> logger)
        {
            _cardService = cardService;
            _depositService = depositService;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new OverallViewModel();
            _logger.LogDebug(User.GetId().ToString());
            model.Cards = _cardService.GetAll(User.GetId()).Select(CardViewModel.From).ToList();
            model.Deposits = _depositService.ViewAllByUserId(User.GetId()).Select(DepositModel.From).ToList();

            _depositService.TakeMoney(User.GetId());            
            return View(model);
        }
    }
}