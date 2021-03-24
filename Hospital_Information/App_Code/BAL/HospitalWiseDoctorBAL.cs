using Hospital_Information.DAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HospitalWiseDoctorBAL
/// </summary>
namespace Hospital_Information.BAL
{
    public class HospitalWiseDoctorBAL
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

        public HospitalWiseDoctorBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(HospitalWiseDoctorENT entHospitalWiseDoctor)
        {
            HospitalWiseDoctorDAL dalHospitalWiseDoctor = new HospitalWiseDoctorDAL();

            if(dalHospitalWiseDoctor.Insert(entHospitalWiseDoctor))
            {
                return true;
            }
            else
            {
                Message = dalHospitalWiseDoctor.Message;
                return false;
            }
        }
        #endregion Insert Opertaion
    }
}