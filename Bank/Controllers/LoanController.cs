using System;
using Bank.BL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bank.Web.Controllers
{
    public class LoanController : Controller
    {
        private ILogger<LoanController> _logger;
        private ILoanService _loanService;

        public LoanController(ILogger<LoanController> logger, ILoanService loanService)
        {
            _logger = logger;
            _loanService = loanService;
        }

        public IActionResult Create()
        {
            throw new NotImplementedException();
        }
        

        public IActionResult Refill()
        {
            throw new NotImplementedException();
        }
    }
}