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
    public partial class formDistribuidores : Form
    {
        public string distribuidor;

        public formDistribuidores()
        {
            InitializeComponent();
        }

        private void distribuidoresBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.distribuidoresBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsDistribuidores);

        }

        private void formDistribuidores_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsDistribuidores.Distribuidores' table. You can move, or remove it, as needed.
            this.distribuidoresTableAdapter.Fill(this.dsDistribuidores.Distribuidores);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            distribuidor = dsDistribuidores.Distribuidores[distribuidoresBindingSource.Position].Distribuidor;
            Close();
        }
    }
}
