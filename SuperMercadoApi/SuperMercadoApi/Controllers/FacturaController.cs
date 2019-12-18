using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperMercadoApi.Controllers
{
    public class FacturaController : ApiController
    {
        private SuperMercadoEntities dbContext = new SuperMercadoEntities();

        [HttpGet]
        public FACTURA Get(int id_factura)
        {
            using (SuperMercadoEntities supermercadoentities = new SuperMercadoEntities())
            {
                var fac = supermercadoentities.FACTURAs.FirstOrDefault(e => e.ID_FACTURA == id_factura);
                if (fac != null)
                {
                    return fac;
                }
                else
                {
                    return null;
                }

            }
        }

        [HttpGet]
        public FACTURA Get(int id_factura)
        {
            using (SuperMercadoEntities supermercadoentities = new SuperMercadoEntities())
            {
                var fac = supermercadoentities.FACTURAs.FirstOrDefault(e => e.ID_FACTURA == id_factura);
                if (fac != null)
                {
                    return fac;
                }
                else
                {
                    return null;
                }

            }
        }


        [HttpPost]
        public IHttpActionResult AgregarFactura([FromBody]FACTURA fac)
        {
           if (ModelState.IsValid)
            {
                dbContext.FACTURAs.Add(fac);
                dbContext.SaveChanges();

                return Ok(fac);
            }
           else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarProductoFactura([FromBody]FACTURA_PRODUCTO fac)
        {
            if (ModelState.IsValid)
            {
                dbContext.FACTURA_PRODUCTO.Add(fac);

                PRODUCTO pro = dbContext.PRODUCTOes.FirstOrDefault(e => e.ID_PRODUCTO == fac.ID_PRODUCTO);

                int cp = pro.CANTIDAD_PRODUCTO.Value;
                cp = cp - fac.CANTIDAD_PRODUCTO.Value;

                pro.CANTIDAD_PRODUCTO = cp;

                dbContext.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();

                return Ok(fac);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
