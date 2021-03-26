<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckUser.aspx.cs" Inherits="AdminPanel_Authentication_CheckUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hospital information</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- favicon -->
    <link rel="shortcut icon" href="<%=ResolveClientUrl("~/UploadedData/images/favicon.ico") %>" />
    <!-- Bootstrap -->
    <link href="<%=ResolveClientUrl("~/Content/AdminPanel/css/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />

    <!-- Icons -->
    <link href="<%=ResolveClientUrl("~/Content/AdminPanel/css/materialdesignicons.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Content/AdminPanel/css/remixicon.css") %>" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/AdminPanel/css/line.css") %>" />

    <!-- Css -->
    <link href="<%=ResolveClientUrl("~/Content/AdminPanel/css/style.min.css") %>" rel="stylesheet" type="text/css" />
    <!-- custom Css -->
    <link href="<%=ResolveClientUrl("~/Content/AdminPanel/css/custom.css") %>" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .loginTitleLogo {
            height: 28px;
            margin: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Hero Start -->
        <%--<asp:Image ID="imgLogo" runat="server" Height="22" ImageUrl="~/UploadedData/images/logo.png" />--%>
        <section class="bg-home d-flex bg-light align-items-center" style="background: url('<%=ResolveClientUrl("~/UploadedData/images/bg/bg-lines-one.png") %>') center;">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-5 col-md-8">
                        <%--<img src="images/logo-dark.png" height="24" class="mx-auto d-block" alt="">--%>
                        <div class="mx-auto d-block" style="display: flex !important; justify-content: center;">
                            <asp:Image ID="imgLogo" runat="server" ImageUrl="~/UploadedData/images/logo.png" CssClass="loginTitleLogo" />
                            <h3>Hospital Information</h3>
                        </div>
                        <div class="card login-page bg-white shadow mt-4 rounded border-0">
                            <div class="card-body">
                                <h4 class="text-center mb-4">Who are you..?</h4>

                                <div class="row">
                                    <div class="col-md-12" style="text-align:center">
                                        <asp:LinkButton ID="lbAdmin" runat="server" CssClass="btn btn-outline-primary btn-lg btn-pills" OnClick="lbAdmin_Click">Admin</asp:LinkButton>
                                        <asp:LinkButton ID="lbDoctor" runat="server" CssClass="btn btn-outline-primary btn-lg btn-pills ms-3" OnClick="lbDoctor_Click">Doctor</asp:LinkButton>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <!---->
                    </div>
                    <!--end col-->
                </div>
                <!--end row-->
            </div>
            <!--end container-->
        </section>
        <!--end section-->
        <!-- Hero End -->
    </form>

    <!-- javascript -->
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/js/bootstrap.bundle.min.js") %>"></script>

    <!-- Icons -->
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/js/feather.min.js") %>"></script>
    <!-- Main Js -->
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/js/app-admin.js") %>"></script>
</body>
</html>
