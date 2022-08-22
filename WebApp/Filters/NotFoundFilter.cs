using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductRepository _repository;

        public NotFoundFilter(IProductRepository repository)
        {
            _repository = repository;
        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                return;
            }

            var id = Convert.ToInt32(idValue);
            var hasProduct = _repository.Any(x => x.Id == id);

            if (hasProduct == false)
            {
                context.Result = new RedirectToActionResult("Error", "Home", new ErrorViewModel() { Message = "Ürün bulunamadı" });
            }
        }
    }
}
