using Hospital_Information.DAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityBAL
/// </summary>
namespace Hospital_Information.BAL
{
    public class CityBAL
    {
        #region Local Variables

        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Local Variables

        #region Constructor

        public CityBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if(dalCity.Insert(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion Insert Opertaion

        #region Update Opertaion
        public Boolean Update(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Update(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion Update Opertaion

        #region Delete Opertaion
        public Boolean Delete(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Delete(CityID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion Delete Opertaion

        #region Select Opertaion

        #region SelectAll
        public DataTable SelectAll()
        {
            CityDAL dalCityDAL = new CityDAL();
            return dalCityDAL.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            CityDAL dalCityDAL = new CityDAL();
            return dalCityDAL.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public CityENT SelectByPK(SqlInt32 CityID)
        {
            CityDAL dalCityDAL = new CityDAL();
            return dalCityDAL.SelectByPK(CityID);
        }
        #endregion SelectByPK

        #endregion Select Opertaion

    }
}