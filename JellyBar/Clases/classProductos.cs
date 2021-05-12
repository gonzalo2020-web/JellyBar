using Dsa.Common;
using Dsa.Dbms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JellyBar.Clases
{
    public class classProductos
    {
        #region Variables        
        private bool _seleccionar = false;
        private int _idproveedor = 0;
        private int _idproducto = 0;
        private string _nombre = String.Empty;
        private float _precio = 0;
        private bool _activo = false;
        private DateTime _fecharegistro = DateTime.MinValue;
        private Stat _objStat = Stat.New;
        #endregion

        #region Atributos 
        /// <summary>
        /// Obtiene o asigna Seleccionar.
        /// </summary>
        /// <value>Un <i>bool</i> con Seleccionar.</value>
        public bool Seleccionar
        {
            get { return this._seleccionar; }
            set { if (this._seleccionar != value) { this._seleccionar = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o asigna numero de IdProveedor.
        /// </summary>
        /// <value>Un <i>int</i> con numero de IdProveedor.</value>
        public int IdProveedor
        {
            get { return this._idproveedor; }
            set { if (this._idproveedor != value) { this._idproveedor = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o asigna numero de IdProducto.
        /// </summary>
        /// <value>Un <i>int</i> con numero de IdProducto.</value>
        public int IdProducto
        {
            get { return this._idproducto; }
            set { if (this._idproducto != value) { this._idproducto = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o asigna Nombre.
        /// </summary>
        /// <value>Un <i>string</i> con Nombre.</value>
        public string Nombre
        {
            get { return this._nombre; }
            set { if (this._nombre != value) { this._nombre = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o float Precio.
        /// </summary>
        /// <value>Un <i>float</i> con Precio.</value>
        public float Precio
        {
            get { return this._precio; }
            set { if (this._precio != value) { this._precio = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o asigna Activo.
        /// </summary>
        /// <value>Un <i>bool</i> con Activo.</value>
        public bool Activo
        {
            get { return this._activo; }
            set { if (this._activo != value) { this._activo = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o asigna FechaRegistro.
        /// </summary>
        /// <value>Un <i>DateTime</i> con FechaRegistro.</value>
        public DateTime FechaRegistro
        {
            get { return this._fecharegistro; }
            set { if (this._fecharegistro != value) { this._fecharegistro = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
       
        /// <summary>
        /// Obtiene el estado del objeto.
        /// </summary>
        /// <value>Un <i>Stat</i> con el estado del objeto.</value>
        public Stat ObjStat
        {
            get { return _objStat; }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="classProductos"/>.
        /// </summary>
        public classProductos()
        {
            this._objStat = Stat.New;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="classProductos"/>.
        /// </summary>
        public classProductos(int idprov, int idprod)
        {
            try
            {
                LoadData(String.Format("SELECT * FROM CatProductos WHERE IdProveedor={0} and IdProducto={1}", idprov,idprod));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Metodos
        #endregion

        #region IStatable Members
        /// <summary>
        /// Cambia el objeto a Preloaded cargado por un objeto externo.
        /// </summary>
        public void SetPreLoaded()
        {
            this._objStat = Stat.PreLoaded;
        }
        #endregion

        #region ISavable Members
        /// <summary>
        /// Inserta, Actualiza o borra de la base de datos seg�n el estado del objeto.
        /// </summary>
        public void Save()
        {
            try
            {
                using (GetData gd = Conn.GetConn("sql"))
                {
                    switch (this._objStat)
                    {
                        case Stat.New:
                            gd.SentenciaSQL = "INSERT INTO CatProductos(IdProveedor,IdProducto,Nombre,Precio,Activo,FechaRegistro) "
                                    + "VALUES(@IdProveedor,@IdProducto,@Nombre,@Precio,@Activo,getdate()); ";                            
                            gd.AddParameter(_idproveedor, "IdProveedor");
                            gd.AddParameter(_idproducto, "IdProducto");
                            gd.AddParameter(_nombre, "Nombre");
                            gd.AddParameter(_precio, "Precio");
                            gd.AddParameter(_activo, "Activo");                            
                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Changed:
                            gd.SentenciaSQL = "UPDATE CatProductos SET " 
                                + "Nombre=@Nombre, "
                                + "Precio=@Precio, "
                                + "Activo=@Activo "                                
                                + "WHERE IdProveedor=@IdProveedor and IdProducto=@IdProducto";
                            gd.AddParameter(_idproveedor, "IdProveedor");
                            gd.AddParameter(_idproducto, "IdProducto");
                            gd.AddParameter(_nombre, "Nombre");
                            gd.AddParameter(_precio, "Precio");
                            gd.AddParameter(_activo, "Activo");
                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Deleted:
                            gd.SentenciaSQL = "DELETE FROM CatProductos WHERE IdProveedor=@IdProveedor and IdProducto=@IdProducto";
                            gd.AddParameter(_idproveedor, "IdProveedor");
                            gd.AddParameter(_idproducto, "IdProducto");
                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Marca el objeto para ser borrado de la base de datos cuando se ejecute el m�todo Save()
        /// </summary>
        public void Delete()
        {
            this._objStat = Stat.Deleted;
        }

        /// <summary>
        /// Marca el objeto para ser borrado de la base de datos y lo borra inmediatamente de la DB.
        /// </summary>
        public void DeleteNow()
        {
            this._objStat = Stat.Deleted;
            this.Save();
        }

        private void LoadData(string SentenciaSQL)
        {
            try
            {
                using (GetData gd = Conn.GetConn("sql"))
                {
                    gd.SentenciaSQL = SentenciaSQL;
                    FillFields(gd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void FillFields(GetData gd)
        {
            try
            {
                using (DataTable dt = gd.GetDataTable())
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            FillField(dr);
                        }
                        this._objStat = Stat.Loaded;
                    }
                    else
                    {
                        ResetFields();
                        this._objStat = Stat.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FillField(DataRow dr)
        {
            this._seleccionar = false;
            this._idproveedor = int.Parse(dr["IdProveedor"].ToString().Trim());
            this._idproducto = int.Parse(dr["IdProducto"].ToString().Trim());
            this._nombre = dr["Nombre"].ToString().Trim();
            this._precio = float.Parse(dr["Precio"].ToString().Trim());
            this._activo = bool.Parse(dr["Activo"].ToString().Trim());
            this._fecharegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
        }

        private void ResetFields()
        {
            this._seleccionar = false;
            this._idproveedor = 0;
            this._idproducto = 0;
            this._nombre = String.Empty;
            this._precio = 0;
            this._activo = false;
            this._fecharegistro = DateTime.MinValue;
        }

        #endregion
    }
}
