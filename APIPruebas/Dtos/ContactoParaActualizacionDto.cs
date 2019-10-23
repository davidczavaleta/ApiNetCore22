using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIPruebas.Dtos
{
    public class ContactoParaActualizacionDto
    {
        [Required]
        [MaxLength(60, ErrorMessage = "El nombre del contacto revasa el limite de 60 caracteres.")]
        public string Nombre { get; set; }
        [MaxLength(30, ErrorMessage = "El nombre del puesto es superior a 30 caracteres")]
        public string Puesto { get; set; }
        [MaxLength(30, ErrorMessage = "El correo es muy superior a 30 caracteres")]
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Observaciones { get; set; }
    }
}
