using Microsoft.AspNetCore.Mvc;
using Domain.Dto;
using Domain.Entities;
using Proyecto25AM.Services.IServices;
namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoServices _departamentoServices;
        public DepartamentoController(IDepartamentoServices departamentoServices)
        {
            _departamentoServices = departamentoServices;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerDepartamentos()
        {
            return Ok(await _departamentoServices.ObtenerDepartamentos());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerDepartamentoId(int id)
        {
            return Ok(await _departamentoServices.ObtenerDepartamentoId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearDepartamento([FromBody]DepartamentoResponse departamentoResponse)
        {
            return Ok(await _departamentoServices.CrearDepartamento(departamentoResponse));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarDepartamento(int id)
        {
            return Ok(await _departamentoServices.BorrarDepartamento(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarDepartamento([FromBody]DepartamentoResponse i, int id)
        {
            return Ok(await _departamentoServices.EditarDepartamento(i, id));
        }
    }
}
