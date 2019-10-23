using APIPruebas.Data;
using APIPruebas.Dtos;
using APIPruebas.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPruebas.Controllers
{
    [Route("api/Contactos")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly ContextoDb _db;
        public ContactosController(ContextoDb db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<ContactoDto>> ObtenContactos()
        {
            var contactosDtos = new List<ContactoDto>();
            var contactosEntidades = _db.Contactos.ToList();

            foreach (var contactoEntidad in contactosEntidades)
            {
                var contactoDto = new ContactoDto
                {
                    Id = contactoEntidad.Id,
                    Nombre = contactoEntidad.Nombre,
                    Puesto = contactoEntidad.Puesto,
                    Correo = contactoEntidad.Correo,
                    Celular = contactoEntidad.Celular,
                    Telefono1 = contactoEntidad.Telefono1,
                    Observaciones = contactoEntidad.Observaciones
                };

                contactosDtos.Add(contactoDto);
            }
            return contactosDtos;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<ContactoDto> ObtenContacto(int id)
        {
            var contactoEntidad = _db.Contactos.Find(id);

            if (contactoEntidad == null)
                return NotFound();

            var contactoDto = new ContactoDto();
            contactoDto.Id = contactoEntidad.Id;
            contactoDto.Nombre = contactoEntidad.Nombre;
            contactoDto.Puesto = contactoEntidad.Puesto;
            contactoDto.Celular = contactoEntidad.Celular;
            contactoDto.Telefono1 = contactoEntidad.Telefono1;
            contactoDto.Observaciones = contactoEntidad.Observaciones;

            return contactoDto;
        }
        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public ActionResult CreaContacto([FromBody] ContactoParaCreacion contactoParaCrear)
        {
            //Validaciones Defencivas
            if (contactoParaCrear == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            //Creacionn del objeto a guardar
            var contactoCreado = new Contacto();
            contactoCreado.Nombre = contactoParaCrear.Nombre;
            contactoCreado.Puesto = contactoParaCrear.Puesto;
            contactoCreado.Celular = contactoParaCrear.Celular;
            contactoCreado.Telefono1 = contactoParaCrear.Telefono1;
            contactoCreado.Telefono2 = contactoParaCrear.Telefono2;
            contactoCreado.Observaciones = contactoParaCrear.Observaciones;

            //Agrega el nuevo contacto a la tabla Contactos
            _db.Contactos.Add(contactoCreado);

            //Guuarda cambios
            if (_db.SaveChanges() <= 0)
                return StatusCode(500,"Ocurrio un error durante el guardado");

            //Se crea un nuevo objeto de Tipo ContactoDTo del contacto Creado
            var contactoDto = new ContactoDto();
            contactoDto.Id = contactoCreado.Id;
            contactoDto.Nombre = contactoCreado.Nombre;
            contactoDto.Puesto = contactoCreado.Puesto;
            contactoDto.Celular = contactoCreado.Celular;
            contactoDto.Telefono1 = contactoCreado.Telefono1;
            contactoDto.Telefono2 = contactoCreado.Telefono2;
            contactoDto.Observaciones = contactoCreado.Observaciones;
               

            return CreatedAtAction(nameof(ObtenContacto), new { id = contactoCreado.Id }, contactoDto);
        }
    }
}
