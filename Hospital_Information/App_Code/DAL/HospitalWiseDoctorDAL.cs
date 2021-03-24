using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HospitalWiseDoctorDAL
/// </summary>
namespace Hospital_Information.DAL
{ 
    public class HospitalWiseDoctorDAL : DatabaseConfig
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

        public HospitalWiseDoctorDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(HospitalWiseDoctorENT entHospitalWiseDoctor)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_HospitalWiseDoctor_Insert";
                        objCmd.Parameters.Add("@HospitalWiseDoctorID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@HospitalID", SqlDbType.Int).Value = entHospitalWiseDoctor.HospitalID;
                        objCmd.Parameters.Add("@DoctorID", SqlDbType.Int).Value = entHospitalWiseDoctor.DoctorID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@HospitalWiseDoctorID"] != null)
                        {
                            entHospitalWiseDoctor.HospitalWiseDoctorID = Convert.ToInt32(objCmd.Parameters["@HospitalWiseDoctorID"].Value);
                        }

                        return true;
                    }
                    catch (SqlException sqlEx)
                    {
                        Message = sqlEx.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion Insert Opertaion
    }
}