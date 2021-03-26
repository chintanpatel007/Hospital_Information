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

    <!-- jquery -->
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/js/jquery-3.5.1.min.js") %>"></script>

    <!-- Css -->
    <link href="<%=ResolveClientUrl("~/Content/AdminPanel/css/style.min.css") %>" rel="stylesheet" type="text/css" />
    <!-- custom Css -->
    <link href="<%=ResolveClientUrl("~/Content/AdminPanel/css/custom.css") %>" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .loginTitleLogo {
            height: 28px;
            margin: 10px;
        }
        .btn-primary {
            height: 29px;
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
                                <h4 class="text-center" style="font-weight:400 !important">
                                    Login to 
                                    <asp:Label ID="lblTitle" runat="server" CssClass="fw-bold"></asp:Label>
                                    Panel
                                </h4>
                                <div class="mt-3 mb-3">
                                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
                                </div>
                                <div class="row mt-4 mb-2">
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
                                            <i id="passwordStatus" class="uil uil-eye-slash passwordStatus" style="bottom: 17px !important"></i>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 mt-2 mb-0" style="text-align: center">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-info" OnClick="btnLogin_Click" />
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

    <script type="text/javascript">

        $(document).ready(function () {

            $("#passwordStatus").click(function () {

                if ($('[id$=txtPassword]').attr("type") == "password") {
                    //Change type attribute
                    $('[id$=txtPassword]').attr("type", "text");
                    $("#passwordStatus").removeClass('uil uil-eye-slash').addClass('uil uil-eye');
                }
                else {
                    //Change type attribute
                    $('[id$=txtPassword]').attr("type", "password");
                    $("#passwordStatus").removeClass('uil uil-eye').addClass('uil uil-eye-slash');
                }
            });

        });
    </script>

    <!-- javascript -->
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/js/bootstrap.bundle.min.js") %>"></script>

    <!-- Icons -->
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/js/feather.min.js") %>"></script>
    <!-- Main Js -->
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/js/app-admin.js") %>"></script>

</body>
</html>
