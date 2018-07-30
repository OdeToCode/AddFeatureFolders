using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Administration.Features.Test
{
    [Area("Administration")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", typeof(TestController));
        }
    }
}