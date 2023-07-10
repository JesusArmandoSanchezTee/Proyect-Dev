using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaServices _facturaServices;
        public FacturaController(IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerFacturas()
        {
            return Ok(await _facturaServices.ObtenerFacturas());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerFacturaId(int id)
        {
            return Ok(await _facturaServices.ObtenerFacturaId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearFactura([FromBody] FacturaResponse facturaResponse)
        {
            return Ok(await _facturaServices.CrearFactura(facturaResponse));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarFactura(int id)
        {
            return Ok(await _facturaServices.BorrarFactura(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarFactura([FromBody] FacturaResponse i, int id)
        {
            return Ok(await _facturaServices.EditarFactura(i, id));
        }
    }
}
