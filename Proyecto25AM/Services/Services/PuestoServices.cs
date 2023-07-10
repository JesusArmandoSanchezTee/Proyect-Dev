using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class PuestoServices:IPuestoServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public PuestoServices(ApplicationDbContext context)
        {
            _context = context;
        }
        //Creacion de funciones Crud
        public async Task<Response<List<Puesto>>> ObtenerPuesto()
        {
            try
            {
                //Mensaje = "La lista de puestos";
                var response = await _context.Puestos.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Puesto>>(response, Mensaje);

                }
                else
                {
                    Mensaje = "No hay ningun registro";
                    return new Response<List<Puesto>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<List<Puesto>>> ObtenerPuestoId(int id)
        {
            try
            {
                var response = await _context.Puestos.FindAsync(id);
                if (response != null)
                {
                    return new Response<List<Puesto>>(new List<Puesto> { response }, Mensaje);
                }
                return new Response<List<Puesto>>(Mensaje);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Puesto>> CrearPuesto(PuestoResponse Request)
        {
            try
            {
                Mensaje = "Puesto ha sido creado exitosamente";
                Puesto puesto = new Puesto()
                {
                    Nombre = Request.nombre
                };
                _context.Puestos.Add(puesto);
                await _context.SaveChangesAsync();
                return new Response<Puesto>(puesto, Mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Puesto>> BorrarPuesto(int id)
        {
            try
            {
                Mensaje = "El puesto ha sido borrado";
                var res = _context.Puestos.Find(id);
                Puesto puesto = new Puesto();
                var funcion = _context.Puestos.FirstOrDefault(x => x.Pkpuesto == id);
                if (funcion != null)
                {
                    _context.Puestos.Remove(res);
                    await _context.SaveChangesAsync();
                    return new Response<Puesto>(res, Mensaje);
                }
                else
                {
                    Mensaje = "Ha habido un error al momento de borrar el puesto";
                    return new Response<Puesto>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Puesto>> EditarPuesto([FromBody] PuestoResponse i, int id)
        {
            try
            {
                Mensaje = "El puesto ha sido editado";
                Puesto puesto = new Puesto();
                var res = _context.Puestos.Find(id);
                if (res != null)
                {
                    res.Nombre = i.nombre;

                    _context.Entry(res).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new Response<Puesto>(res, Mensaje);
                }
                else
                {
                    Mensaje = "Ha habido un error al momento de editar el puesto";
                    return new Response<Puesto>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }
    }
}
