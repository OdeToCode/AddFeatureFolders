using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Administration.Overview
{
    [Area("Administration")]
    public class OverviewController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}