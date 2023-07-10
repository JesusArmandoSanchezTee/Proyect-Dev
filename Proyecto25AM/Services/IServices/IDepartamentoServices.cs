using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IDepartamentoServices
    {
        public Task<Response<List<Departamento>>> ObtenerDepartamentos();
        public Task<Response<List<Departamento>>> ObtenerDepartamentoId(int id);
        public Task<Response<Departamento>> CrearDepartamento(DepartamentoResponse Request);
        public Task<Response<Departamento>> BorrarDepartamento(int id);
        public Task<Response<Departamento>> EditarDepartamento([FromBody] DepartamentoResponse i, int id);
    }
}
