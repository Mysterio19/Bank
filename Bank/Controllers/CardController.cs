using Microsoft.AspNetCore.Mvc;

namespace Bank.Web.Controllers
{
    public class CardController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}