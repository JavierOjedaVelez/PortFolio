using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Data;
using Restaurante.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Dtos.Roles;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RolesController : Controller
    {

        private readonly AppDBContextcs _context;

        public RolesController(AppDBContextcs context)
        {
            _context = context;
        }


        //GET: /roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolesResponseDto>>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();

            var response = roles.Select(r => new RolesResponseDto
            {
                IdRol = r.IdRol,
                nombre = r.nombre
            }).ToList();

            return Ok(response);
        }


        //GET: roles/23
        [HttpGet("{iIdRol}")]
        public async Task<ActionResult<RolesResponseDto>> GetRol(int iIdRol)
        {
            var rol = await _context.Roles.FirstOrDefaultAsync(u => u.IdRol == iIdRol);

            if (rol == null)
                return NotFound();

            var response = new RolesResponseDto
            {
                IdRol = rol.IdRol,
                nombre = rol.nombre,

            };

            return Ok(response);
        }

        //POST: /roles
        [HttpPost]
        public async Task<ActionResult<RolCreateDto>> CreateRol([FromBody] RolCreateDto dto)
        {

            var rol = new Roles
            {
                nombre = dto.nombre
            };
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();

            var response = new RolesResponseDto
            {
                IdRol = rol.IdRol,
                nombre = rol.nombre
            };
            return CreatedAtAction(nameof(GetRol), new { iIdRol = rol.IdRol }, response);
        }



        //PUT: /roles/23
        [HttpPut("{iIdRol}")]
        public async Task<IActionResult> UpdateRol(int iIdRol, [FromBody] RolUpdateDto dto)
        {
            var rol = await _context.Roles.FindAsync(iIdRol);
            if (rol == null)
                return NotFound();

            // Actualizar solo los campos permitidos
            rol.nombre = dto.nombre;


            _context.Entry(rol).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //DELETE /roles/23
        [HttpDelete("{iIdRol}")]
        public async Task<IActionResult> DeleteRol(int iIdRol)
        {
            var rol = await _context.Roles.FindAsync(iIdRol);

            if (rol == null)
                return NotFound();

            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
