using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class EmpleadosServices:IEmpleadosServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public  EmpleadosServices(ApplicationDbContext context)
        {
            _context = context;
        }
        //Creacion de funciones Crud
        public async Task<Response<List<Empleado>>> ObtenerEmpleados()
        {
            try
            {
                //Mensaje = "La lista de empleados";
                var response = await _context.Empleados.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Empleado>>(response, Mensaje);

                }
                else
                {
                    //Mensaje = "No hay ningun registro";
                    return new Response<List<Empleado>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<List<Empleado>>> ObtenerEmpleadoId(int id)
        {
            try
            {
                var response = await _context.Empleados.FindAsync(id);
                if (response != null)
                {
                    return new Response<List<Empleado>>(new List<Empleado> { response }, Mensaje);
                }
                return new Response<List<Empleado>>(Mensaje);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Empleado>> CrearEmpleado(EmpleadoResponse Request)
        {
            try
            {
                Mensaje = "Empleado ha sido creado exitosamente";
                Empleado empleado = new Empleado()
                {
                    Nombre = Request.nombre,
                    Apellidos = Request.apellido,
                    Direccion = Request.direccion,
                    Ciudad = Request.ciudad,
                    FkPuesto = Request.FkPuesto,
                    FkDepartamento = Request.FkDepartamento
                };
                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();
                return new Response<Empleado>(empleado, Mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Empleado>> BorrarEmpleado(int id)
        {
            try
            {
                Mensaje = "El empleado ha sido borrado";
                var res = _context.Empleados.Find(id);
                Empleado empleado = new Empleado();
                var funcion = _context.Empleados.FirstOrDefault(x => x.PkEmpleado == id);
                if (funcion != null)
                {
                    _context.Empleados.Remove(res);
                    await _context.SaveChangesAsync();
                    return new Response<Empleado>(res, Mensaje);
                }
                else
                {
                    Mensaje = "Ha habido un error al momento de borrar el empleado";
                    return new Response<Empleado>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Empleado>> EditarEmpleado([FromBody] EmpleadoResponse i, int id)
        {
            try
            {
                Mensaje = "El empleado ha sido editado";
                Empleado empleado = new Empleado();
                var res = _context.Empleados.Find(id);
                if (res != null)
                {
                    res.Nombre = i.nombre;
                    res.Apellidos = i.apellido;
                    res.Direccion = i.direccion;
                    res.Ciudad = i.ciudad;
                    res.FkPuesto = i.FkPuesto;
                    res.FkDepartamento = i.FkDepartamento;

                    _context.Entry(res).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new Response<Empleado>(res, Mensaje);
                }
                else
                {
                    Mensaje = "Ha habido un error al momento de editar el empleado";
                    return new Response<Empleado>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }
        public async Task<Response<List<Empleado>>> EmpleMulti()
        {
            Puesto en = new Puesto();
            Departamento es = new Departamento();
            var c = await _context.Empleados.Include(z => z.puesto).Include(z => z.departamento).ToListAsync();
            return new Response<List<Empleado>>(c);
        }
    }
}
