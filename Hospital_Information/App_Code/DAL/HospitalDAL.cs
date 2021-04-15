using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HospitalDAL
/// </summary>
namespace Hospital_Information.DAL
{
    public class HospitalDAL : DatabaseConfig
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

        public HospitalDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(HospitalENT entHospital)
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
                        objCmd.CommandText = "PR_Hospital_Insert";
                        objCmd.Parameters.Add("@HospitalID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@HospitalName", SqlDbType.VarChar).Value = entHospital.HospitalName;
                        objCmd.Parameters.Add("@Overview", SqlDbType.VarChar).Value = entHospital.Overview;
                        objCmd.Parameters.Add("@SpecialityID", SqlDbType.Int).Value = entHospital.SpecialityID;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entHospital.Address;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entHospital.CityID;
                        objCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = entHospital.Mobile;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entHospital.Email;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if(objCmd.Parameters["@HospitalID"] != null)
                        {
                            entHospital.HospitalID = Convert.ToInt32(objCmd.Parameters["@HospitalID"].Value);
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
        public Boolean Update(HospitalENT entHospital)
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
                        objCmd.CommandText = "PR_Hospital_UpdateByPK";
                        objCmd.Parameters.Add("@HospitalID", SqlDbType.Int).Value = entHospital.HospitalID;
                        objCmd.Parameters.Add("@HospitalName", SqlDbType.VarChar).Value = entHospital.HospitalName;
                        objCmd.Parameters.Add("@Overview", SqlDbType.VarChar).Value = entHospital.Overview;
                        objCmd.Parameters.Add("@SpecialityID", SqlDbType.Int).Value = entHospital.SpecialityID;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entHospital.Address;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entHospital.CityID;
                        objCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = entHospital.Mobile;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entHospital.Email;
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
                        objCmd.CommandText = "PR_Hospital_SelectAll";
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
        public HospitalENT SelectByPK(SqlInt32 HospitalID)
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
                        objCmd.CommandText = "PR_Hospital_SelectByPK";
                        objCmd.Parameters.Add("@HospitalID", SqlDbType.Int).Value = HospitalID;
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        HospitalENT entHospital = new HospitalENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["HospitalID"].Equals(DBNull.Value))
                                {
                                    entHospital.HospitalID = Convert.ToInt32(objSDR["HospitalID"]);
                                }
                                if (!objSDR["HospitalName"].Equals(DBNull.Value))
                                {
                                    entHospital.HospitalName = Convert.ToString(objSDR["HospitalName"]);
                                }
                                if (!objSDR["Overview"].Equals(DBNull.Value))
                                {
                                    entHospital.Overview = Convert.ToString(objSDR["Overview"]);
                                }
                                if (!objSDR["SpecialityID"].Equals(DBNull.Value))
                                {
                                    entHospital.SpecialityID = Convert.ToInt32(objSDR["SpecialityID"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entHospital.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entHospital.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }
                                if (!objSDR["Mobile"].Equals(DBNull.Value))
                                {
                                    entHospital.Mobile = Convert.ToString(objSDR["Mobile"]);
                                }
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entHospital.Email = Convert.ToString(objSDR["Email"]);
                                }
                            }
                        }
                        return entHospital;
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
        #endregion SelectByPK

        #region Select By CityID SpecialityID
        public DataTable SelectByCityIDSpecialityID(SqlString CityID, SqlString SpecialityID, SqlInt32 PageIndex, SqlInt32 PageSize)
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
                        objCmd.CommandText = "PR_Hospital_SelectByCityIDSpecialityID";
                        objCmd.Parameters.Add("@CityID", SqlDbType.VarChar).Value = CityID;
                        objCmd.Parameters.Add("@SpecialityID", SqlDbType.VarChar).Value = SpecialityID;
                        objCmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = PageIndex;
                        objCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
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
        #endregion Select By CityID SpecialityID

        #region Select By CityID SpecialityID RecordCount
        public Int32 SelectByCityIDSpecialityIDRecordCount(SqlString CityID, SqlString SpecialityID)
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
                        objCmd.CommandText = "PR_Hospital_SelectByCityIDSpecialityIDForRecordCount";
                        objCmd.Parameters.Add("@CityID", SqlDbType.VarChar).Value = CityID;
                        objCmd.Parameters.Add("@SpecialityID", SqlDbType.VarChar).Value = SpecialityID;
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        Int32 recordCount = 0;

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["RecordCount"].Equals(DBNull.Value))
                                {
                                    recordCount = Convert.ToInt32(objSDR["RecordCount"]);
                                }
                            }
                        }
                        return recordCount;
                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlEx)
                    {
                        Message = sqlEx.InnerException.Message;
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return 0;
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
        #endregion Select By CityID SpecialityID RecordCount

        #endregion Select Opertaion
    }
}