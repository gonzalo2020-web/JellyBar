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
    public class classEventos
    {
        #region Variables        
        private bool _seleccionar = false;
        private int _idevento = 0;       
        private string _nombre = String.Empty;
        private string _direccion = String.Empty;
        private DateTime _fechaevento = DateTime.MinValue;
        private int _cantpersonas = 0;
        private string _categoria = String.Empty;
        private float _costo = 0;
        private string _status = String.Empty;  
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
        /// Obtiene o asigna numero de IdEvento.
        /// </summary>
        /// <value>Un <i>int</i> con numero de IdEvento.</value>
        public int IdEvento
        {
            get { return this._idevento; }
            set { if (this._idevento != value) { this._idevento = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
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
        /// Obtiene o asigna Direccion.
        /// </summary>
        /// <value>Un <i>string</i> con Direccion.</value>
        public string Direccion
        {
            get { return this._direccion; }
            set { if (this._direccion != value) { this._direccion = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o asigna FechaEvento.
        /// </summary>
        /// <value>Un <i>DateTime</i> con FechaEvento.</value>
        public DateTime FechaEvento
        {
            get { return this._fechaevento; }
            set { if (this._fechaevento != value) { this._fechaevento = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o int CantPersonas.
        /// </summary>
        /// <value>Un <i>int</i> con CantPersonas.</value>
        public int CantPersonas
        {
            get { return this._cantpersonas; }
            set { if (this._cantpersonas != value) { this._cantpersonas = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
       
        /// <summary>
        /// Obtiene o asigna Categoria.
        /// </summary>
        /// <value>Un <i>string</i> con Categoria.</value>
        public string Categoria
        {
            get { return this._categoria; }
            set { if (this._categoria != value) { this._categoria = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o float Costo.
        /// </summary>
        /// <value>Un <i>float</i> con Costo.</value>
        public float Costo
        {
            get { return this._costo; }
            set { if (this._costo != value) { this._costo = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }
        /// <summary>
        /// Obtiene o asigna Activo.
        /// </summary>
        /// <value>Un <i>string</i> con Activo.</value>
        public string Status
        {
            get { return this._status; }
            set { if (this._status != value) { this._status = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
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
        /// Inicializa una nueva instancia de la clase <see cref="classEventos"/>.
        /// </summary>
        public classEventos()
        {
            this._objStat = Stat.New;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="classEventos"/>.
        /// </summary>
        public classEventos(int ide)
        {
            try
            {
                LoadData(String.Format("SELECT * FROM Eventos WHERE IdEvento={0}", ide));
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
                            gd.SentenciaSQL = "INSERT INTO Eventos(IdEvento,Nombre,Direccion,CantPersonas,Categoria,Costo,Status,FechaRegistro,FechaEvento) "
                                    + "VALUES(@IdEvento,@Nombre,@Direccion,@CantPersonas,@Categoria,@Costo,@Status,getdate(),@FechaEvento); ";
                            gd.AddParameter(_idevento, "IdEvento");
                            gd.AddParameter(_nombre, "Nombre");
                            gd.AddParameter(_direccion, "Direccion");
                            gd.AddParameter(_cantpersonas, "CantPersonas");
                            gd.AddParameter(_categoria, "Categoria");
                            gd.AddParameter(_costo, "Costo");
                            gd.AddParameter(_status, "Status");
                            gd.AddParameter(_fechaevento, "FechaEvento");                           
                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Changed:
                            gd.SentenciaSQL = "UPDATE Eventos SET "
                                + "Nombre=@Nombre, "
                                + "Direccion=@Direccion, "
                                + "CantPersonas=@CantPersonas, "
                                + "Categoria=@Categoria, "
                                + "Costo=@Costo, "
                                + "Status=@Status, "                               
                                + "FechaEvento=FechaEvento() "
                                + "WHERE IdEvento=@IdEvento";
                            gd.AddParameter(_idevento, "IdEvento");
                            gd.AddParameter(_nombre, "Nombre");
                            gd.AddParameter(_direccion, "Direccion");
                            gd.AddParameter(_cantpersonas, "CantPersonas");
                            gd.AddParameter(_categoria, "Categoria");
                            gd.AddParameter(_costo, "Costo");
                            gd.AddParameter(_status, "Status");
                            gd.AddParameter(_fechaevento, "FechaEvento");
                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Deleted:
                            gd.SentenciaSQL = "DELETE FROM Eventos WHERE IdEvento=@IdEvento";
                            gd.AddParameter(_idevento, "IdEvento");                           
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
            this._idevento = int.Parse(dr["IdEvento"].ToString().Trim());            
            this._nombre = dr["Nombre"].ToString().Trim();
            this._direccion = dr["Direccion"].ToString().Trim();
            this._cantpersonas = int.Parse(dr["CantPersonas"].ToString().Trim());
            this._categoria = dr["Categoria"].ToString().Trim();
            this._costo = float.Parse(dr["Costo"].ToString().Trim());
            this._status = dr["Status"].ToString().Trim();           
            this._fecharegistro = DateTime.Parse(dr["FechaRegistro"].ToString());          
            this._fechaevento = DateTime.Parse(dr["FechaEvento"].ToString());
        }

        private void ResetFields()
        {
            this._seleccionar = false;
            this._idevento = 0;
            this._nombre = String.Empty;
            this._direccion = String.Empty;
            this._cantpersonas = 0;
            this._categoria = String.Empty;
            this._costo = 0;
            this._status = String.Empty;           
            this._fecharegistro = DateTime.MinValue;
            this._fechaevento = DateTime.MinValue;
        }

        #endregion
    }
}
