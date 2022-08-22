using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
using WebApp.Models.ViewModels;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, IMapper mapper)
        {
            _logger = logger;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            ViewBag.product = _mapper.Map<ProductViewModel>(_productRepository.GetById(6));

            ViewBag.products = _mapper.Map<List<ProductViewModel>>(_productRepository.GetAll());

            ViewData["Title"] = "Home Page";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult ExamplePage()
        {
            string name = "Asp.Net Core MVC 8";
            var name2 = "Visual Studio";

            ViewData["Name"] = name;
            ViewBag.name2 = name2;

            return View();
        }

        public IActionResult ContentPage()
        {


            return Content("Bu sayfa content page'dir");
        }

        public IActionResult JsonPage()
        {


            return Json(new { Id = 1, Name = "Kalem 1", Price = 300 });
        }

        public IActionResult EmptyPage()
        {

            return new EmptyResult();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }

        [Route("Hakkimizda")]
        public IActionResult About()
        {
            ViewBag.productList = _mapper.Map<List<ProductViewModel>>(_productRepository.GetAll());

            return View();
        }

        [HttpPost]
        [Route("urunler/name/{name}/color/{color}/stock/{stock}", Name = "productLink")]
        public IActionResult Product([FromRoute] string name, [FromRoute] string color, [FromRoute] int stock, [FromQuery] int productId, [FromForm] string categoryName)
        {
            return View();
        }

        
        public IActionResult Page(int stock, string name)
        {
            ViewBag.productList = _mapper.Map<List<ProductViewModel>>(_productRepository.GetAll());
            return View();
        }

        [Route("[controller]/[action]/{productId:range(5,10)}")]
        public IActionResult ConstraintPage(int productId)
        {
            ViewBag.productId = productId;
            return View();
        }
    }
}