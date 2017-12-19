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
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Proyecto1DataSet.MostrarGrid' table. You can move, or remove it, as needed.
            // this.MostrarGridTableAdapter.Fill(this.Proyecto1DataSet.MostrarGrid);
            // TODO: This line of code loads data into the 'dsCliente.Cliente' table. You can move, or remove it, as needed.
            // this.ClienteTableAdapter.Fill(this.dsCliente.Cliente);
            // TODO: This line of code loads data into the 'Proyecto1DataSet.Cliente' table. You can move, or remove it, as needed.
            //  this.ClienteTableAdapter.Fill(this.Proyecto1DataSet.Cliente);
            // TODO: This line of code loads data into the 'Proyecto1DataSet.Empleado' table. You can move, or remove it, as needed.
            // this.EmpleadoTableAdapter.Fill(this.Proyecto1DataSet.Empleado);
            // TODO: This line of code loads data into the 'Proyecto1DataSet.Factura' table. You can move, or remove it, as needed.
            //this.FacturaTableAdapter.Fill(this.Proyecto1DataSet.Factura);
            // TODO: This line of code loads data into the 'Proyecto1DataSet.Inventario' table. You can move, or remove it, as needed.
            //this.InventarioTableAdapter.Fill(this.Proyecto1DataSet.Inventario);

            this.MostrarPDFTableAdapter.Fill(this.Proyecto1DataSet.MostrarPDF);
            this.reportViewer1.RefreshReport();
        }
    }
}
