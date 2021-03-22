using Hospital_Information.DAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentBAL
/// </summary>
namespace Hospital_Information.BAL
{
    public class DepartmentBAL
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

        public DepartmentBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(DepartmentENT entDepartment)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();

            if(dalDepartment.Insert(entDepartment))
            {
                return true;
            }
            else
            {
                Message = dalDepartment.Message;
                return false;
            }
        }
        #endregion Insert Opertaion

        #region Update Opertaion
        public Boolean Update(DepartmentENT entDepartment)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();

            if (dalDepartment.Update(entDepartment))
            {
                return true;
            }
            else
            {
                Message = dalDepartment.Message;
                return false;
            }
        }
        #endregion Update Opertaion

        #region Delete Opertaion
        public Boolean Delete(SqlInt32 DepartmentID)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();

            if (dalDepartment.Delete(DepartmentID))
            {
                return true;
            }
            else
            {
                Message = dalDepartment.Message;
                return false;
            }
        }
        #endregion Delete Opertaion

        #region Select Opertaion

        #region SelectAll
        public DataTable SelectAll()
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            return dalDepartment.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            return dalDepartment.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public DepartmentENT SelectByPK(SqlInt32 DepartmentID)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            return dalDepartment.SelectByPK(DepartmentID);
        }
        #endregion SelectByPK

        #endregion Select Opertaion

    }
}