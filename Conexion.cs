using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace ProyectoTecProg2
{
    class Conexion
    {
        public string LeerConexion()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["ProyectoTecProg2.Properties.Settings.Proyecto1ConnectionString"].ConnectionString;
                
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
