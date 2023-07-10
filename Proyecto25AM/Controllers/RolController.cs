using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolServices _rolServices;
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerRol()
        {
            return Ok(await _rolServices.ObtenerRoles());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerRolId(int id)
        {
            return Ok(await _rolServices.ObtenerRolId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearRol([FromBody]RolResponse request)
        {
            return Ok(await _rolServices.CrearRol(request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarRol(int id)
        {
            return Ok(await _rolServices.BorrarRol(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarRol([FromBody]RolResponse i, int id)
        {
            return Ok(await _rolServices.EditarRol(i, id));
        }
    }
}
