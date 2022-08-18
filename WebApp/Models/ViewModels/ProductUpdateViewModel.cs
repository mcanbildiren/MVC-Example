using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models.ViewModels
{
    public class ProductUpdateViewModel
    {

        public int Id { get; set; }

        [Remote(action: "AnyProductNameWithUpdate", controller: "Products", AdditionalFields = "Id")]
        [StringLength(20, ErrorMessage = "İsim alanı en fazla 20 karakter olabilir")]
        [Required(ErrorMessage = "İsim alanı boş olamaz")]
        public string? Name { get; set; }

        [Range(1, 100, ErrorMessage = "Fiyat 1 ile 100 arasında olmalıdır.")]
        [Required(ErrorMessage = "Fiyat alanı boş olamaz")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Renk alanı boş olamaz")]
        public string? Color { get; set; }

        public int CategoryId { get; set; }
    }
}
