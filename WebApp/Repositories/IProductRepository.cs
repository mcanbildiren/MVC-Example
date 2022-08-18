using System.Linq.Expressions;
using WebApp.Models;

namespace WebApp.Repositories
{
    public interface IProductRepository
    {

        List<Product> GetAll();

        Product Create(Product product);

        void Update(Product product);

        Product GetById(int id);

        void Delete(int id);

        bool Any(Expression<Func<Product, bool>> predicate);

        List<Category> GetCategories();

    }
}
