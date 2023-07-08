using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Examen2.Models
{
    public class TelefonoModelo
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Marca")]
        [DisplayName("Nombre de la marca del telefono: ")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Modelo")]
        [DisplayName("Modelo del telefono: ")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Color")]
        [DisplayName("Color del telefono: ")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Debe ingresar numero de Cores")]
        [DisplayName("Cores: ")]
        public int Cores { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un valor para Android")]
        [DisplayName("Android (ingrese true o false): ")]
        public bool Android { get; set; }
    }
}
