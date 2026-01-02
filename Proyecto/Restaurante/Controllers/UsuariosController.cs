using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Models;
using Restaurante.Dtos.Usuarios;
using Restaurante.Helpers;


namespace Restaurante.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class UsuariosController : Controller
    {
        private readonly AppDBContextcs _context;

        public UsuariosController(AppDBContextcs context)
        {
            _context = context;
        }

        //GET: /Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuariosResponseDto>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Rol) // Incluye la relación de Rol
                .ToListAsync();

            var response = usuarios.Select(u => new UsuariosResponseDto
            {
                IdUsuario = u.IdUsuario,
                Nombre = u.Nombre,
                Apellidos = u.Apellidos,
                Email = u.Email,
                Telefono = u.Telefono,
                Rol = u.Rol.nombre, // Nombre del rol
                FechaRegistro = u.FechaRegistro
            }).ToList();

            return Ok(response);
        }
            //GET: /Usuarios/23
            [HttpGet("{iIdUsuario}")]
        public async Task<ActionResult<UsuariosResponseDto>> GetUsuario(int iIdUsuario)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Rol) // Incluye la relación de Rol
                .FirstOrDefaultAsync(u => u.IdUsuario == iIdUsuario);

            if (usuario == null)
                return NotFound();

            var response = new UsuariosResponseDto
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Rol = usuario.Rol.nombre,
                FechaRegistro = usuario.FechaRegistro
            };

            return Ok(response);
        }

        //POST: /Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuariosResponseDto>> CreateUsuario([FromBody] UsuarioCreateDto dto)
        {

            var usuario = new Usuarios
            {
                Nombre = dto.Nombre,
                Apellidos = dto.Apellidos,
                Email = dto.Email,
                Telefono = dto.Telefono,
                PasswordHash = PasswordHelper.HashPassword(dto.Password), 
                IdRol = dto.IdRol
                
            };

            
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var response = new UsuariosResponseDto
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Rol = (await _context.Roles.FindAsync(usuario.IdRol))?.nombre ?? "",
                FechaRegistro = usuario.FechaRegistro
            };

            return CreatedAtAction(nameof(GetUsuario), new { iIdUsuario = usuario.IdUsuario }, response);
        }

        //PUT: /Usuarios/23
        [HttpPut("{iIdUsuario}")]
        public async Task<IActionResult> UpdateUsuario(int iIdUsuario, [FromBody] UsuarioUpdateDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(iIdUsuario);
            if (usuario == null)
                return NotFound();

            // Actualizar solo los campos permitidos
            usuario.Nombre = dto.Nombre;
            usuario.Apellidos = dto.Apellidos;
            usuario.Email = dto.Email;
            usuario.Telefono = dto.Telefono;
            usuario.IdRol = dto.IdRol;

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: /Usuarios
        [HttpDelete("{iIdUsuario}")]
        public async Task<IActionResult> DeleteUsuario(int iIdUsuario)
        {
            var usuario = await _context.Usuarios.FindAsync(iIdUsuario);

            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
