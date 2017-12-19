using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoTecProg2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void MostrarFactura()
        {
            Conexion cnn = new Conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("MostrarFactura",cn);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
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

        public void MostrarGrid()
        {
            Conexion cnn = new Conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("MostrarGrid",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFactura", textBox10.Text);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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

        public void sumarTotal()
        {
            float montoTotal = 0;
            float iva = 0;
            float total = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                montoTotal+= float.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
            }
            textBox13.Text = montoTotal.ToString();
            iva = montoTotal * 0.16f;
            total = iva + montoTotal;
            textBox14.Text = total.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;
            MostrarGrid();
            MostrarFactura();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            formEmpleados empleados = new formEmpleados();
            empleados.ShowDialog();
            textBox1.Text = Convert.ToString(empleados.idEmpleado);
            textBox2.Text = empleados.nombre;
            textBox3.Text = empleados.puesto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formClientes clientes = new formClientes();
            clientes.ShowDialog();
            textBox4.Text = Convert.ToString(clientes.idCliente);
            textBox5.Text = clientes.nombreCliente;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formProductos productos = new formProductos();
            productos.ShowDialog();
            textBox11.Text = productos.marca;
            textBox12.Text = Convert.ToString(productos.idProducto);
            textBox6.Text = productos.modelo;
            textBox9.Text = Convert.ToString(productos.stock);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formDistribuidores distribuidores = new formDistribuidores();
            distribuidores.ShowDialog();
            textBox8.Text = distribuidores.distribuidor;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            factura fact = new factura();
            DateTime fecha = DateTime.Now;
            fact.agregarFactura(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox4.Text), fecha);

            Conexion cnn = new Conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("UltimoFactura", cn);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                da.Fill(tb);
                textBox10.Text = tb.Rows[0][0].ToString();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally{
                cn.Dispose();
                cmd.Dispose();
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            factura fact = new factura();
            fact.agregarProducto(Convert.ToInt32(textBox10.Text),Convert.ToInt32(textBox12.Text));
            fact.cantidad(Convert.ToInt32(textBox12.Text), Convert.ToInt32(textBox7.Text));
            MostrarGrid();
            sumarTotal();
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if(textBox7.Text.Length < 3 || Convert.ToInt32(textBox7.Text) <= 0 || textBox7.Text.Length == 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBox7, "Ingrese un valor dentro del formato 001 a 999");
                }
                else if(Convert.ToInt32(textBox7.Text) > Convert.ToInt32(textBox9.Text))
                {
                    MessageBox.Show("Cantidad no valida, supera el stock");
                }
                else
                {
                    errorProvider1.SetError(textBox7, string.Empty);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese solo numeros positivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string idproducto, existencia;
            int cantidad;
            double costo, precio;
            try
            {

                cantidad = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                if (Convert.ToInt32(cantidad) < 0 || Convert.ToInt32(cantidad) == 0)
                {
                    MessageBox.Show("Solo puede ingresar numeros positivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Conexion cnn = new Conexion();
                    SqlConnection cn = new SqlConnection(cnn.LeerConexion());
                    SqlCommand cmd = new SqlCommand("MostrarPorIDProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProducto", dataGridView1.CurrentRow.Cells[0].Value);
                    try
                    {
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        DataTable tb2 = new DataTable();
                        da2.Fill(tb2);
                        string variable = tb2.Rows[0][5].ToString();
                        existencia = tb2.Rows[0][4].ToString();
                        precio = double.Parse(variable);
                        cantidad = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                        costo = precio * cantidad;
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

                    if (Convert.ToInt32(cantidad) <= Convert.ToInt32(existencia))
                    {
                        if (Convert.ToInt32(cantidad) <= Convert.ToInt32(existencia))
                        {
                            idproducto = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                            factura fac = new factura();
                            fac.modificarCompra(Convert.ToInt32(idproducto), Convert.ToInt32(cantidad), Convert.ToDouble(costo));
                            MostrarGrid();
                            sumarTotal();
                        }
                        else
                        {
                            MessageBox.Show("La cantidad supera el stock disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad supera el stock disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("El valor no puede ser nulo");
            }
        }

        private void textBox10_Validating(object sender, CancelEventArgs e)
        {
            if(textBox10.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox10, "Presione el boton para generar un pedido");
            }
            else
            {
                errorProvider1.SetError(textBox10, string.Empty);
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Indique el ID del Empleado");
            }
            else
            {
                errorProvider1.SetError(textBox1, string.Empty);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Indique el nombre del Empleado");
            }
            else
            {
                errorProvider1.SetError(textBox2, string.Empty);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "Indique el puesto del Empleado");
            }
            else
            {
                errorProvider1.SetError(textBox3, string.Empty);
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox4, "Indique el ID del cliente");
            }
            else
            {
                errorProvider1.SetError(textBox4, string.Empty);
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox5, "Indique el nombre del cliente");
            }
            else
            {
                errorProvider1.SetError(textBox5, string.Empty);
            }
        }

        private void textBox11_Validating(object sender, CancelEventArgs e)
        {
            if (textBox11.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox11, "Indique la marca del producto");
            }
            else
            {
                errorProvider1.SetError(textBox11, string.Empty);
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox6, "Indique el nombre del producto");
            }
            else
            {
                errorProvider1.SetError(textBox6, string.Empty);
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (textBox8.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox8, "Indique el distribuidor");
            }
            else
            {
                errorProvider1.SetError(textBox8, string.Empty);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reporte report = new Reporte();
            report.ShowDialog();
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string idProducto, cantidad, existencia;
                int nuevaCantidad;
                cantidad = dataGridView1.Rows[i].Cells[5].Value.ToString();
                idProducto = dataGridView1.Rows[i].Cells[0].Value.ToString();

                Conexion cnn = new Conexion();
                SqlConnection cn = new SqlConnection(cnn.LeerConexion());
                SqlCommand cmd = new SqlCommand("MostrarPorIDProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", dataGridView1.Rows[i].Cells[0].Value);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable tb = new DataTable();
                    da.Fill(tb);
                    existencia = tb.Rows[0][4].ToString();
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

                nuevaCantidad = Convert.ToInt32(existencia) - Convert.ToInt32(cantidad);
                factura fact = new factura();
                fact.modificarStock(Convert.ToInt32(idProducto), nuevaCantidad);
            }
            MessageBox.Show("La orden fue enviada, puede imprimir recibo");
        }
    }
}
