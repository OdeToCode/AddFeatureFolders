using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Features.Home
{
    [Route("")]
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Create()
        {
            return Content("Create");
        }
    }
}
