using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Products.Include(x=>x.Category).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id)!;
        }

        public void Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        public bool Any(Expression<Func<Product, bool>> predicate)
        {
            return _context.Products.Any(predicate);
        }
        public (List<Product>, int) GetProductsWithPaged(int page, int pageSize)
        {

            var product = _context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalCount = _context.Products.Count();


            return (product, totalCount);


        }

    }
}
