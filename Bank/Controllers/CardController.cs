using System;
using Bank.BL.Services.Abstract;
using Bank.Web.Extensions;
using Bank.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Web.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CardModel model)
        {
            if (!ModelState.IsValid) return View();
            
            try
            {
                _cardService.Create(model.To(User.GetId()));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}