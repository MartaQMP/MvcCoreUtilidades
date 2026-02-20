using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;
using System.ComponentModel.Design;

namespace MvcCoreUtilidades.Controllers
{
    public class UploadFilesController : Controller
    {
        private HelperPathProvider helperPath; 

        public UploadFilesController(HelperPathProvider helperPath)
        {
            this.helperPath = helperPath;
        }

        public IActionResult SubirFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirFile(IFormFile fichero)
        {
            string fileName = fichero.FileName;
            string path = this.helperPath.MapPath(fileName, Folders.Uploads);
            string pathUrl = this.helperPath.MapUrlPath(fileName, Folders.Uploads);
            // PARA SUBIR FICHEROS UTILIZAMOS Stream
            using(Stream stream = new FileStream(path, FileMode.Create))
            {
                await fichero.CopyToAsync(stream);
            }
            ViewBag.Mensaje = "Fichero subido a: " + path;
            ViewBag.FileName = fileName;
            ViewBag.PathUrl = pathUrl;
            return View();
        }
    }
}
