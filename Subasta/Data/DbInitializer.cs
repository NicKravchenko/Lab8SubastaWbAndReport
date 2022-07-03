using Subasta.Models;

namespace Subasta.Data
{
    public class DbInitializer
    {

        public static void Initialize(SubastaContext context)
        {
            // Look for any students.
            if (!context.Item.Any())
            {
                var Items = new Item[]
                {
                    new Item{ItemNombre = "Ford Mustang 2022", PrecioInicial = 45000, FechaPuesto = DateTime.Now} ,
                    new Item{ItemNombre = "Chevy Corvett 1970", PrecioInicial = 20000, FechaPuesto = DateTime.Now}  ,
                    new Item{ItemNombre = "Dodge Challenger 1980", PrecioInicial = 30000, FechaPuesto = DateTime.Now} ,
                    new Item{ItemNombre = "Honda NSX", PrecioInicial = 50000}
                };

                context.Item.AddRange(Items);
                context.SaveChanges();
            }

            if (!context.Puja.Any())
            {                
                var Pujas = new Puja[]{
                new Puja{ItemID = 1, Cedula = "402411", NombreCompleto = "Nik Kravch", PujaMonto = 50000, FechaPuesto = DateTime.Now} ,
                new Puja{ItemID = 1, Cedula = "402444", NombreCompleto = "Stev Mart", PujaMonto = 55000, FechaPuesto = DateTime.Now},
                new Puja{ItemID = 2, Cedula = "111411", NombreCompleto = "Oli Infante", PujaMonto = 60000, FechaPuesto = DateTime.Now}
                };

                context.Puja.AddRange(Pujas);
                context.SaveChanges();
            }

            return;

        }

    }
}
