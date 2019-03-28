using System;
using System.Linq;
using Bank.BL.Services.Abstract;
using Bank.DAL.Models;
using Bank.Web.Extensions;
using Bank.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bank.Web.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILogger<LoanController> _logger;
        private readonly ILoanService _loanService;
        private readonly ICardService _cardService;

        public LoanController(ILogger<LoanController> logger, ILoanService loanService, ICardService cardService)
        {
            _logger = logger;
            _loanService = loanService;
            _cardService = cardService;
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var model = new LoanModel();
            model.Cards = _cardService.GetAll(User.GetId()).ToList();

            return View(model);
        }
        

        [HttpPost]
        public IActionResult Create(LoanModel loan)
        {
            if (!ModelState.IsValid) return View();

            try
            {
               _loanService.Create(loan.To());
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        

        public IActionResult Refill(LoanModel loan)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Home");

            try
            {
                _loanService.Refill(loan.To());
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}