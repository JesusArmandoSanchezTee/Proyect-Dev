using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IRolServices
    {
        public Task<Response<List<Rol>>> ObtenerRoles();
        public Task<Response<List<Rol>>> ObtenerRolId(int id);
        public Task<Response<Rol>> CrearRol(RolResponse Request);
        public Task<Response<Rol>> BorrarRol(int id);
        public Task<Response<Rol>> EditarRol([FromBody] RolResponse i, int id);
    }
}
