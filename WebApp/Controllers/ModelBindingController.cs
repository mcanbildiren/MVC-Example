using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ModelBindingController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // baseurl/modelbinding/create?id=5
        [HttpPost]
        public IActionResult Create(string name, string age, [FromQuery] int productId)
        {

            return View();

        }

        [Route("[controller]/[action]/page/{page}/pageSize/{pageSize}")]
        public IActionResult DoSomething(int page, int pageSize)
        {

            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            return View();
        }


    }
}