using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuestoController : ControllerBase
    {
        private readonly IPuestoServices _puestoServices;
        public PuestoController(IPuestoServices puestoServices)
        {
            _puestoServices = puestoServices;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerPuesto()
        {
            return Ok(await _puestoServices.ObtenerPuesto());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPuestoId(int id)
        {
            return Ok(await _puestoServices.ObtenerPuestoId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearPuesto([FromBody]PuestoResponse request)
        {
            return Ok(await _puestoServices.CrearPuesto(request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarPuesto(int id)
        {
            return Ok(await _puestoServices.BorrarPuesto(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarPuesto([FromBody]PuestoResponse i, int id)
        {
            return Ok(await _puestoServices.EditarPuesto(i, id));
        }
    }
}
