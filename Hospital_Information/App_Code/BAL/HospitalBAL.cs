using Hospital_Information.DAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HospitalBAL
/// </summary>
namespace Hospital_Information.BAL
{
    public class HospitalBAL
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

        public HospitalBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(HospitalENT entHospital)
        {
            HospitalDAL dalHospital = new HospitalDAL();

            if(dalHospital.Insert(entHospital))
            {
                return true;
            }
            else
            {
                Message = dalHospital.Message;
                return false;
            }
        }
        #endregion Insert Opertaion

        #region Update Opertaion
        public Boolean Update(HospitalENT entHospital)
        {
            HospitalDAL dalHospital = new HospitalDAL();

            if (dalHospital.Update(entHospital))
            {
                return true;
            }
            else
            {
                Message = dalHospital.Message;
                return false;
            }
        }
        #endregion Update Opertaion

        #region Delete Opertaion

        #endregion Delete Opertaion

        #region Select Opertaion

        #region SelectAll
        public DataTable SelectAll()
        {
            HospitalDAL dalHospital = new HospitalDAL();
            return dalHospital.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList

        #endregion SelectForDropDownList

        #region SelectByPK
        public HospitalENT SelectByPK(SqlInt32 HospitalID)
        {
            HospitalDAL dalHospital = new HospitalDAL();
            return dalHospital.SelectByPK(HospitalID);
        }
        #endregion SelectByPK

        #region SelectByCityIDSpecialityID
        public DataTable SelectByCityIDSpecialityID(SqlString CityID, SqlString SpecialityID, SqlInt32 PageIndex, SqlInt32 PageSize)
        {
            HospitalDAL dalHospital = new HospitalDAL();
            return dalHospital.SelectByCityIDSpecialityID(CityID, SpecialityID, PageIndex, PageSize);
        }
        #endregion SelectByCityIDSpecialityID

        #region Select By CityID SpecialityID RecordCount
        public Int32 SelectByCityIDSpecialityIDRecordCount(SqlString CityID, SqlString SpecialityID)
        {
            HospitalDAL dalHospital = new HospitalDAL();
            return dalHospital.SelectByCityIDSpecialityIDRecordCount(CityID, SpecialityID);
        }
        #endregion Select By CityID SpecialityID RecordCount

        #endregion Select Opertaion
    }
}