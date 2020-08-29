using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPV.Service;
using SPV.util;
using SPV.Models;
using Microsoft.EntityFrameworkCore;

namespace SPV.Controllers
{
    public class ClienteController : Controller
    {
        private SPVContext dbo;
        private Respuesta respuesta;

        public ClienteController(SPVContext db)
        {
            dbo = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Cliente> clientes = await dbo.Cliente.ToListAsync();
            return View(clientes);
        }

        public IActionResult FormCliente(int id)
        {
            var cliente = dbo.Cliente.Find(id);
            return PartialView("FormClienteModal", cliente);
        }

        [HttpPost]
        public IActionResult SetCliente(Cliente cliente)
        {
            respuesta = new Respuesta();
            try
            {
                if(ModelState.IsValid)
                {
                    if(cliente.Id == 0)    
                    {
    
                        dbo.Cliente.Add(cliente);
                        dbo.SaveChanges();

                        respuesta.Estado = true;
                        respuesta.Mensaje = "Cliente Registrado con exito!";
                        respuesta.Resultado = "";
                        return Ok(respuesta);
                    }
                    else
                    {
                        dbo.Cliente.Update(cliente);
                        dbo.SaveChanges();
                        
                        respuesta.Estado = true;
                        respuesta.Mensaje = "Cliente Actulizado con exito!";
                        respuesta.Resultado = cliente.Id;
                        return Ok(respuesta);
                    }
                }
                else
                {
                    string messages = string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));

                    respuesta.Estado = false;
                    respuesta.Mensaje = " validar formulario "+ "'"+messages+"'";
                    return BadRequest(respuesta);
                }
            }
            catch (System.Exception ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = "!Error en el servidor" + ex.Message;
                respuesta.Resultado = "";
                return BadRequest(respuesta);
                
                throw;
            }
        }

        [HttpDelete]
        public IActionResult DeleteCliente(int id)
        {
            respuesta = new Respuesta();
            try
            {
                Cliente cliente = dbo.Cliente.Find(id);

                if(cliente != null)
                {
                    dbo.Cliente.Remove(cliente);
                    dbo.SaveChanges();

                    respuesta.Estado = true;
                    respuesta.Mensaje = "Cliente eliminado con exito!";
                    respuesta.Resultado = "";
                    return Ok(respuesta);
                }
                else
                {
                    respuesta.Estado = false;
                    respuesta.Mensaje = "Cliente no existe en el sistema";
                    respuesta.Resultado = "";
                    return BadRequest(respuesta);
                }
            }
            catch (System.Exception ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = "!Error en el servidor:" + ex.Message;
                respuesta.Resultado = "";
                return BadRequest(respuesta);
                
                throw;
            }

        }


    }
}