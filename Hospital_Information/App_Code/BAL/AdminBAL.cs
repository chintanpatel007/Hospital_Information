using Hospital_Information.DAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminBAL
/// </summary>
namespace Hospital_Information.BAL
{
    public class AdminBAL
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

        public AdminBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(AdminENT entAdmin)
        {
            AdminDAL dalAdmin = new AdminDAL();

            if(dalAdmin.Insert(entAdmin))
            {
                return true;
            }
            else
            {
                Message = dalAdmin.Message;
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
        public DataTable SelectAll()
        {
            AdminDAL dalAdmin = new AdminDAL();
            return dalAdmin.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList

        #endregion SelectForDropDownList

        #region SelectByPK

        #endregion SelectByPK

        #region Select By UserName Password
        public AdminENT SelectByUserNamePassword(SqlString UserName, SqlString Password)
        {
            AdminDAL dalAdmin = new AdminDAL();
            return dalAdmin.SelectByUserNamePassword(UserName, Password);
        }
        #endregion Select By UserName Password

        #endregion Select Opertaion
    }
}