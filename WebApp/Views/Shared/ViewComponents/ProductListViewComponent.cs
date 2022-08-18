using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;
using WebApp.Repositories;

namespace WebApp.Views.Shared.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductListViewComponent(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int type)

        {

            var products = _mapper.Map<List<ProductViewModel>>(_repository.GetAll());


            if (type == 0)
            {
                return await Task.FromResult(View("UrunListeleme", products));
            }
            else
            {
                return await Task.FromResult(View("Default", products));
            }


        }

    }
}