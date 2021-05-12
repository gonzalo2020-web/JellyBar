using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;

namespace JellyBar.ModAdministrador
{
    public partial class ucMenu : XtraUserControl
    {
        Buscando buscando = new Buscando();
        ucAgendar agendar;
        ucCatalogos catalogos;
        string ventana = "";

        public ucMenu()
        {
            InitializeComponent();
        }

        private void Buscando()
        {
            this.splitContainerControl1.Panel1.Controls.Add(buscando);
            this.splitContainerControl1.Panel1.Controls[buscando.Name].BringToFront();
            this.splitContainerControl1.Panel1.Controls[buscando.Name].Dock = DockStyle.Fill;
            splitContainerControl1.Panel1.Refresh();
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
        }

        internal void ViewData(string v)
        {
            try
            {
                ventana = v.ToString();
                Buscando();
                this.backgroundWorker1.RunWorkerAsync(v.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void BringToFront(string Name)
        {
            ocultarControles();
            this.treeListPantallas.Controls[Name].BringToFront();
            this.treeListPantallas.Controls[Name].Visible = true;
            this.treeListPantallas.Controls[Name].Dock = DockStyle.Fill;
        }
        private void ocultarControles()
        {
            foreach (Control c in this.treeListPantallas.Controls)
            {
                c.Visible = false;
            }
        }
        private void inicializeControles(string miControl)
        {
            switch (miControl)
            {
                case "agendar":
                    if (agendar == null)
                    {
                        agendar = new ucAgendar();
                    }
                    agendar.Name = miControl;
                    agendar.Visible = false;
                    this.treeListPantallas.Controls.Add(agendar);
                    break;
                case "catalogos":
                    if (catalogos == null)
                    {
                        catalogos = new ucCatalogos();
                    }
                    catalogos.Name = miControl;
                    catalogos.Visible = false;
                    this.treeListPantallas.Controls.Add(catalogos);
                    break;

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            switch (e.Argument)
            {
                case "agendar":
                case "catalogos":
                    for (int i = 1; i <= 10; i++)
                    {
                        System.Threading.Thread.Sleep(300);
                        backgroundWorker1.ReportProgress(i * 10);
                    }
                    break;               
            }
            e.Result = e.Argument;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            buscando.pBar.EditValue = e.ProgressPercentage;
            buscando.pBar.Refresh();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //DevExpress.XtraEditors.XtraMessageBox.Show("El proceso se ha cancelado");
            }
            else if (e.Error != null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Error. details: " + (e.Error as Exception).ToString());
            }
            else
            {
                inicializeControles(e.Result.ToString());
                BringToFront(e.Result.ToString());
                if(e.Result.ToString() == "catalogos")
                {
                    catalogos.viewdata();
                }
                if (e.Result.ToString() == "agendar")
                {
                    agendar.viewdata();
                }
               
                this.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                botones("I");
            }
        }

        private void botones(string v)
        {
            foreach (WindowsUIButton b in windowsUIButtonPanel1.Buttons)
            {
                b.Enabled = false;
            }           

            switch (v)
            {
                case "I":
                    windowsUIButtonPanel1.Buttons[0].Properties.Enabled = true;
                    break;
            }
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;           
            switch (btn.Caption.ToString())
            {
                case "Agregar":
                   if(ventana.ToString() == "agendar")
                    {
                        agendar.Agregar();
                    }
                    if (ventana.ToString() == "catalogos")
                    {
                        catalogos.Agregar();
                    }
                    botones("");
                    windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                    windowsUIButtonPanel1.Buttons[3].Properties.Enabled = true;
                    break;
                case "Guardar":
                    if (ventana.ToString() == "agendar")
                    {
                        agendar.Guardar();
                    }
                    if (ventana.ToString() == "catalogos")
                    {
                        catalogos.Guardar();
                    }
                    botones("I");
                    break;
                case "Eliminar":
                    if (ventana.ToString() == "agendar")
                    {
                        agendar.Eliminar();
                    }
                    if (ventana.ToString() == "catalogos")
                    {
                        catalogos.Eliminar();
                    }
                    botones("I");
                    break;
                case "Cancelar":
                    if (ventana.ToString() == "agendar")
                    {
                        agendar.Cancelar();
                    }
                    if (ventana.ToString() == "catalogos")
                    {
                        catalogos.Cancelar();
                    }
                    botones("I");
                    break;              
            }
        }
    }
}
