using Microsoft.AspNetCore.Mvc;

namespace BookDonors.Controllers
{
    [Route("AboutUs")]
    public class AboutUsController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
