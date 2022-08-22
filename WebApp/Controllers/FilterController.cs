using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;

namespace WebApp.Controllers
{
    //[MyFilter]
    public class FilterController : Controller
    {
        [MyFilter]
        public IActionResult Index()
        {
            var name = "qwe asd";
            return View();
        }

        [MyFilter]
        public IActionResult Page()
        {
            return View();
        }
    }
}
