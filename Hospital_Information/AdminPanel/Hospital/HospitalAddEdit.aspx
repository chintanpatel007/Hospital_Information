<%@ Page Title="Hospital Add/Edit - Hospital Information" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="HospitalAddEdit.aspx.cs" Inherits="AdminPanel_Hospital_HospitalAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <!-- Select2 -->
    <link href="<%=ResolveClientUrl("~/Content/AdminPanel/css/select2.min.css") %>" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=lstFruits]').multiselect({
                includeSelectAllOption: true
            });
        });

        function ValidateReport(source, args) {
            var chkListModules = document.getElementById('<%= chlReport.ClientID %>');
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    Hospital List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li class="breadcrumb-item active" aria-current="page">Hosptial
    </li>
    <li class="breadcrumb-item active" aria-current="page">Hosptial Add/Edit
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-md-12 mt-4">
            <div class="card border-0 p-4 rounded shadow">

                <div class="row mt-4">
                    <div class="col-md-12 mb-3">
                        <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                    <div class="col-md-6 mb-3">

                        <div class="mb-3 row">
                            <div class="col-sm-4 form-label labelAlign">
                                Hospital Name
                            </div>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtHospitalName" runat="server" CssClass="form-control" placeholder="Enter Hospital Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="mb-3 row">
                            <div class="col-sm-4 form-label labelAlign">
                                Overview
                            </div>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtOverview" runat="server" CssClass="form-control" placeholder="Enter Overview" TextMode="MultiLine" Rows="4"></asp:TextBox>
                            </div>
                        </div>

                        <div class="mb-3 row">
                            <div class="col-sm-4 form-label labelAlign">
                                Mobile
                            </div>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile"></asp:TextBox>
                            </div>
                        </div>

                        <div class="mb-3 row">
                            <div class="col-sm-4 form-label labelAlign">
                                Email
                            </div>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-6 mb-3">

                        <div class="mb-3 row">
                            <div class="col-sm-3 form-label labelAlign">
                                Speciality
                            </div>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlSpeciality" runat="server" CssClass="form-control department-name select2input"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="mb-3 row">

                            <div class="col-sm-3 form-label labelAlign">
                                City
                            </div>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control department-name select2input"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="mb-3 row">
                            <div class="col-sm-3 form-label labelAlign">
                                Address
                            </div>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </div>
                        </div>

                        <div class="mb-3 row">
                            <div class="col-sm-3 form-label labelAlign">
                                Report
                            </div>
                            <div class="col-sm-8">
                                <asp:CheckBoxList ID="chlReport" runat="server" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="5" CssClass="chlLabel"></asp:CheckBoxList>
                                <asp:CustomValidator runat="server" ID="cvReport" ClientValidationFunction="ValidateReport" ErrorMessage="Please Select at least one Report" ValidationGroup="HospitalForm"></asp:CustomValidator>
                            </div>
                        </div>

                    </div>

                    <div class="col-md-12 mb-3" style="text-align: center">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="HospitalForm" />
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

