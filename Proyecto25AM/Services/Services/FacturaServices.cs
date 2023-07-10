using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class FacturaServices:IFacturaServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public FacturaServices(ApplicationDbContext context)
        {
            _context = context;
        }
        //Creacion de funciones Crud
        public async Task<Response<List<Factura>>> ObtenerFacturas()
        {
            try
            {
                //Mensaje = "La lista de facturas";
                var response = await _context.Facturas.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Factura>>(response, Mensaje);

                }
                else
                {
                    Mensaje = "No hay ningun registro";
                    return new Response<List<Factura>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<List<Factura>>> ObtenerFacturaId(int id)
        {
            try
            {
                //Mensaje = "La factura es: ";
                var response = await _context.Facturas.FindAsync(id);
                if (response != null)
                {
                    return new Response<List<Factura>>(new List<Factura> { response }, Mensaje);
                }
                return new Response<List<Factura>>(Mensaje);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Factura>> CrearFactura(FacturaResponse Request)
        {
            try
            {
                //Mensaje = "Factura ha sido creado exitosamente";
                Factura factura = new Factura()
                {
                    RazonSocial = Request.RazonSocial,
                    Fecha = Request.Fecha,
                    RFC = Request.RFC,
                    FkCliente = Request.FkCliente
                };
                _context.Facturas.Add(factura);
                await _context.SaveChangesAsync();
                return new Response<Factura>(factura, Mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Factura>> BorrarFactura(int id)
        {
            try
            {
                Mensaje = "La factura ha sido borrado";
                var res = _context.Facturas.Find(id);
                Factura factura = new Factura();
                var funcion = _context.Facturas.FirstOrDefault(x => x.PkFactura == id);
                if (funcion != null)
                {
                    _context.Facturas.Remove(res);
                    await _context.SaveChangesAsync();
                    return new Response<Factura>(res, Mensaje);
                }
                else
                {
                    Mensaje = "Ha habido un error al momento de borrar la factura";
                    return new Response<Factura>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Factura>> EditarFactura([FromBody] FacturaResponse i, int id)
        {
            try
            {
                Mensaje = "La factura ha sido editado";
                Factura factura = new Factura();
                var res = _context.Facturas.Find(id);
                if (res != null)
                {
                    res.RazonSocial = i.RazonSocial;
                    res.Fecha = i.Fecha;
                    res.RFC = i.RFC;
                    res.FkCliente = i.FkCliente;

                    _context.Entry(res).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new Response<Factura>(res, Mensaje);
                }
                else
                {
                    Mensaje = "Ha habido un error al momento de editar la factura";
                    return new Response<Factura>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }
    }
}
