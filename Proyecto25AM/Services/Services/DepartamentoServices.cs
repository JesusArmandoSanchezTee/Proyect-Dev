using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class DepartamentoServices:IDepartamentoServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public DepartamentoServices(ApplicationDbContext context)
        {
            _context = context;
        }
        //Creacion de funciones Crud
        public async Task<Response<List<Departamento>>> ObtenerDepartamentos()
        {
            try
            {
                //Mensaje = "La lista de departamentos";
                var response = await _context.Departamentos.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Departamento>>(response, Mensaje);

                }
                else
                {
                    Mensaje = "No hay ningun registro";
                    return new Response<List<Departamento>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<List<Departamento>>> ObtenerDepartamentoId(int id)
        {
            try
            {
                var response = await _context.Departamentos.FindAsync(id);
                if (response != null)
                {
                    return new Response<List<Departamento>>(new List<Departamento> { response }, Mensaje);
                }
                return new Response<List<Departamento>>(Mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Departamento>> CrearDepartamento(DepartamentoResponse Request)
        {
            try
            {
                Mensaje = "Departamento ha sido creado exitosamente";
                Departamento departamento = new Departamento()
                {
                    Nombre = Request.nombre,
                };
                _context.Departamentos.Add(departamento);
                await _context.SaveChangesAsync();
                return new Response<Departamento>(departamento, Mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Departamento>> BorrarDepartamento(int id)
        {
            try
            {
                Mensaje = "El departamento ha sido borrado";
                var res = _context.Departamentos.Find(id);
                Departamento departamento = new Departamento();
                var funcion = _context.Departamentos.FirstOrDefault(x => x.PkDepartamento == id);
                if (funcion != null)
                {
                    _context.Departamentos.Remove(res);
                    await _context.SaveChangesAsync();
                    return new Response<Departamento>(res, Mensaje);
                }
                else
                {
                    Mensaje = "Ha habido un error al momento de borrar el departamento";
                    return new Response<Departamento>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Departamento>> EditarDepartamento([FromBody] DepartamentoResponse i, int id)
        {
            try
            {
                Mensaje = "El departamento ha sido editado";
                Departamento departamento = new Departamento();
                var res = _context.Departamentos.Find(id);
                if (res != null)
                {
                    res.Nombre = i.nombre;

                    _context.Entry(res).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new Response<Departamento>(res, Mensaje);
                }
                else
                {
                    Mensaje = "Ha habido un error al momento de editar el departamento";
                    return new Response<Departamento>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }
    }
}
