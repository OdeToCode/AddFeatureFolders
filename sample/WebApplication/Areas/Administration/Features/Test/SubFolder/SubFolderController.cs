using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Administration.Features.Test.SubFolder
{
    [Area("Administration")]
    public class SubFolderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}