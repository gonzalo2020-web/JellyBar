using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JellyBar.Clases;

namespace JellyBar.ModAdministrador
{
    public partial class ucAgendar : UserControl
    {        

        public ucAgendar()
        {
            InitializeComponent();
        }

        internal void viewdata()
        {
            CargaAgenda();
            Cargacombos();
            Botones("I");
        }

        private void Botones(string v)
        {
            switch (v.ToString())
            {
                case "I":
                    panelControl1.Enabled = false;
                    break;
            }
        }

        private void CargaAgenda()
        {

        }
        private void Cargacombos()
        {
            cboCategoria.Items.Clear();
            foreach (classCatCategorias cat in global.classcategorias.CategoriasLst)
            {
                cboCategoria.Items.Add(cat.Descripcion.ToString());
            }

            cboStatus.Items.Clear();
            foreach (classStatus item in global.classstatus.StatusLst)
            {
                cboStatus.Items.Add(item.Status.ToString());
            }
        }

        internal void Agregar()
        {
            panelControl1.Enabled = true;
            txtNombre.Focus();
        }

        internal void Guardar()
        {
           
        }

        internal void Eliminar()
        {
          
        }

        internal void Cancelar()
        {
           
        }

      
    }
}
