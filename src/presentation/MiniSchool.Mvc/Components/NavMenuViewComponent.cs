using Microsoft.AspNetCore.Mvc;

namespace MiniSchool.Mvc.Components;

public class NavMenuViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}