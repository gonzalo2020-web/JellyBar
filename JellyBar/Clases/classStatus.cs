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
    public class classStatus
    {
        #region Variables        
        private bool _seleccionar = false;
        private int _idstatus = 0;
        private string _status = String.Empty;
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
        /// Obtiene o asigna numero de IdStatus.
        /// </summary>
        /// <value>Un <i>int</i> con numero de IdStatus.</value>
        public int IdStatus
        {
            get { return this._idstatus; }
            set { if (this._idstatus != value) { this._idstatus = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o asigna numero de Status.
        /// </summary>
        /// <value>Un <i>string</i> con numero de Status.</value>
        public string Status
        {
            get { return this._status; }
            set { if (this._status != value) { this._status = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
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
        /// Inicializa una nueva instancia de la clase <see cref="classStatus"/>.
        /// </summary>
        public classStatus()
        {
            this._objStat = Stat.New;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="classStatus"/>.
        /// </summary>
        public classStatus(int id)
        {
            try
            {
                LoadData(String.Format("SELECT * FROM CatStatus WHERE IdStatus={0", id));
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
                            gd.SentenciaSQL = "INSERT INTO CatStatus(IdStatus,Status,Activo,FechaRegistro) "
                                    + "VALUES(@IdStatus,@Status,@Activo,getdate()); ";
                            gd.AddParameter(_idstatus, "IdStatus");
                            gd.AddParameter(_status, "Status");
                            gd.AddParameter(_activo, "Activo");
                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Changed:
                            gd.SentenciaSQL = "UPDATE CatStatus SET "
                                + "Status=@Status, "
                                + "Activo=@Activo "
                                + "WHERE IdStatus=@IdStatus";
                            gd.AddParameter(_idstatus, "IdStatus");
                            gd.AddParameter(_status, "Status");
                            gd.AddParameter(_activo, "Activo");
                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Deleted:
                            gd.SentenciaSQL = "DELETE FROM CatStatus WHERE IdStatus=@IdStatus";
                            gd.AddParameter(_idstatus, "IdStatus");
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
            this._idstatus = int.Parse(dr["IdStatus"].ToString().Trim());
            this._status = dr["Status"].ToString().Trim();
            this._activo = bool.Parse(dr["Activo"].ToString().Trim());
            this._fecharegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
        }

        private void ResetFields()
        {
            this._seleccionar = false;
            this._idstatus = 0;
            this._status = String.Empty;
            this._activo = false;
            this._fecharegistro = DateTime.MinValue;
        }

        #endregion
    }
}
