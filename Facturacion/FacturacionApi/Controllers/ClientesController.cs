using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using FacturacionApi.Entities;
using FacturacionApi.Models;

namespace FacturacionApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {
        private FacturacionEntities context = new FacturacionEntities();
        [HttpGet]
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                clientes = context.Clientes.Select(cliente => new Cliente
                {
                    Documento = cliente.Documento,
                    Edad = cliente.Edad,
                    Nombres = cliente.Nombres,
                    PrimerApellido = cliente.PrimerApellido,
                    SegundoApellido = cliente.SegundoApellido
                }).ToList();
            }
            catch (Exception ex)
            {
                Ok(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
            return Json(clientes);
        }
        [HttpGet]
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente([FromUri] long id)
        {
            Clientes cliente = new Clientes();
            try
            {
                cliente = context.Clientes.Find(id) ?? new Clientes();
            }
            catch (Exception ex)
            {
                Ok(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
            if (cliente.Documento == 0)
                return Ok("Cliente no encontrado");
            Cliente clienteViewModel = new Cliente
            {
                Documento = cliente.Documento,
                Edad = cliente.Edad,
                Nombres = cliente.Nombres,
                PrimerApellido = cliente.PrimerApellido,
                SegundoApellido = cliente.SegundoApellido
            };
            return Json(clienteViewModel);
        }
        [HttpPost]
        [ResponseType(typeof(string))]
        public IHttpActionResult AddClientes([FromBody] Cliente clienteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Clientes cliente = new Clientes
            {
                Documento = clienteViewModel.Documento,
                Edad = clienteViewModel.Edad,
                Nombres = clienteViewModel.Nombres,
                PrimerApellido = clienteViewModel.PrimerApellido,
                SegundoApellido = clienteViewModel.SegundoApellido
            };
            context.Clientes.Add(cliente);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
            return Ok($"Cliente {clienteViewModel.Documento} creado con exito");
        }
        [HttpPut]
        [ResponseType(typeof(string))]
        public IHttpActionResult EditClientes([FromBody] Cliente clienteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Clientes cliente = context.Clientes.Find(clienteViewModel.Documento);
            if (cliente == null)
                return Ok("Cliente no encontrado");
            cliente.Edad = clienteViewModel.Edad;
            cliente.Nombres = clienteViewModel.Nombres;
            cliente.PrimerApellido = clienteViewModel.PrimerApellido;
            cliente.SegundoApellido = clienteViewModel.SegundoApellido;
            context.Entry(cliente).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
            return Ok($"Cliente {clienteViewModel.Documento} actualizado con exito");
        }
        [HttpDelete]
        [ResponseType(typeof(string))]
        public IHttpActionResult DeleteCliente(long id)
        {
            Clientes clientes = context.Clientes.Find(id);
            if (clientes == null)
                return Ok($"Cliente {id} no encontrado");
            context.Clientes.Remove(clientes);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.Contains("inner") ? ex.InnerException.Message : ex.Message);
            }
            return Ok($"Cliente {id} eliminado con exito");
        }
    }
}