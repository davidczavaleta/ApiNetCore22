using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIPruebas.Dtos
{
    public class SucursalParaCreacionDto
    {        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Debes indicar un numero de sucursal valido")]
        public int Numero { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage ="El nombre no puede tener más de 15 caracteres")]
        public string Nombre { get; set; }
    }
}
