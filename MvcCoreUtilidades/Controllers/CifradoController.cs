using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;

namespace MvcCoreUtilidades.Controllers
{
    public class CifradoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CifradoBasico()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CifradoBasico(string contenido, string resultado, string accion)
        {
            // CIFRAMOS EL CONTENIDO
            string response = HelperCryptography.EncriptarTextoBasico(contenido);
            if(accion.ToLower() == "cifrar")
            {
                ViewBag.TextoCifrado = response;
            }
            else if(accion.ToLower() == "comparar")
            {
                // SI EL USUARIO QUIERE COMPARAR NOS ESTARA ENVIANDO EL TEXTO A COMPARAR EN resultado
                if(response != resultado)
                {
                    ViewBag.Mensaje = "Los datos no coinciden";
                }else
                {
                    ViewBag.Mensaje = "Todo correcto";
                }
            }
                return View();
        }


        public IActionResult CifradoEficiente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CifradoEficiente(string contenido, string resultado, string accion)
        {
            if(accion.ToLower() == "cifrar")
            {
                string response = HelperCryptography.CifrarContenido(contenido, false);
                ViewBag.TextoCifrado = response;
                ViewBag.Salt = HelperCryptography.Salt;
            }
            else if(accion.ToLower() == "comparar")
            {
                string response = HelperCryptography.CifrarContenido(contenido, true);
                if (response != resultado)
                {
                    ViewBag.Mensaje = "Los datos no coinciden";
                }else
                {
                    ViewBag.Mensaje = "Todo correcto";
                }
            }
                return View();
        }
    }
}
