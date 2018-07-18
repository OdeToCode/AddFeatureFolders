using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Features.Foo.SubFoo
{
    public class SubFooController : Controller
    {
        [HttpGet]
        public IActionResult SubFoo()
        {
            return View();
        }
    }
}