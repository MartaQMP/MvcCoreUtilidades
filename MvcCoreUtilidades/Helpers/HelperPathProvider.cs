using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace MvcCoreUtilidades.Helpers
{
    // ENUM CON LAS CARPETAS QUE DESEAMOS SUBIR
    public enum Folders { Uploads, Images, Facturas, Cobros}

    public class HelperPathProvider
    {
        private IWebHostEnvironment webHostEnvironment;
        private IServer server;

        public HelperPathProvider(IWebHostEnvironment webHostEnvironment, IServer server)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.server = server;
        }

        // TENDEREMOS UN METODO QUE SE ENCARGA DE RESOLVER LA RUTA 
        // COMO STRING CUANDO RECIBAMOS EL FICHERO Y LA CARPETA
        public string MapPath(string fileName, Folders folder)
        {
            /* CUANDO PENSAMOS EN FICHEROS Y SUS RUTAS ESTAMOS PENSANDO EN ALGO PARECIDO A ESTO:
             * C:/misFicheros/carpeta/1.txt
             * NET CORE NO ES DE WINDOWS Y ESTA RUTA ES DE WINDOWS
             * LAS RUTAS DE LINUX PUEDEN SER DISTINTAS Y MACOS
             * DEBEMOS CREAR RUTAS CON HERRAMIENTAS DE NET CORE: Path */
            string carpeta = "";
            if(folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if(folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            else if(folder == Folders.Facturas)
            {
                carpeta = "facturas";
            }
            else if(folder == Folders.Cobros)
            {
                carpeta = Path.Combine("facturas", "cobros");
            }
                string rootPath = this.webHostEnvironment.WebRootPath;
            string path = Path.Combine(rootPath, carpeta, fileName);
            return path;
        }

        public string MapUrlPath(string fileName, Folders folder)
        {
            string carpeta = "";
            if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            else if (folder == Folders.Facturas)
            {
                carpeta = "facturas";
            }
            else if (folder == Folders.Cobros)
            {
                carpeta = "facturas/cobros";
            }
            var address = this.server.Features.Get<IServerAddressesFeature>().Addresses;
            string serverUrl = address.FirstOrDefault();
            return serverUrl + "/" + carpeta + "/" + fileName;
        }
    }
}
