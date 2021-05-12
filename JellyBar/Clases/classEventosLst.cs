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
    public class classEventosLst
    {
        #region Variables
        List<classEventos> _lstRecords = new List<classEventos>();
        private Stat _objStat;
        #endregion

        #region Atributos
        public List<classEventos> EventosLst
        {
            get
            {
                if (this._lstRecords.Count == 0)
                    GetRecords();
                return this._lstRecords;
            }
        }
        public Stat ObjStat
        {
            get { return _objStat; }
        }
        public string ObjStatString
        {
            get { return _objStat.ToString(); }
        }
        #endregion

        #region Constructores	    
        public classEventosLst()
        {
            this._objStat = Stat.New;
        }
        #endregion

        #region Metodos
        private void GetRecords()
        {
            LoadData(String.Format("SELECT * FROM  Eventos"));
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
                            classEventos info = new classEventos();
                            info.FillField(dr);
                            info.SetPreLoaded();
                            this._lstRecords.Add(info);
                        }
                    }
                    else
                    {
                        this._objStat = Stat.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Refresh()
        {
            this._lstRecords.Clear();
            GetRecords();
        }
        public void Clear()
        {
            this._lstRecords.Clear();
        }

        #endregion
    }
}
