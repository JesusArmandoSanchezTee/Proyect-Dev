using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [EnableCors("EnableCore")]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuariosController(IUsuarioServices usuarioServices)
        {
            _usuarioServices= usuarioServices;
        }
        [HttpGet]   
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _usuarioServices.GetUsers());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuarioId(int id)
        {
            return Ok( await _usuarioServices.ObtenerUsuarioId(id));
        }
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody]UsuarioResponse i) 
        {
            return Ok(await _usuarioServices.CrearUsuario(i));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Borrar(int id)
        {
            return Ok(await _usuarioServices.BorrarUsuario(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar([FromBody]UsuarioResponse i, int id)
        {
            return Ok(await _usuarioServices.EditarUsuario(i, id));
        }

        [HttpGet("Multi")]
        public async Task<IActionResult> UsuarioMulti()
        {
            return Ok(await _usuarioServices.UsuarioMulti());
        }
    }
}
