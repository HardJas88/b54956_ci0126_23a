using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace laboratorio6.Models
{
    public class PeliculaModelo
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [DisplayName("Nombre de la pelicula: ")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar un anno")]
        [DisplayName("Anno: ")]
        [RegularExpression("^(18|19|20)[0-9]{2}$", ErrorMessage ="Ingrese un anno valido")]
        public int Año{ get; set; }
    }
}
