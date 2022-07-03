using System.ComponentModel;

namespace Subasta.Models
{
    public class Item
    {
        public int ID { get; set; }

        [DisplayName("Nombre")]
        public string ItemNombre { get; set; }

        [DisplayName("Precio Inicial")]
        public float PrecioInicial { get; set; }

        [DisplayName("Fecha de creacion")]
        public DateTime FechaPuesto { get; set; }


        public ICollection<Puja> Puja { get; set; }
    }
}
