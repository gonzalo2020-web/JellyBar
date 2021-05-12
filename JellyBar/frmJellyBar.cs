using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using JellyBar.FormasGlobales;
using JellyBar.ModAdministrador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JellyBar
{
    public partial class frmJellyBar : XtraForm
    {
        public frmJellyBar()
        {
            InitializeComponent();
            iniskin();
            IniciaImagen();
        }

        ucImgInicio inicio;
        ucMenu menu;
      

        private void iniskin()
        {
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Dark");
        }

        private void IniciaImagen()
        {
            if (inicio == null)
            {
                inicializeControles("inicio");
            }                        
            BringToFront(inicio.Name);
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
                case "inicio":
                    if (inicio == null)
                    {
                        inicio = new ucImgInicio();
                    }
                    inicio.Name = miControl;
                    inicio.Visible = false;
                    this.treeListPantallas.Controls.Add(inicio);
                    break;
                case "menu":
                    if (menu == null)
                    {
                        menu = new ucMenu();
                    }
                    menu.Name = miControl;
                    menu.Visible = false;
                    this.treeListPantallas.Controls.Add(menu);
                    break;
            }
        }

        private void tbiAgendar_ItemClick(object sender, TileItemEventArgs e)
        {            
            inicializeControles("menu");            
            BringToFront(menu.Name);
            menu.ViewData("agendar");

        }

        private void tbiCatalogos_ItemClick(object sender, TileItemEventArgs e)
        {            
            inicializeControles("menu");           
            BringToFront(menu.Name);
            menu.ViewData("catalogos");
        }
    }
}
