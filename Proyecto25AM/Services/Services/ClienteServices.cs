using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class ClienteServices:IClienteServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public ClienteServices(ApplicationDbContext context)
        {
            _context = context;
        }
        //Creacion de funciones Crud
        public async Task<Response<List<Cliente>>> Obtenerclientes()
        {
            try
            {
                Mensaje = "La lista de clientes";
                var response = await _context.Clientes.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Cliente>>(response, Mensaje);

                }
                else
                {
                    Mensaje = "No hay ningun registro";
                    return new Response<List<Cliente>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<List<Cliente>>> ObtenerClienteId(int id)
        {
            try
            {
                var response = await _context.Clientes.FindAsync(id);
                if (response != null)
                {
                    return new Response<List<Cliente>>(new List<Cliente> { response }, Mensaje);
                }
                return new Response<List<Cliente>>(Mensaje);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Cliente>> CrearCliente(ClienteResponse Request)
        {
            try
            {
                Mensaje = "Cliente ha sido creado exitosamente";
                Cliente cliente = new Cliente()
                {
                    Nombre = Request.nombre,
                    Apellido = Request.apellido,
                    Telefono = Request.telefono,
                    Direccion = Request.direccion,
                    Email = Request.email
                };
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return new Response<Cliente>(cliente, Mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Cliente>> BorrarCliente(int id)
        {
            try
            {
                Mensaje = "El Cliente ha sido borrado";
                var res = _context.Clientes.Find(id);
                Cliente cliente = new Cliente();
                var funcion = _context.Clientes.FirstOrDefault(x => x.PkCliente == id);
                if (funcion != null)
                {
                    _context.Clientes.Remove(res);
                    await _context.SaveChangesAsync();
                    return new Response<Cliente>(res, Mensaje);
                }
                else
                {
                    Mensaje = "Ha habido un error al momento de borrar el cliente";
                    return new Response<Cliente>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Cliente>> Editarcliente([FromBody] ClienteResponse i, int id)
        {
            try
            {
                Mensaje = "El cliente ha sido editado";
                Cliente cliente = new Cliente();
                var res = _context.Clientes.Find(id);
                if (res != null)
                {
                    res.Nombre = i.nombre;
                    res.Apellido = i.apellido;
                    res.Telefono = i.telefono;
                    res.Direccion = i.direccion;
                    res.Email = i.email;

                    _context.Entry(res).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new Response<Cliente>(res, Mensaje);
                }
                else
                {
                    Mensaje = "Ha habido un error al momento de editar el cliente";
                    return new Response<Cliente>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }
    }
}
