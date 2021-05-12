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
using JellyBar.Clases;
using Dsa.Common;

namespace JellyBar.ModAdministrador
{
    public partial class ucCatalogos : XtraUserControl
    {
        public ucCatalogos()
        {
            InitializeComponent();
            Botones("I");
        }

        internal void viewdata()
        {
            cargaproveedores();
            carrgaeventos();
            cargaproductos();
            cargaextras();
            cargacategorias();
        }

        private void cargacategorias()
        {
            global.classcategorias.Clear();
            this.CategoriasBindingSource.Clear();
            this.CategoriasBindingSource.DataSource = global.classcategorias.CategoriasLst;
            this.CategoriasBindingSource.ResetBindings(false);
        }

        private void carrgaeventos()
        {
            global.classeventos.Clear();
            this.EventosBindingSource.Clear();
            this.EventosBindingSource.DataSource = global.classeventos.EventosLst;
            this.EventosBindingSource.ResetBindings(false);
        }

        private void cargaproveedores()
        {
            global.classproveedores.Clear();
            this.ProveedoresBindingSource.Clear();
            this.ProveedoresBindingSource.DataSource = global.classproveedores.ProveedoresLst;
            this.ProveedoresBindingSource.ResetBindings(false);
        }

        private void cargaproductos()
        {
            global.classproductos.Clear();
            this.ProductosBindingSource.Clear();
            this.ProductosBindingSource.DataSource = global.classproductos.ProductosLst;
            this.ProductosBindingSource.ResetBindings(false);
        }

        private void cargaextras()
        {
            global.classextras.Clear();
            this.ExtrasBindingSource.Clear();
            this.ExtrasBindingSource.DataSource = global.classextras.ExtrasLst;
            this.ExtrasBindingSource.ResetBindings(false);
        }

        private void Botones(string v)
        {
            switch (v.ToString())
            {
                case "I":
                    txtProveedor.Enabled = false;
                    lupProveedor.Enabled = false;
                    txtNombreProdcuto.Enabled = false;
                    txtPrecio.Enabled = false;
                    txtDescripcionExtra.Enabled = false;
                    txtPrecioExtra.Enabled = false;
                    txtCategoria.Enabled = false;
                    break;
            }
        }

        internal void Agregar()
        {
            switch (npanelCatalogos.SelectedPage.Caption.ToString())
            {               
                case "Proveedores":
                    txtProveedor.Enabled = true;
                    txtProveedor.Focus();
                    break;
                case "Productos":
                    lupProveedor.Enabled = true;
                    txtNombreProdcuto.Enabled = true;
                    txtPrecio.Enabled = true;
                    break;
                case "Extras":
                    txtDescripcionExtra.Enabled = true;
                    txtPrecioExtra.Enabled = true;
                    break;
                case "Categorias":
                    txtCategoria.Enabled = true;
                    txtCategoria.Focus();
                    break;
            }
        }

