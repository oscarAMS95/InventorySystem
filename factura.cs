using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoTecProg2
{
    class factura
    {
        public void agregarFactura(int idEmpleado, int idCliente, DateTime fecha)
        {
            Conexion cnn = new Conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("InsertarFactura",cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
            cmd.Parameters.AddWithValue("@idProducto", idCliente);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Dispose();
                cmd.Dispose();
            }
        }

        public void agregarProducto(int idFactura, int idProducto)
        {
            Conexion cnn = new Conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("InsertarPedido", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idFactura",idFactura);
            cmd.Parameters.AddWithValue("@idProducto", idProducto);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Dispose();
                cmd.Dispose();
            }
        }

        public void modificarCompra(int idProducto, int cantidad, double coste) 
        {
            Conexion cnn = new Conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("ModificarCompra", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idProducto", idProducto);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@coste", coste);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Dispose();
                cmd.Dispose();
            }
        }

        public void cantidad(int idProducto, int cantidad)
        {
            Conexion cnn = new Conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("ModificarQuantity", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProducto", idProducto);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Dispose();
                cmd.Dispose();
            }
        }

        public void modificarStock(int idProducto, int cantidadStock)
        {
            Conexion cnn = new Conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("ModificarStock", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProducto", idProducto);
            cmd.Parameters.AddWithValue("@stock", cantidadStock);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Dispose();
                cmd.Dispose();
            }
        }
    }
}
