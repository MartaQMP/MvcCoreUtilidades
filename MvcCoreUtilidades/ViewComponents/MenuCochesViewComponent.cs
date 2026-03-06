using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Models;
using MvcCoreUtilidades.Repositories;

namespace MvcCoreUtilidades.ViewComponents
{
    public class MenuCochesViewComponent: ViewComponent
    {
        private RepositoryCoches repo;

        public MenuCochesViewComponent(RepositoryCoches repo)
        {
            this.repo = repo;
        }

        /* SI QUEREMOS TENER TODOS LOS METODOS QUE DESEEMOS PERO SI QUEREMOS DEVOLDER DATOS A LA VISTA
         * Y AL LAYOUT NECESITAMOS EL METODO InvokeAsync() */
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Coche> coches = this.repo.GetCoches();
            return View(coches);
        }
    }
}
