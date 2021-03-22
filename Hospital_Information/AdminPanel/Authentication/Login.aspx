<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Authentication_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Hospital information</title>
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
                                <h4 class="text-center">Sign In</h4>

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="mb-3">
                                            <label class="form-label">Your Email <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-lg-12">
                                        <div class="mb-3">
                                            <label class="form-label">Password <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-lg-12">
                                        <div class="d-flex justify-content-between">
                                            <%--<div class="mb-3">
                                                <div class="form-check">
                                                    <input class="form-check-input align-middle" type="checkbox" value="" id="remember-check">
                                                    <label class="form-check-label" for="remember-check">Remember me</label>
                                                </div>
                                            </div>--%>
                                            <%--<asp:HyperLink ID="hlForgottenPassword" runat="server">Forgot password ?</asp:HyperLink>
                                            <a href="forgot-password.html" class="text-dark h6 mb-0">Forgot password ?</a>--%>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 mb-0" style="text-align: center">
                                        <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn btn-primary" />
                                    </div>

                                    <%--<div class="col-lg-12 mt-3 text-center">
                                        <h6 class="text-muted">Or</h6>
                                    </div>
                                    <!--end col-->

                                    <div class="col-6 mt-3">
                                        <div class="d-grid">
                                            <a href="#" class="btn btn-soft-primary"><i class="uil uil-facebook"></i>Facebook</a>
                                        </div>
                                    </div>
                                    <!--end col-->

                                    <div class="col-6 mt-3">
                                        <div class="d-grid">
                                            <a href="#" class="btn btn-soft-primary"><i class="uil uil-google"></i>Google</a>
                                        </div>
                                    </div>
                                    <!--end col-->

                                    <div class="col-12 text-center">
                                        <p class="mb-0 mt-3"><small class="text-dark me-2">Don't have an account ?</small> <a href="signup.html" class="text-dark fw-bold">Sign Up</a></p>
                                    </div>--%>
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
