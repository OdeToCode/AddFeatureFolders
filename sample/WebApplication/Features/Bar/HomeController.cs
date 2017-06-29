using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Features.Bar
{
    [Route("Bar/[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search()
        {
            // do some stuff...
            return View("Home");            
            // this will also work
            // return Redirect("/Bar/Home");

            // TODO: posting to /Foo/Home or /Bar/Home with Content-Type: application/x-www-form-urlencoded always routes to the "Bar" feature controller            
            // return RedirectToAction("Home");
        }
    }
}
