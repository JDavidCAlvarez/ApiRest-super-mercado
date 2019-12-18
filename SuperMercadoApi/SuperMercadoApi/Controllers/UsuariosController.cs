using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperMercadoApi.Controllers
{
    public class UsuariosController : ApiController
    {
        private SuperMercadoEntities dbContext = new SuperMercadoEntities();


        [HttpGet]
        public USUARIO Get(int id_usuario)
        {
            using (SuperMercadoEntities usuariosentities = new SuperMercadoEntities())
            {
                return usuariosentities.USUARIOs.FirstOrDefault(e => e.ID_USUARIO == id_usuario);
            }
        }

        [HttpGet]
        public USUARIO Get(string nombre_usuario)
        {
            using (SuperMercadoEntities usuariosentities = new SuperMercadoEntities())
            {
                var usu = usuariosentities.USUARIOs.FirstOrDefault(e => e.NOMBRE_USUARIO == nombre_usuario);
                
                if (usu != null) {
                   return usu;
                }
                else
                {
                   return null;
                }
                
            }
        }
    }
}
