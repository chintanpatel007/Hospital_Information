using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminDAL
/// </summary>
namespace Hospital_Information.DAL
{
    public class AdminDAL : DatabaseConfig
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

        public AdminDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(AdminENT entAdmin)
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
                        objCmd.CommandText = "PR_Admin_Insert";
                        objCmd.Parameters.Add("@AdminID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@AdminName", SqlDbType.VarChar).Value = entAdmin.AdminName;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entAdmin.Address;
                        objCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = entAdmin.Mobile;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entAdmin.Email;
                        objCmd.Parameters.Add("@AdminImage", SqlDbType.VarChar).Value = entAdmin.AdminImage;
                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = entAdmin.UserName;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = entAdmin.Password;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if(objCmd.Parameters["@AdminID"] != null)
                        {
                            entAdmin.AdminID = Convert.ToInt32(objCmd.Parameters["@AdminID"].Value);
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
        public DataTable SelectAll()
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
                        objCmd.CommandText = "PR_Admin_SelectAll";
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
        #endregion SelectAll

        #region SelectForDropDownList

        #endregion SelectForDropDownList

        #region SelectByPK

        #endregion SelectByPK

        #endregion Select Opertaion
    }
}