using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Models;
using MvcCoreUtilidades.Repositories;

namespace MvcCoreUtilidades.Controllers
{
    public class CochesController : Controller
    {
        private RepositoryCoches repo;

        public CochesController(RepositoryCoches repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _CochesPartial()
        {
            /* DEBEMOS DEVOLVER UN DIBUJO QUE DESEEMOS EN AJAX
             * INDICAMOS EL NOMBRE DEL FICHERO CSHTML Y SU MODEL */
            return PartialView("_CochesPartial", this.repo.GetCoches);
        }

        public IActionResult _CochesDetalles(int idcoche)
        {
            Coche car = this.repo.FindCoche(idcoche);
            return PartialView("_CochesDetalles", car);
        }

        public IActionResult Details(int idCoche)
        {
            Coche car = this.repo.FindCoche(idCoche);
            return View(car);
        }
    }
}
