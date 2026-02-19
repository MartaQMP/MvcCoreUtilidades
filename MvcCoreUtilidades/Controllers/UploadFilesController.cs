using Microsoft.AspNetCore.Mvc;

namespace MvcCoreUtilidades.Controllers
{
    public class UploadFilesController : Controller
    {
        private IWebHostEnvironment hostEnvironment;

        public UploadFilesController(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult SubirFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirFile(IFormFile fichero)
        {
            // NECESITAMOS LA RUTA HACIA LA CARPETA wwwroot
            string rootFoler = hostEnvironment.WebRootPath;
            string fileName = fichero.FileName;
            /* CUANDO PENSAMOS EN FICHEROS Y SUS RUTAS ESTAMOS PENSANDO EN ALGO PARECIDO A ESTO:
             * C:/misFicheros/carpeta/1.txt
             * NET CORE NO ES DE WINDOWS Y ESTARUTA ES DE WINDOWS
             * LAS RUTAS DE LINUX PUEDEN SER DISTINTAS Y MACOS
             * DEBEMOS CREAR RUTAS CON HERRAMIENTAS DE NET CORE: Path */
            string path = Path.Combine(rootFoler, "uploads", fileName);
            // PARA SUBIR FICHEROS UTILIZAMOS Stream
            using(Stream stream = new FileStream(path, FileMode.Create))
            {
                await fichero.CopyToAsync(stream);
            }
            ViewBag.Mensaje = "Fichero subido a: " + path;
            ViewBag.FileName = fileName;
            return View();
        }
    }
}
