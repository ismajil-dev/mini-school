using Microsoft.AspNetCore.Mvc;

namespace MiniSchool.Mvc.Components;

public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}