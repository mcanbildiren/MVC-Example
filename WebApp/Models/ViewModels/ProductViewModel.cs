namespace WebApp.Models.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Color { get; set; }
        public bool IsPublish { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}