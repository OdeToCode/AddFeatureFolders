using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Features.Shared.Components.MainMenu
{
    public class MainMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}