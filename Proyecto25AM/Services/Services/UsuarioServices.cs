using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class UsuarioServices:IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context; 
        }
        //Creacion de funciones Crud
        public async Task<Response<List<Usuario>>> GetUsers()
        {
            try
            {
                //Mensaje = "La lista de usuarios";
                var response = await _context.Usuarios.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Usuario>>(response, Mensaje);

                }
                else
                {
                    //Mensaje = "No se encontro ningún registro";
                    return new Response<List<Usuario>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: "+ ex.Message);
            }
        }
        public async Task<Response<List<Usuario>>> ObtenerUsuarioId(int id)
        {
            try
            {
                var response = await _context.Usuarios.FindAsync(id);
                if (response != null){
                    return new Response<List<Usuario>>(new List<Usuario> { response}, Mensaje);
                }
                return new Response<List<Usuario>>(Mensaje);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Usuario>> CrearUsuario(UsuarioResponse Request) 
        {
            try
            {
                Usuario user = new Usuario()
                {
                    
                    User = Request.User,
                    Password = Request.Password,
                    FechaRegistro = Request.FechaRegistro,
                    FkEmpleado = Request.FkEmpleado,
                    FkRol = Request.FkRol
                };
                 _context.Usuarios.Add(user);
                await _context.SaveChangesAsync();
                return new Response<Usuario>(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Usuario>> BorrarUsuario(int id)
        {
            try
            {
                var res = _context.Usuarios.Find(id);
                Usuario usuario = new Usuario();
                var funcion = _context.Usuarios.FirstOrDefault(x => x.PkUsuario == id);
                if (funcion != null)
                {
                    _context.Usuarios.Remove(res);
                    await _context.SaveChangesAsync();
                }
                return new Response<Usuario>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error"+ ex.Message);
            }
        }
        public async Task<Response<Usuario>> EditarUsuario([FromBody] UsuarioResponse i, int id)
        {
            try
            {
                Usuario usuario = new Usuario();
                var res = _context.Usuarios.Find(id);
                if( res != null)
                {
                    res.User = i.User;
                    res.Password = i.Password;
                    res.FechaRegistro = i.FechaRegistro;
                    res.FkRol = i.FkRol;
                    res.FkEmpleado = i.FkEmpleado;

                    _context.Entry(res).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                    return new Response<Usuario>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: "+ ex.Message);
            }
        }

        public async Task<Response<List<Usuario>>> UsuarioMulti()
        {
            Empleado en = new Empleado();
            Rol es = new Rol();
            var c = await _context.Usuarios.Include(z => z.Empleado).Include(z => z.Rol).ToListAsync();
            return new Response<List<Usuario>>(c);
        }
    }
}
