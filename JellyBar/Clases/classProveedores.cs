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
    public class classProveedores
    {
        #region Variables        
        private bool _seleccionar = false;
        private int _idproveedor = 0;
        private string _proveedor = String.Empty;
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
        /// Obtiene o asigna Proveedor.
        /// </summary>
        /// <value>Un <i>string</i> con Proveedor.</value>
        public string Proveedor
        {
            get { return this._proveedor; }
            set { if (this._proveedor != value) { this._proveedor = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
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
        /// Obtiene o asigna Wwho.
        /// </summary>
        /// <value>Un <i>int</i> con Wwho.</value>
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
        /// Inicializa una nueva instancia de la clase <see cref="classProveedores"/>.
        /// </summary>
        public classProveedores()
        {
            this._objStat = Stat.New;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="classProveedores"/>.
        /// </summary>
        public classProveedores(int idprov)
        {
            try
            {
                LoadData(String.Format("SELECT * FROM CatProveedores WHERE IdProveedor={0}", idprov));
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
                            gd.SentenciaSQL = "INSERT INTO CatProveedores(IdProveedor,Proveedor,Activo,FechaRegistro) "
                                    + "VALUES(@IdProveedor,@Proveedor,@Activo,getdate()); ";
                            gd.AddParameter(_idproveedor, "IdProveedor");
                            gd.AddParameter(_proveedor, "Proveedor");
                            gd.AddParameter(_activo, "Activo");                        
                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Changed:
                            gd.SentenciaSQL = "UPDATE CatProveedores SET "
                                + "Proveedor=@Proveedor, "
                                + "Activo=@Activo "                               
                                + "WHERE IdProveedor=@IdProveedor";
                            gd.AddParameter(_idproveedor, "IdProveedor");
                            gd.AddParameter(_proveedor, "Proveedor");
                            gd.AddParameter(_activo, "Activo");                          
                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Deleted:
                            gd.SentenciaSQL = "DELETE FROM CatProveedores WHERE IdProveedor=@IdProveedor";
                            gd.AddParameter(_idproveedor, "IdProveedor");
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
            this._proveedor = dr["Proveedor"].ToString().Trim();
            this._activo = bool.Parse(dr["Activo"].ToString().Trim());
            this._fecharegistro = DateTime.Parse(dr["FechaRegistro"].ToString());          
        }

        private void ResetFields()
        {
            this._seleccionar = false;
            this._idproveedor = 0;
            this._proveedor = String.Empty;
            this._activo = false;
            this._fecharegistro = DateTime.MinValue;           
        }

        #endregion
    }
}
