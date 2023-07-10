using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IEmpleadosServices
    {
        public Task<Response<List<Empleado>>> ObtenerEmpleados();
        public Task<Response<List<Empleado>>> ObtenerEmpleadoId(int id);
        public Task<Response<Empleado>> CrearEmpleado(EmpleadoResponse Request);
        public Task<Response<Empleado>> BorrarEmpleado(int id);
        public Task<Response<Empleado>> EditarEmpleado([FromBody] EmpleadoResponse i, int id);
        public Task<Response<List<Empleado>>> EmpleMulti();
    }
}
