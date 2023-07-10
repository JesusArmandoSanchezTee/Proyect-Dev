using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class RolServices:IRolServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }
        //Creacion de funciones Crud
        public async Task<Response<List<Rol>>> ObtenerRoles()
        {
            try
            {
                //Mensaje = "La lista de roles";
                var response = await _context.Rols.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Rol>>(response, Mensaje);

                }
                else
                {
                    //Mensaje = "No se encontro ningún registro";
                    return new Response<List<Rol>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<List<Rol>>> ObtenerRolId(int id)
        {
            try
            {
                var response = await _context.Rols.FindAsync(id);
                if (response != null)
                {
                    return new Response<List<Rol>>(new List<Rol> { response }, Mensaje);
                }
                return new Response<List<Rol>>(Mensaje);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Rol>> CrearRol(RolResponse Request)
        {
            try
            {
                Mensaje = "Rol ha sido creado exitosamente";
                Rol rol = new Rol()
                {
                    Nombre = Request.nombre
                };
                _context.Rols.Add(rol);
                await _context.SaveChangesAsync();
                return new Response<Rol>(rol, Mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Rol>> BorrarRol(int id)
        {
            try
            {
                Mensaje = "El rol ha sido borrado";
                var res = _context.Rols.Find(id);
                Rol rol = new Rol();
                var funcion = _context.Rols.FirstOrDefault(x => x.PkRol == id);
                if (funcion != null)
                {
                    _context.Rols.Remove(res);
                    await _context.SaveChangesAsync();
                    return new Response<Rol>(res, Mensaje);
                }
                else
                {
                    Mensaje = "Ha habido un error al momento de borrar el rol";
                    return new Response<Rol>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Rol>> EditarRol([FromBody] RolResponse i, int id)
        {
            try
            {
              
                Rol rol = new Rol();
                var res = _context.Rols.Find(id);
                if (res != null)
                {
                    res.Nombre = i.nombre;

                    _context.Entry(res).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new Response<Rol>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }
    }
}
