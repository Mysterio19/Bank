using System;
using System.Linq;
using Bank.BL.Services.Abstract;
using Bank.DAL.Repositories;
using Bank.Web.Extensions;
using Bank.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bank.Web.Controllers
{
    public class DepositController : Controller
    {
        private readonly IDepositService _depositService;
        private readonly ICardService _cardService;
        private readonly ILogger<DepositController> _logger;
        private readonly IUnitOfWork _uow;

        public DepositController(IDepositService depositService, ICardService cardService, ILoggerFactory loggerFactory, IUnitOfWork uow)
        {
            _depositService = depositService;
            _cardService = cardService;
            _uow = uow;
            _logger = loggerFactory.CreateLogger<DepositController>();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new DepositModel();
            model.Cards = _cardService.GetAll(User.GetId()).ToList();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(DepositModel model)
        {
            model.Cards = _cardService.GetAll(User.GetId()).ToList();
            if (!ModelState.IsValid) return View(model);

            try
            {
                _uow.BeginTransaction();
                _depositService.Create(model.To());
                _uow.CommitTransaction();
            }
            catch (Exception e)
            {
                _logger.LogDebug("Deposit service throw exception: " + e.Message);
                ModelState.AddModelError("", e.Message);
                _uow.RollbackTransaction();

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}