using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTecProg2
{
    public partial class formProductos : Form
    {
        public string marca, modelo;
        public int stock, idProducto;

        public formProductos()
        {
            InitializeComponent();
        }

        private void inventarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.inventarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsInventario);

        }

        private void formProductos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsInventario.Inventario' table. You can move, or remove it, as needed.
            this.inventarioTableAdapter.Fill(this.dsInventario.Inventario);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            inventarioTableAdapter.FillByProducto(dsInventario.Inventario, "%" + textBox1.Text + "%");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            marca = dsInventario.Inventario[inventarioBindingSource.Position].Marca;
            modelo = dsInventario.Inventario[inventarioBindingSource.Position].Modelo;
            stock = dsInventario.Inventario[inventarioBindingSource.Position].Stock;
            idProducto = dsInventario.Inventario[inventarioBindingSource.Position].Id_Producto;
            Close();
        }
    }
}
