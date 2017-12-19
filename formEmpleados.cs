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
    public partial class formEmpleados : Form
    {
        public string nombre, puesto;
        public int idEmpleado;
        public formEmpleados()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            idEmpleado = dsEmpleado.Empleado[empleadoBindingSource.Position].Id_Empleado;
            nombre = dsEmpleado.Empleado[empleadoBindingSource.Position].Nombre;
            puesto = dsEmpleado.Empleado[empleadoBindingSource.Position].Puesto;
            Close();

        }

        private void empleadoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.empleadoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsEmpleado);

        }

        private void formEmpleados_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsEmpleado.Empleado' table. You can move, or remove it, as needed.
            this.empleadoTableAdapter.Fill(this.dsEmpleado.Empleado);

        }
    }
}
