using Hospital_Information.DAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DoctorBAL
/// </summary>
namespace Hospital_Information.BAL
{
    public class DoctorBAL
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

        public DoctorBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(DoctorENT entDoctor)
        {
            DoctorDAL DALDoctor = new DoctorDAL();

            if(DALDoctor.Insert(entDoctor))
            {
                return true;
            }
            else
            {
                Message = DALDoctor.Message;
                return false;
            }
        }
        #endregion Insert Opertaion

        #region Update Opertaion

        #endregion Update Opertaion

        #region Delete Opertaion

        #endregion Delete Opertaion

        #region Select Opertaion

        #region SelectAll
        //public DataTable SelectAll()
        //{

        //}
        #endregion SelectAll

        #region SelectByHospitalID
        public DataTable SelectByHospitalID(SqlInt32 HospitalID)
        {
            DoctorDAL dalDoctor = new DoctorDAL();
            return dalDoctor.SelectByHospitalID(HospitalID);
        }
        #endregion SelectByHospitalID

        #region SelectForDropDownList

        #endregion SelectForDropDownList

        #region SelectByPK

        #endregion SelectByPK

        #region Select By UserName Password
        public DoctorENT SelectByUserNamePassword(SqlString UserName, SqlString Password)
        {
            DoctorDAL dalDoctor = new DoctorDAL();
            return dalDoctor.SelectByUserNamePassword(UserName, Password);
        }
        #endregion Select By UserName Password

        #endregion Select Opertaion
    }
}