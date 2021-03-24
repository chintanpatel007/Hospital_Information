using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HospitalWiseReportDAL
/// </summary>
namespace Hospital_Information.DAL
{
    public class HospitalWiseReportDAL : DatabaseConfig
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

        public HospitalWiseReportDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(HospitalWiseReportENT entHospitalWiseReport)
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
                        objCmd.CommandText = "PR_HospitalWiseReportr_Insert";
                        objCmd.Parameters.Add("@HospitalWiseReportID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@HospitalID", SqlDbType.Int).Value = entHospitalWiseReport.HospitalID;
                        objCmd.Parameters.Add("@ReportID", SqlDbType.Int).Value = entHospitalWiseReport.ReportID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@HospitalWiseReportID"] != null)
                        {
                            entHospitalWiseReport.HospitalWiseReportID = Convert.ToInt32(objCmd.Parameters["@HospitalWiseReportID"].Value);
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
        
        #region DeleteByHospitalID
        public Boolean DeleteByHospitalID(SqlInt32 HospitalID)
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
                        objCmd.CommandText = "PR_HospitalWiseReport_DeleteByHospitalID";
                        objCmd.Parameters.Add("@HospitalID", SqlDbType.Int).Value = HospitalID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

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
        #endregion Delete DeleteByHospitalID

        #region Select Opertaion

        #region SelectByHospitalID
        public DataTable SelectByHospitalID(SqlInt32 HospitalID)
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
                        objCmd.CommandText = "PR_HospitalWiseReport_SelectByHospitalID";
                        objCmd.Parameters.Add("@HospitalID", SqlDbType.Int).Value = HospitalID;
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlEx)
                    {
                        Message = sqlEx.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
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
        #endregion SelectByHospitalID

        #endregion Select Opertaion
    }
}