<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="AdminAddEdit.aspx.cs" Inherits="AdminPanel_Admin_AdminAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript">

        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgAdminImagePreview.ClientID%>').prop('src', e.target.result)
                        .width(300);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    Admin Add/Edit
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li class="breadcrumb-item active" aria-current="page">Admin
    </li>
    <li class="breadcrumb-item active" aria-current="page">Admin Add/Edit
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-md-12 mt-4">
            <div class="card border-0 p-4 rounded shadow">



                <div class="row mt-4">

                    <div class="col-md-8 offset-md-2 mb-3">
                        <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
                    </div>

                    <div class="col-md-6 offset-md-1 row">

                        <div class="col-sm-4 form-label labelAlign">
                            Name
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:TextBox ID="txtAdminName" runat="server" CssClass="form-control" placeholder="Enter Admin Name"></asp:TextBox>
                        </div>

                        <div class="col-sm-4 form-label labelAlign">
                            Address
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address" Rows="3" TextMode="MultiLine"></asp:TextBox>
                        </div>

                        <div class="col-sm-4 form-label labelAlign">
                            Email
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                        </div>

                        <div class="col-sm-4 form-label labelAlign">
                            Mobile
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile"></asp:TextBox>
                        </div>

                        <div class="col-sm-4 form-label labelAlign">
                            Profile Image
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:FileUpload ID="fuAdminImage" runat="server" CssClass="form-control" onchange="ImagePreview(this);" accept=".png,.jpg,.jpeg," />
                        </div>
                    </div>


                    <div class="col-md-4 mb-3" style="text-align: center !important">
                        <asp:Image ID="imgAdminImagePreview" runat="server" ImageUrl="~/UploadedData/Images/Admin/avatar.png" CssClass="imagePreviewAdmin" />
                    </div>

                    <asp:Panel ID="pnlLoginDetail" runat="server">
                        <div class="col-md-6 offset-md-1 row mb-3">
                            <div class="col-sm-4 form-label labelAlign">
                                UserName
                            </div>
                            <div class="col-sm-8 mb-3">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-sm-4 form-label labelAlign">
                                Password
                            </div>
                            <div class="col-sm-8 mb-3">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>

                            <div class="col-sm-4 form-label labelAlign">
                                Re-type Password
                            </div>
                            <div class="col-sm-8 mb-3">
                                <asp:TextBox ID="txtReTypePassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>

                    <div class="col-md-12 mb-3" style="text-align: center">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        <asp:LinkButton ID="lbCancel" runat="server" CssClass="btn btn-danger btn-ml" OnClick="lbCancel_Click">Cancel</asp:LinkButton>
                    </div>


                </div>
            </div>
            <!--end col-->

        </div>
        <!--end row-->
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>

