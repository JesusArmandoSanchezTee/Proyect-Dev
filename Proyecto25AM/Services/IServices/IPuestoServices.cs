using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IPuestoServices
    {
        public Task<Response<List<Puesto>>> ObtenerPuesto();
        public Task<Response<List<Puesto>>> ObtenerPuestoId(int id);
        public Task<Response<Puesto>> CrearPuesto(PuestoResponse Request);
        public Task<Response<Puesto>> BorrarPuesto(int id);
        public Task<Response<Puesto>> EditarPuesto([FromBody] PuestoResponse i, int id);
    }
}
