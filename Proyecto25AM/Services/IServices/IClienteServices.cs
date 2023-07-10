using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IClienteServices
    {
        public Task<Response<List<Cliente>>> Obtenerclientes();
        public Task<Response<List<Cliente>>> ObtenerClienteId(int id);
        public Task<Response<Cliente>> CrearCliente(ClienteResponse Request);
        public Task<Response<Cliente>> BorrarCliente(int id);
        public Task<Response<Cliente>> Editarcliente([FromBody] ClienteResponse i, int id);
    }
}
