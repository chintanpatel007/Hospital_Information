<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="DoctorAddEdit.aspx.cs" Inherits="AdminPanel_Hospital_DoctorAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <!-- Select2 -->
    <link href="<%=ResolveClientUrl("~/Content/AdminPanel/css/select2.min.css") %>" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgDoctorImagePreview.ClientID%>').prop('src', e.target.result)
                        .width(300);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    Doctor Add/Edit
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li class="breadcrumb-item active" aria-current="page">Hosptial
    </li>
    <li class="breadcrumb-item active" aria-current="page">Doctor Add/Edit
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
                            Name <span class="text-danger">*</span>
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:TextBox ID="txtDoctorName" runat="server" CssClass="form-control" placeholder="Enter Doctor Name"></asp:TextBox>
                        </div>

                        <div class="col-sm-4 form-label labelAlign">
                            Department <span class="text-danger">*</span>
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control department-name select2input">
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-4 form-label labelAlign">
                            Experince
                        </div>
                        <div class="col-sm-8 mb-3">
                            <asp:TextBox ID="txtExperince" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="revExperince" ControlToValidate="txtExperince" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>--%>
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

                    <asp:Panel ID="pnlLoginDetail" runat="server">
                        <div class="col-md-6 offset-md-1 row mb-3">
                            <div class="col-sm-4 form-label labelAlign">
                                UserName <span class="text-danger">*</span>
                            </div>
                            <div class="col-sm-8 mb-3">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-sm-4 form-label labelAlign">
                                Password <span class="text-danger">*</span>
                            </div>
                            <div class="col-sm-8 mb-3">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>

                            <div class="col-sm-4 form-label labelAlign">
                                Re-type Password <span class="text-danger">*</span>
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
    <!-- javascript -->
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/js/select2.min.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/js/select2.init.js") %>"></script>
</asp:Content>

