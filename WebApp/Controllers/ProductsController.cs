using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Filters;
using WebApp.Models;
using WebApp.Models.ViewModels;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {



            var products = _productRepository.GetAll();

            var tableName = "Ürünler";

            //1.yol
            // return View(Tuple.Create(products, tableName));

            //2.yol
            // return View((products, tableName));

            var productListViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return View(new IndexPageViewModel() { Products = productListViewModel, TableName = tableName });

        }

        [HttpGet]
        public IActionResult Create()

        {
            var categoryList = _productRepository.GetCategories();

            ViewBag.selectList = new SelectList(categoryList, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel request)

        {
            if (!ModelState.IsValid)
            {
                var categoryList = _productRepository.GetCategories();

                ViewBag.selectList = new SelectList(categoryList, "Id", "Name");

                return View(request);
            }

            var newProduct = _mapper.Map<Product>(request);

            _productRepository.Create(newProduct);
            return RedirectToAction(nameof(HomeController.Index));
        }

        public IActionResult Update(int id)
        {
            var categoryList = _productRepository.GetCategories();

            ViewBag.selectList = new SelectList(categoryList, "Id", "Name");

            var productUpdateViewModel = _mapper.Map<ProductUpdateViewModel>(_productRepository.GetById(id));

            return View(productUpdateViewModel);
        }

        [HttpPost]
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Update(ProductUpdateViewModel request)
        {

            if (!ModelState.IsValid)
            {
                var categoryList = _productRepository.GetCategories();

                ViewBag.selectList = new SelectList(categoryList, "Id", "Name");
                return View();
            }

            _productRepository.Update(_mapper.Map<Product>(request));

            return RedirectToAction(nameof(HomeController.Index));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction(nameof(HomeController.Index));
        }

        public IActionResult AnyProductName(string Name)
        {
            var anyProduct = _productRepository.Any(x => x.Name.ToLower() == Name.ToLower());

            if (anyProduct)
            {
                return Json("Ürün ismi veritabanında bulunmaktadır.");
            }
            return Json(true);
        }
        public IActionResult AnyProductNameWithUpdate(string Name, int Id)
        {
            var anyProduct = _productRepository.Any(x => x.Name.ToLower() == Name.ToLower() && x.Id != Id);

            if (anyProduct)
            {
                return Json("Ürün ismi veritabanında bulunmaktadır.");
            }
            return Json(true);
        }

        public IActionResult DoSomething(int page, int pageSize)
        {
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;

            return View();
        }
    }
}