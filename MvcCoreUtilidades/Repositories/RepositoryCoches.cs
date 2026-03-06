using MvcCoreUtilidades.Models;

namespace MvcCoreUtilidades.Repositories
{
    public class RepositoryCoches
    {
        private List<Coche> coches;

        public RepositoryCoches()
        {
            this.coches = new List<Coche>
            {
                new Coche { IdCoche = 1, Marca = "Pontiac", Modelo = "Firebird", Imagen = "https://cdn-images.motor.es/image/m/1320w/fotos-noticias/2017/10/pontiac-firebird-trans-am-1979-201740312_1.jpg"},
                new Coche { IdCoche = 2, Marca = "Volkswagen", Modelo = "Escarabajo", Imagen = "https://upload.wikimedia.org/wikipedia/commons/6/6f/2006_Volkswagen_New_Beetle_Luna_1.6_Front.jpg"},
                new Coche { IdCoche = 3, Marca = "Ferrari", Modelo = "Testarrosa", Imagen = "https://hips.hearstapps.com/hmg-prod/images/1987-ferrari-testarossa-monodado-6464c1cb84bba.png"},
                new Coche { IdCoche = 4, Marca = "Ford", Modelo = "Mustang GT", Imagen = "https://rentlux.es/wp-content/uploads/2023/04/alquilar-ford-mustang.jpg"}
            };
        }

        public List<Coche> GetCoches()
        {
            return this.coches;
        }

        public Coche FindCoche(int idCoche)
        {
            return this.coches.Find(c => c.IdCoche == idCoche);
        }
    }
}
