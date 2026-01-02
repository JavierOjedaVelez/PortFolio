using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Data;
using Restaurante.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Dtos.Restaurantes;
using Restaurante.Dtos.Roles;


namespace Restaurante.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RestaurantesController : Controller
    {
        private readonly AppDBContextcs _context;

        public RestaurantesController(AppDBContextcs context)
        {
            _context = context;
        }

        //GET: /restaurantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantesResponseDto>>> GetRestaurantes()
        {
            var restaurantes = await _context.Restaurantes.ToListAsync();

            var response = restaurantes.Select(r => new RestaurantesResponseDto
            {
                IdRestaurante = r.IdRestaurante,
                Nombre = r.Nombre,
                Direccion = r.Direccion,
                Telefono = r.Telefono,
                CapacidadTotal = r.CapacidadTotal,
            }).ToList();

            return Ok(response);
        }

        //GET: restaurantes/23
        [HttpGet("{iIdRestaurante}")]
        public async Task<ActionResult<RestaurantesResponseDto>> GetRestaurante(int iIdRestaurante)
        {
            var restaurante = await _context.Restaurantes.FirstOrDefaultAsync(u => u.IdRestaurante == iIdRestaurante);

            if (restaurante == null)
                return NotFound();

            var response = new RestaurantesResponseDto
            {
                IdRestaurante = restaurante.IdRestaurante,
                Nombre = restaurante.Nombre,
                Direccion = restaurante.Direccion,
                Telefono = restaurante.Telefono,
                CapacidadTotal = restaurante.CapacidadTotal,

            };

            return Ok(response);
        }

        //POST: /restaurantes
        [HttpPost]
        public async Task<ActionResult<RestauranteCreateDto>> CreateRestaurante([FromBody] RestauranteCreateDto dto)
        {

            var restaurantes = new Restaurantes
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                CapacidadTotal = dto.CapacidadTotal,
            };
            _context.Restaurantes.Add(restaurantes);
            await _context.SaveChangesAsync();

            var response = new RestaurantesResponseDto
            {
                IdRestaurante = restaurantes.IdRestaurante,
                Nombre = restaurantes.Nombre,
                Direccion = restaurantes.Direccion,
                Telefono = restaurantes.Telefono,
                CapacidadTotal = restaurantes.CapacidadTotal,
            };
            return CreatedAtAction(nameof(GetRestaurante), new { iIdRestaurante = restaurantes.IdRestaurante }, response);
        }



        //PUT: /restaurantes/23
        [HttpPut("{iIdRestaurante}")]
        public async Task<IActionResult> UpdateRestaurante(int iIdRestaurante, [FromBody] RestauranteUpdateDto dto)
        {
            var restaurante = await _context.Restaurantes.FindAsync(iIdRestaurante);
            if (restaurante == null)
                return NotFound();

            // Actualizar solo los campos permitidos
            restaurante.Nombre = dto.Nombre;
            restaurante.Direccion = dto.Direccion;
            restaurante.Telefono = dto.Telefono;
            restaurante.CapacidadTotal = dto.CapacidadTotal;


            _context.Entry(restaurante).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //DELETE /restaurantes/23
        [HttpDelete("{iIdRestaurante}")]
        public async Task<IActionResult> DeleteRestaurante(int iIdRestaurante)
        {
            var restaurante = await _context.Restaurantes.FindAsync(iIdRestaurante);

            if (restaurante == null)
                return NotFound();

            _context.Restaurantes.Remove(restaurante);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
