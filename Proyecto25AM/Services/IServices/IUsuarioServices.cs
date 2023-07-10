using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> GetUsers();

        public Task<Response<Usuario>> CrearUsuario(UsuarioResponse Request);
        public Task<Response<Usuario>> BorrarUsuario(int id);
        public Task<Response<Usuario>> EditarUsuario([FromBody] UsuarioResponse i, int id);
        public Task<Response<List<Usuario>>> ObtenerUsuarioId(int id);
        public Task<Response<List<Usuario>>> UsuarioMulti();

    }
}
