using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace WebApp.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileProvider _fileProvider;

        public FileController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public IActionResult PhotoSave()
        {


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {


                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var picturesDirectory = root.Single(x => x.Name == "pictures");

                // var path2== "D:\\ITalentBootcamp\\WebApp\\wwwroot\\pictures" + "ahmet.jpg";

                var path = Path.Combine(picturesDirectory.PhysicalPath, photo.FileName);


                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream);

            }

            return View();

        }
    }
}