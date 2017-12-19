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
    public partial class formClientes : Form
    {
        public string nombreCliente;
        public int idCliente;

        public formClientes()
        {
            InitializeComponent();
        }

        private void clienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clienteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsCliente);

        }

        private void formClientes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCliente.Cliente' table. You can move, or remove it, as needed.
            this.clienteTableAdapter.Fill(this.dsCliente.Cliente);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nombreCliente = dsCliente.Cliente[clienteBindingSource.Position].Nombre;
            idCliente = dsCliente.Cliente[clienteBindingSource.Position].Id_Cliente;
            Close();
        }
    }
}
