using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MvcCoreUtilidades.Controllers
{
    public class CachingController : Controller
    {
        private IMemoryCache memoryCache;

        public CachingController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 20, Location = ResponseCacheLocation.Client)]
        public IActionResult MemoriaDistribuida()
        {
            string fecha = DateTime.Now.ToLongDateString() + "--" + DateTime.Now.ToLongTimeString();
            ViewBag.Fecha = fecha;
            return View();
        }

        public IActionResult MemoriaPersonalizada(int? tiempo)
        {
            if (tiempo == null)
            {
                tiempo = 60;
            }
            string fecha = DateTime.Now.ToLongDateString() + "--" + DateTime.Now.ToLongTimeString();
            // COMO ESTO ES MANUAL DEBEMOS PREGUNTAR SI EXISTE ALGO EN CACHE O NO
            if(this.memoryCache.Get("FECHA") == null)
            {
                // NO EXISTE CACHE TODAVIA
                //CREAMOS EL OBJETO 
                MemoryCacheEntryOptions options = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(tiempo.Value));
                this.memoryCache.Set("FECHA", fecha, options);
                ViewBag.Mensaje = "Fecha almacenada";
                ViewBag.Fecha = this.memoryCache.Get("FECHA");
            }else
            {
                fecha = this.memoryCache.Get<string>("FECHA");
                ViewBag.Mensaje = "Fecha recuperada";
                ViewBag.Fecha = fecha;
            }
                return View();
        }
    }
}
