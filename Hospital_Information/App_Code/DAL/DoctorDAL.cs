﻿using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DoctorDAL
/// </summary>
namespace Hospital_Information.DAL
{
    public class DoctorDAL : DatabaseConfig
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

        public DoctorDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(DoctorENT entDoctor)
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
                        objCmd.CommandText = "PR_Doctor_Insert";
                        objCmd.Parameters.Add("@DoctorID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@DoctorName", SqlDbType.VarChar).Value = entDoctor.DoctorName;
                        objCmd.Parameters.Add("@DoctorImage", SqlDbType.VarChar).Value = entDoctor.DoctorImage;
                        objCmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = entDoctor.DepartmentID;
                        objCmd.Parameters.Add("@Experince", SqlDbType.Int).Value = entDoctor.Experince;
                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = entDoctor.UserName;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = entDoctor.@Password;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@DoctorID"] != null)
                        {
                            entDoctor.DoctorID = Convert.ToInt32(objCmd.Parameters["@DoctorID"].Value);
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
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Doctor_SelectByHospitalID";
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

        #region SelectForDropDownList

        #endregion SelectForDropDownList

        #region SelectByPK

        #endregion SelectByPK

        #endregion Select Opertaion
    }
}