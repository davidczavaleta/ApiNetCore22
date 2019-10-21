using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPruebas.Data;
using APIPruebas.Dtos;
using APIPruebas.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPruebas.Controllers
{
    /// <summary>
    /// Esto se conoce como EndPoint y es un controlador que apunta a tu recurso e implementa 
    /// todos los metodos http para -> GET, POST, PUT, DELETE 
    /// Equivale al famoso CRUD de base de datos.
    /// </summary>
    [Route("api/sucursales")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly ContextoDb _db;

        public SucursalesController(ContextoDb db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<SucursalDto>> ObtenSucursales()
        {
            var sucursalesDtos = new List<SucursalDto>(); 
            var sucursalesEntidades =  _db.Sucursales.ToList(); 

            foreach (var sucursalEntidad in sucursalesEntidades)
            {
                var sucursalDto = new SucursalDto
                {
                    Id = sucursalEntidad.Id,
                    Nombre = sucursalEntidad.Nombre
                };

                sucursalesDtos.Add(sucursalDto);
            }

            return sucursalesDtos; 
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<SucursalDto> ObtenSucursal(Guid id)
        {
            var sucursalEntidad = _db.Sucursales.Find(id);

            if (sucursalEntidad == null)
                return NotFound();

            var sucursalDto = new SucursalDto();
            sucursalDto.Id = sucursalEntidad.Id;
            sucursalDto.Nombre = sucursalEntidad.Nombre; 

            return sucursalDto;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public ActionResult CreaSucursal([FromBody] SucursalParaCreacionDto sucursalParaCrear)
        {
            if (sucursalParaCrear == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var sucursalCreada = new Sucursal();
            sucursalCreada.Nombre = sucursalParaCrear.Nombre;
            sucursalCreada.Numero = sucursalParaCrear.Numero;

            _db.Sucursales.Add(sucursalCreada);

            if (_db.SaveChanges() <= 0)
                return StatusCode(500, "Ocurrió un error en el servidor, intente despues");

            var sucursalDto = new SucursalDto();
            sucursalDto.Id = sucursalCreada.Id;
            sucursalDto.Nombre = sucursalCreada.Nombre; 

            return CreatedAtAction(nameof(ObtenSucursal), new { id = sucursalCreada.Id }, sucursalDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(204)]
        public ActionResult ActualizaSucursal(Guid id,  [FromBody] SucursalParaActualizacionDto sucursalParaActualizar)
        {
            if (sucursalParaActualizar == null || !ModelState.IsValid)
                return BadRequest(); 

            var sucursalEntidad = _db.Sucursales.Find(id);

            if (sucursalEntidad == null)
                return NotFound();

            sucursalEntidad.Nombre = sucursalParaActualizar.Nombre;

            if (_db.SaveChanges() <= 0)
                return StatusCode(500, "Ocurrió un error en el servidor");

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(204)]
        public ActionResult EliminaSucursal(Guid id)
        {
            var sucursalEntidad = _db.Sucursales.Find(id);

            if (sucursalEntidad == null)
                return NotFound();

            _db.Sucursales.Remove(sucursalEntidad);

            if (_db.SaveChanges() <= 0)
                return StatusCode(500, "Error en el servidor");

            return NoContent();             
        }
    }
}