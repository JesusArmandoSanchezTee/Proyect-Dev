using Microsoft.AspNetCore.Mvc;
using Domain.Dto;
using Domain.Entities;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;
        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerClientes()
        {
            return Ok(await _clienteServices.Obtenerclientes());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerClienteId(int id)
        {
            return Ok(await _clienteServices.ObtenerClienteId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody]ClienteResponse clienteResponse)
        {
            return Ok(await _clienteServices.CrearCliente(clienteResponse));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarCliente(int id)
        {
            return Ok(await _clienteServices.BorrarCliente(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarCliente([FromBody]ClienteResponse i, int id)
        {
            return Ok(await _clienteServices.Editarcliente(i, id));
        }
    }
}
