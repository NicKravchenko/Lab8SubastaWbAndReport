using System.ComponentModel;

namespace Subasta.Models
{
    public class Puja
    {
        public int ID { get; set; }
        public int ItemID { get; set; }

        [DisplayName("Nombre completo")]
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }

        [DisplayName("Monto de puja")]
        public float PujaMonto { get; set; }

        [DisplayName("Fecha de puja")]
        public DateTime FechaPuesto { get; set; }

        public Item Item { get; set; }
    }
}
