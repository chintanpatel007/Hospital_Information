using Hospital_Information.BAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Authentication_Login : System.Web.UI.Page
{
    #region Page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if(Request.QueryString["user"] == "admin" || Convert.ToBoolean(Application["CheckAdmin"]) == true)
            {
                lblTitle.Text = "Admin";
            }
            else if (Request.QueryString["user"] == "doctor" || Convert.ToBoolean(Application["CheckDoctor"]) == true)
            {
                lblTitle.Text = "Doctor";
            }
            else
            {
                Response.Redirect("~/AdminPanel/Authentication/CheckUser.aspx");
            }
        }
    }
    #endregion Page load

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";

        if (txtUserName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Username <br/>";
        }

        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Password <br/>";
        }

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        else
        {
            lblErrorMessage.Text = "";
        }
        #endregion Server Side Validation

        #region Read Data
        SqlString UserName = SqlString.Null;
        SqlString Password = SqlString.Null;

        if (txtUserName.Text != "")
        {
            UserName = txtUserName.Text.ToString().Trim();
        }

        if (txtPassword.Text != "")
        {
            Password = txtPassword.Text.ToString().Trim();
        }
        #endregion Read Data

        if (Request.QueryString["user"] == "admin" || Convert.ToBoolean(Application["CheckAdmin"]) == true)
        {
            AdminBAL balAdmin = new AdminBAL();
            AdminENT entAdmin = new AdminENT();

            entAdmin = balAdmin.SelectByUserNamePassword(UserName, Password);

            if (!entAdmin.AdminID.IsNull)
            {
                if (!entAdmin.AdminID.IsNull)
                {
                    Session["UserID"] = Convert.ToString(entAdmin.AdminID.Value);
                }

                if (!entAdmin.UserName.IsNull)
                {
                    Session["UserName"] = Convert.ToString(entAdmin.UserName.Value);
                }

                if (!entAdmin.AdminImage.IsNull)
                {
                    Session["UserImage"] = Convert.ToString(entAdmin.AdminImage.Value);
                }

                string ReturnUrl = Convert.ToString(Request.QueryString["url"]);

                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    Response.Redirect(ReturnUrl);
                }
                else
                {
                    Response.Redirect("~/AdminPanel/Dashboard.aspx");
                }
            }
            else
            {
                lblErrorMessage.Text = "Eithe Username or password is Invalid, Try again...!";
            }
        }
        else if (Request.QueryString["user"] == "doctor" || Convert.ToBoolean(Application["CheckDoctor"]) == true)
        {
            DoctorBAL balDoctor = new DoctorBAL();
            DoctorENT entDoctor = new DoctorENT();

            entDoctor = balDoctor.SelectByUserNamePassword(UserName, Password);

            if (!entDoctor.DoctorID.IsNull)
            {
                if (!entDoctor.DoctorID.IsNull)
                {
                    Session["UserID"] = Convert.ToString(entDoctor.DoctorID.Value);
                }

                if (!entDoctor.DoctorName.IsNull)
                {
                    Session["UserName"] = Convert.ToString(entDoctor.DoctorName.Value);
                }

                if (!entDoctor.DoctorImage.IsNull)
                {
                    Session["UserImage"] = Convert.ToString(entDoctor.DoctorImage.Value);
                }

                if (!entDoctor.DepartmentID.IsNull)
                {
                    DepartmentENT entDepartment = new DepartmentENT();
                    DepartmentBAL balDepartment = new DepartmentBAL();

                    entDepartment = balDepartment.SelectByPK(Convert.ToInt32(entDoctor.DepartmentID.Value));
                    Session["DepartmentName"] = entDepartment.DepartmentName.Value;
                }

                string ReturnUrl = Convert.ToString(Request.QueryString["url"]);

                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    Response.Redirect(ReturnUrl);
                }
                else
                {
                    Response.Redirect("~/AdminPanel/Dashboard.aspx");
                }
            }
            else
            {
                lblErrorMessage.Text = "Eithe Username or password is Invalid, Try again...!";
            }
        }
        else
        {
            Response.Redirect("~/AdminPanel/Authentication/CheckUser.aspx");
        }
    }
}