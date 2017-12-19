namespace ProyectoTecProg2
{
    partial class Reporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsCliente = new ProyectoTecProg2.dsCliente();
            this.ClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClienteTableAdapter = new ProyectoTecProg2.dsClienteTableAdapters.ClienteTableAdapter();
            this.MostrarPDFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Proyecto1DataSet = new ProyectoTecProg2.Proyecto1DataSet();
            this.MostrarGridBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EmpleadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MostrarGridTableAdapter = new ProyectoTecProg2.Proyecto1DataSetTableAdapters.MostrarGridTableAdapter();
            this.EmpleadoTableAdapter = new ProyectoTecProg2.Proyecto1DataSetTableAdapters.EmpleadoTableAdapter();
            this.FacturaTableAdapter = new ProyectoTecProg2.Proyecto1DataSetTableAdapters.FacturaTableAdapter();
            this.InventarioTableAdapter = new ProyectoTecProg2.Proyecto1DataSetTableAdapters.InventarioTableAdapter();
            this.MostrarPDFTableAdapter = new ProyectoTecProg2.Proyecto1DataSetTableAdapters.MostrarPDFTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostrarPDFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Proyecto1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostrarGridBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpleadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.MostrarPDFBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoTecProg2.Reporte2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(704, 459);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsCliente
            // 
            this.dsCliente.DataSetName = "dsCliente";
            this.dsCliente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ClienteBindingSource
            // 
            this.ClienteBindingSource.DataMember = "Cliente";
            this.ClienteBindingSource.DataSource = this.dsCliente;
            // 
            // ClienteTableAdapter
            // 
            this.ClienteTableAdapter.ClearBeforeFill = true;
            // 
            // MostrarPDFBindingSource
            // 
            this.MostrarPDFBindingSource.DataMember = "MostrarPDF";
            this.MostrarPDFBindingSource.DataSource = this.Proyecto1DataSet;
            // 
            // Proyecto1DataSet
            // 
            this.Proyecto1DataSet.DataSetName = "Proyecto1DataSet";
            this.Proyecto1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MostrarGridBindingSource
            // 
            this.MostrarGridBindingSource.DataMember = "MostrarGrid";
            this.MostrarGridBindingSource.DataSource = this.Proyecto1DataSet;
            // 
            // EmpleadoBindingSource
            // 
            this.EmpleadoBindingSource.DataMember = "Empleado";
            this.EmpleadoBindingSource.DataSource = this.Proyecto1DataSet;
            // 
            // FacturaBindingSource
            // 
            this.FacturaBindingSource.DataMember = "Factura";
            this.FacturaBindingSource.DataSource = this.Proyecto1DataSet;
            // 
            // InventarioBindingSource
            // 
            this.InventarioBindingSource.DataMember = "Inventario";
            this.InventarioBindingSource.DataSource = this.Proyecto1DataSet;
            // 
            // MostrarGridTableAdapter
            // 
            this.MostrarGridTableAdapter.ClearBeforeFill = true;
            // 
            // EmpleadoTableAdapter
            // 
            this.EmpleadoTableAdapter.ClearBeforeFill = true;
            // 
            // FacturaTableAdapter
            // 
            this.FacturaTableAdapter.ClearBeforeFill = true;
            // 
            // InventarioTableAdapter
            // 
            this.InventarioTableAdapter.ClearBeforeFill = true;
            // 
            // MostrarPDFTableAdapter
            // 
            this.MostrarPDFTableAdapter.ClearBeforeFill = true;
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 459);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Reporte";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostrarPDFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Proyecto1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostrarGridBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpleadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource MostrarGridBindingSource;
        private Proyecto1DataSet Proyecto1DataSet;
        private System.Windows.Forms.BindingSource ClienteBindingSource;
        private dsCliente dsCliente;
        private System.Windows.Forms.BindingSource EmpleadoBindingSource;
        private System.Windows.Forms.BindingSource FacturaBindingSource;
        private System.Windows.Forms.BindingSource InventarioBindingSource;
        private Proyecto1DataSetTableAdapters.MostrarGridTableAdapter MostrarGridTableAdapter;
        private dsClienteTableAdapters.ClienteTableAdapter ClienteTableAdapter;
        private Proyecto1DataSetTableAdapters.EmpleadoTableAdapter EmpleadoTableAdapter;
        private Proyecto1DataSetTableAdapters.FacturaTableAdapter FacturaTableAdapter;
        private Proyecto1DataSetTableAdapters.InventarioTableAdapter InventarioTableAdapter;
        private System.Windows.Forms.BindingSource MostrarPDFBindingSource;
        private Proyecto1DataSetTableAdapters.MostrarPDFTableAdapter MostrarPDFTableAdapter;
    }
}