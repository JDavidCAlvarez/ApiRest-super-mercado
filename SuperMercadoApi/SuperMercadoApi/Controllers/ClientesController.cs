using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperMercadoApi.Controllers
{
    public class ClientesController : ApiController
    {
        private SuperMercadoEntities dbContext = new SuperMercadoEntities();

        [HttpGet]
        public PERSONA Get(String numero_identidad_persona)
        {
            using (SuperMercadoEntities supermercadoentities = new SuperMercadoEntities())
            {
                var per = supermercadoentities.PERSONAs.FirstOrDefault(e => e.NUMERO_IDENTIDAD_PERSONA == numero_identidad_persona);
                if (per != null)
                {
                    var cli = supermercadoentities.CLIENTEs.FirstOrDefault(e => e.ID_PERSONA_CLIENTE == per.ID_PERSONA);
                    if (cli != null)
                    {
                        return per;
                    }
                    else
                    {
                        return null;
                    }
                }
                else 
                {
                    return null;
                }
              
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarCliente([FromBody]PERSONA per)
        {
            if (ModelState.IsValid)
            {
                dbContext.PERSONAs.Add(per);
                CLIENTE cli = new CLIENTE();
                cli.ID_CLIENTE = per.NUMERO_IDENTIDAD_PERSONA.GetHashCode();
                cli.ID_PERSONA_CLIENTE = per.ID_PERSONA;
                dbContext.CLIENTEs.Add(cli);
                dbContext.SaveChanges();
                return Ok(per);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
