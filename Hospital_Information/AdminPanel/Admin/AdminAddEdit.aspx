<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="AdminAddEdit.aspx.cs" Inherits="AdminPanel_Admin_AdminAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" Runat="Server">
    Admin Add/Edit
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" Runat="Server">
    <li class="breadcrumb-item active" aria-current="page">Admin
    </li>
    <li class="breadcrumb-item active" aria-current="page">Admin Add/Edit
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="row">
        <div class="col-md-12 mt-4">
            <div class="card border-0 p-4 rounded shadow">



                <div class="row mt-4">

                    <div class="col-md-6 offset-md-1 row">
                        <div class="col-sm-4 form-label labelAlign">
                            Name
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:TextBox ID="txtDoctorName" runat="server" CssClass="form-control" placeholder="Enter Doctor Name"></asp:TextBox>
                        </div>

                        <div class="col-sm-4 form-label labelAlign">
                            Department
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control department-name select2input">
                                <asp:ListItem Value="EY">Eye Care</asp:ListItem>
                                <asp:ListItem Value="G">Gynecologist</asp:ListItem>
                                <asp:ListItem Value="P">Psychotherapist</asp:ListItem>
                                <asp:ListItem Value="D">Dentist</asp:ListItem>
                                <asp:ListItem Value="U">Urologist</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-4 form-label labelAlign">
                            Experince
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:TextBox ID="txtExperince" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>

                        <div class="col-sm-4 form-label labelAlign">
                            Profile Image
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:FileUpload ID="fuDoctorImage" runat="server" CssClass="form-control" onchange="ImagePreview(this);" accept=".png,.jpg,.jpeg," />
                        </div>
                    </div>
                    

                    <div class="col-md-4 mb-3" style="text-align: center !important">
                        <asp:Image ID="imgDoctorImagePreview" runat="server" ImageUrl="~/UploadedData/Images/Avtar/avatar5.png" CssClass="imagePreview" />
                    </div>

                    <div class="col-md-6 offset-md-1 row mb-3">
                        <div class="col-sm-4 form-label labelAlign">
                            UserName
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>

                        <div class="col-sm-4 form-label labelAlign">
                            Password
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>

                        <div class="col-sm-4 form-label labelAlign">
                            Re-type Password
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-12 mb-3" style="text-align: center">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" />
                        <asp:LinkButton ID="lbCancel" runat="server" CssClass="btn btn-danger btn-ml" OnClick="lbCancel_Click">Cancel</asp:LinkButton>
                    </div>


                </div>
            </div>
            <!--end col-->

        </div>
        <!--end row-->
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" Runat="Server">
</asp:Content>

