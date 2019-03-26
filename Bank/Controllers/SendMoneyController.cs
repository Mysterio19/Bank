using Bank.BL.Services.Abstract;
using Bank.Web.Extensions;
using Bank.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bank.Web.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly ISendMoneyService _sendMoneyService;

        public SendMoneyController(ISendMoneyService sendMoneyService)
        {
            _sendMoneyService = sendMoneyService;
        }

        [HttpGet]
        public IActionResult SenderTab()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TransactionViewModel model)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                var transaction = model.To(User.GetId());
                transaction.Receiver = _sendMoneyService.GetClientByCardNumber(model.CardNumber);

                 _sendMoneyService.SendMoney(model.To(User.GetId()));
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

