using Microsoft.AspNetCore.Mvc;

namespace BookDonors.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
