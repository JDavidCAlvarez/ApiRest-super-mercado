using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperMercadoApi.Controllers
{
    public class ProductosController : ApiController
    {
        private SuperMercadoEntities dbContext = new SuperMercadoEntities();

        [HttpGet]
        public IEnumerable<PRODUCTO> Get()
        {
            using(SuperMercadoEntities productoentities = new SuperMercadoEntities())
            {
                return productoentities.PRODUCTOes.ToList();
            }
        }

        [HttpGet]
        public PRODUCTO Get(int id_producto)
        {
            using (SuperMercadoEntities productoentities = new SuperMercadoEntities())
            {
                return productoentities.PRODUCTOes.FirstOrDefault(e => e.ID_PRODUCTO == id_producto);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarProducto(int id_producto, [FromBody]PRODUCTO pro)
        {
            if (ModelState.IsValid)
            {
                var usuarioExiste = dbContext.PRODUCTOes.Count(e => e.ID_PRODUCTO == id_producto) > 0;
                if (usuarioExiste)
                {
                    dbContext.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarCantidadProducto(int id_producto, int cantidad_producto)
        {
            if (ModelState.IsValid)
            {
                PRODUCTO pro = dbContext.PRODUCTOes.FirstOrDefault(e => e.ID_PRODUCTO == id_producto);

                int cp = pro.CANTIDAD_PRODUCTO.Value;
                cp = cp - cantidad_producto;

                pro.CANTIDAD_PRODUCTO = cp;

                dbContext.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();

                return Ok("Exito");
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
