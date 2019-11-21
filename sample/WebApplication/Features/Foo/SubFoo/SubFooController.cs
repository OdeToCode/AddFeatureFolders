using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Features.Foo.SubFoo
{
    [Route("Foo/SubFoo/[controller]")]
    public class SubFooController : Controller
    {
        [HttpGet]
        public IActionResult SubFoo()
        {
            return View();
        }
    }
}