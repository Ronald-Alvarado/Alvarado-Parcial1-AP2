using System.ComponentModel.DataAnnotations;

namespace Alvarado_Parcial1_AP2.Models{

    public class Productos{

        [Key] public int ProductoId { get; set; }

        [Required(ErrorMessage = "Debe poner una Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe poner una Existencia")]
        public float Existencia { get; set; }

        [Required(ErrorMessage = "Debe poner un Costo")]
        public float Costo { get; set; }

        
        public float ValorInventario { get; set; }
    }
}