        internal void Guardar()
        {
            switch (npanelCatalogos.SelectedPage.Caption.ToString())
            {
                case "Proveedores":
                    if(txtProveedor.Text.ToString() != "")
                    {
                        classProveedores p = global.classproveedores.ProveedoresLst.Find(f => f.Proveedor.ToString() == txtProveedor.Text.ToString());
                        if(p == null)
                        {
                            p = new classProveedores();
                            p.IdProveedor = global.classproveedores.ProveedoresLst.Count + 1;
                            p.Proveedor = txtProveedor.Text.ToString();
                            p.Activo = true;
                            p.Save();
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Ese proveedor ya existe", "Lista de proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        foreach (classProveedores item in ((List<classProveedores>)this.ProveedoresBindingSource.List).FindAll(f => f.ObjStat == Stat.Changed))
                        {
                            item.Save();
                        }
                    }
                    cargaproveedores();
                    break;
                case "Productos":
                    if(txtNombreProdcuto.Text.ToString() != "")
                    {
                        classProductos prod = global.classproductos.ProductosLst.Find(f => f.IdProveedor.ToString() == lupProveedor.Text.ToString() && f.Nombre.ToString() == txtNombreProdcuto.Text.ToString());
                        if(prod == null)
                        {
                            prod = new classProductos();
                            prod.IdProveedor = int.Parse(lupProveedor.Text.ToString());
                            prod.IdProducto = global.classproductos.ProductosLst.FindAll(f => f.IdProveedor.ToString() == lupProveedor.Text.ToString()).Count + 1;
                            prod.Nombre = txtNombreProdcuto.Text.ToString();
                            prod.Precio = float.Parse(txtPrecio.Text.ToString());
                            prod.Activo = true;
                            prod.Save();
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Ese Producto para ese proveedor ya existe", "Lista de productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        foreach (classProductos item in ((List<classProductos>)this.ProductosBindingSource.List).FindAll(f => f.ObjStat == Stat.Changed))
                        {
                            item.Save();
                        }
                    }
                    cargaproductos();
                    break;
                case "Extras":
                    if(txtDescripcionExtra.Text.ToString() != "")
                    {
                        classExtras e = global.classextras.ExtrasLst.Find(f => f.Descripcion.ToString() == txtDescripcionExtra.Text.ToString());
                        if(e == null)
                        {
                            e = new classExtras();
                            e.IdExtra = global.classextras.ExtrasLst.Count + 1;
                            e.Descripcion = txtDescripcionExtra.Text.ToString();
                            e.Precio = float.Parse(txtPrecioExtra.Text.ToString());
                            e.Activo = true;
                            e.Save();
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Ese costo extra ya existe", "Lista de costos extras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        foreach (classExtras item in ((List<classExtras>)this.ExtrasBindingSource.List).FindAll(f => f.ObjStat == Stat.Changed))
                        {
                            item.Save();
                        }
                    }
                    cargaextras();
                    break;
                case "Categorias":
                    if(txtCategoria.Text.ToString() != "")
                    {
                        classCatCategorias cat = global.classcategorias.CategoriasLst.Find(f => f.Descripcion.ToString() == txtCategoria.Text.ToString());
                        if(cat == null)
                        {
                            cat = new classCatCategorias();
                            cat.IdCategoria = global.classcategorias.CategoriasLst.Count + 1;
                            cat.Descripcion = txtCategoria.Text.ToString();
                            cat.Activo = true;
                            cat.Save();
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Ese categoria ya existe", "Lista de categorias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        foreach (classCatCategorias item in ((List<classCatCategorias>)this.CategoriasBindingSource.List).FindAll(f => f.ObjStat == Stat.Changed))
                        {
                            item.Save();
                        }
                    }
                    cargacategorias();
                    break;
            }
            Botones("I");
        }

        internal void Eliminar()
        {
            switch (npanelCatalogos.SelectedPage.Caption.ToString())
            {
                case "Proveedores":
                    foreach (classProveedores item in ((List<classProveedores>)this.ProveedoresBindingSource.List).FindAll(f => f.Seleccionar == true))
                    {
                        item.DeleteNow();
                    }
                    cargaproveedores();
                    break;
                case "Productos":
                    foreach (classProductos item in ((List<classProductos>)this.ProductosBindingSource.List).FindAll(f => f.Seleccionar == true))
                    {
                        item.Save();
                    }
                    cargaproductos();
                    break;
                case "Extras":
                    foreach (classExtras item in ((List<classExtras>)this.ExtrasBindingSource.List).FindAll(f => f.Seleccionar == true))
                    {
                        item.Save();
                    }
                    cargaextras();
                    break;
                case "Categorias":
                    foreach (classCatCategorias item in ((List<classCatCategorias>)this.CategoriasBindingSource.List).FindAll(f => f.Seleccionar == true))
                    {
                        item.Save();
                    }
                    cargacategorias();
                    break;
            }
            Botones("I");
        }

        internal void Cancelar()
        {
            switch (npanelCatalogos.SelectedPage.Caption.ToString())
            {
                case "Proveedores":
                    cargaproveedores();
                    break;
                case "Productos":
                    cargaproductos();
                    break;
                case "Extras":
                    cargaextras();
                    break;
                case "Categorias":
                    cargacategorias();
                    break;
            }
            Botones("I");
        }

       
    }
}
