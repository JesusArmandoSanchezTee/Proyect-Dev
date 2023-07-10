using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadosServices _empleadosServices;
        public EmpleadoController(IEmpleadosServices empleadosServices)
        {
            _empleadosServices = empleadosServices;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerEmpleados()
        {
            return Ok(await _empleadosServices.ObtenerEmpleados());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerEmpleadoId(int id)
        {
            return Ok(await _empleadosServices.ObtenerEmpleadoId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearEmpleado([FromBody]EmpleadoResponse empleadoResponse)
        {
            return Ok(await _empleadosServices.CrearEmpleado(empleadoResponse));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarEmpleado(int id)
        {
            return Ok(await _empleadosServices.BorrarEmpleado(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarEmpleado([FromBody] EmpleadoResponse i, int id)
        {
            return Ok(await _empleadosServices.EditarEmpleado(i, id));
        }
        [HttpGet("Multi")]
        public async Task<IActionResult> EmpleMulti()
        {
            return Ok(await _empleadosServices.EmpleMulti());

        }
    }
}
