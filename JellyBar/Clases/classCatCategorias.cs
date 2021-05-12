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
    public class classCatCategorias
    {
        #region Variables        
        private bool _seleccionar = false;
        private int _idcategoria = 0;
        private string _descripcion = String.Empty;        
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
        /// Obtiene o asigna numero de IdCategoria.
        /// </summary>
        /// <value>Un <i>int</i> con numero de IdCategoria.</value>
        public int IdCategoria
        {
            get { return this._idcategoria; }
            set { if (this._idcategoria != value) { this._idcategoria = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o asigna numero de Descripcion.
        /// </summary>
        /// <value>Un <i>string</i> con numero de Descripcion.</value>
        public string Descripcion
        {
            get { return this._descripcion; }
            set { if (this._descripcion != value) { this._descripcion = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
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
        /// Inicializa una nueva instancia de la clase <see cref="classCatCategorias"/>.
        /// </summary>
        public classCatCategorias()
        {
            this._objStat = Stat.New;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="classCatCategorias"/>.
        /// </summary>
        public classCatCategorias(int idcat)
        {
            try
            {
                LoadData(String.Format("SELECT * FROM CatCategorias WHERE IdCategoria={0", idcat));
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
                            gd.SentenciaSQL = "INSERT INTO CatCategorias(IdCategoria,Descripcion,Activo,FechaRegistro) "
                                    + "VALUES(@IdCategoria,@Descripcion,@Activo,getdate()); ";
                            gd.AddParameter(_idcategoria, "IdCategoria");
                            gd.AddParameter(_descripcion, "Descripcion");
                            gd.AddParameter(_activo, "Activo");
                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Changed:
                            gd.SentenciaSQL = "UPDATE CatCategorias SET "
                                + "Descripcion=@Descripcion, "                                
                                + "Activo=@Activo "
                                + "WHERE IdCategoria=@IdCategoria";
                            gd.AddParameter(_idcategoria, "IdCategoria");
                            gd.AddParameter(_descripcion, "Descripcion");                            
                            gd.AddParameter(_activo, "Activo");
                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Deleted:
                            gd.SentenciaSQL = "DELETE FROM CatCategorias WHERE IdCategoria=@IdCategoria";
                            gd.AddParameter(_idcategoria, "IdCategoria");
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
            this._idcategoria = int.Parse(dr["IdCategoria"].ToString().Trim());
            this._descripcion = dr["Descripcion"].ToString().Trim();           
            this._activo = bool.Parse(dr["Activo"].ToString().Trim());
            this._fecharegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
        }

        private void ResetFields()
        {
            this._seleccionar = false;
            this._idcategoria = 0;
            this._descripcion = String.Empty;
            this._activo = false;
            this._fecharegistro = DateTime.MinValue;
        }

        #endregion

    }
}
