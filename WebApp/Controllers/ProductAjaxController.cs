using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class ProductAjaxController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;



        public ProductAjaxController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetProductList()
        {

            return Json(_mapper.Map<List<ProductViewModel>>(_context.Products.ToList()));


        }
        [HttpPost]
        public IActionResult SaveProduct(ProductCreateViewModel product)
        {

            var newProduct = _mapper.Map<Product>(product);

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return Json(new { success = true });



        }
    }
}