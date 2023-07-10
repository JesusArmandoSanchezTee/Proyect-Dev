using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IFacturaServices
    {
        public Task<Response<List<Factura>>> ObtenerFacturas();
        public Task<Response<List<Factura>>> ObtenerFacturaId(int id);
        public Task<Response<Factura>> CrearFactura(FacturaResponse Request);
        public Task<Response<Factura>> BorrarFactura(int id);
        public Task<Response<Factura>> EditarFactura([FromBody] FacturaResponse i, int id);
    }
}
