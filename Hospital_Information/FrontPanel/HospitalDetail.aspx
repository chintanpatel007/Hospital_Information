<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanel.master" AutoEventWireup="true" CodeFile="HospitalDetail.aspx.cs" Inherits="FrontPanel_HospitalDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" runat="Server">
    <style type="text/css">
        #topnav {
            background-color: #3c3c3c !important;
        }
    </style>
    <script type="text/javascript">
        window.onload = function () {
            $(".navbarFrontpanel").css("background-color", "black");
        };
        $(document).ready(function () {
            $(window).on("scroll", function () {
                var wn = $(window).scrollTop();
                if (wn > 90) {
                    document.getElementById("topnav").setAttribute("style", "background-color: white !important;");
                }
                else {
                    document.getElementById("topnav").setAttribute("style", "background-color: #3c3c3c !important;");
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphbreadcrumb" runat="Server">
    <!-- Start Hero -->
    <section class="bg-half-150 d-table w-100" style="background-color: #acacac !important; padding: 55px 0px 25px 0px!important">
        <div class="container">
            <div class="row mt-5 justify-content-center">
                <div class="col-12">
                    <div class="section-title text-center d-flex justify-content-between">
                        <h3 class="sub-title">Hospital Detail</h3>

                        <nav aria-label="breadcrumb" class="d-inline-block mt-3">
                            <ul class="breadcrumb bg-transparent mb-0">
                                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                <li class="breadcrumb-item active">Hospital Detail</li>
                            </ul>
                        </nav>
                    </div>
                </div>
                <!--end col-->
            </div>
            <!--end row-->
        </div>
        <!--end container-->
    </section>
    <!--end section-->
    <!-- End Hero -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageContent" runat="Server">

    <!-- Start -->
    <section class="section">
        <div class="container">
            <div class="row">
                <div class="col-md-8 offset-md-2">
                    <h2 class="text-center mb-4">
                        <asp:Label ID="lblHospitalName" runat="server"></asp:Label>
                        (<asp:Label ID="lblSpeciality" runat="server"></asp:Label>)
                    </h2>
                </div>
                <div class="col-md-2" style="text-align: right">
                    <asp:HyperLink ID="hlBack" runat="server" CssClass="btn btn-dark btn-pills m-1 ms-3" NavigateUrl="~/FrontPanel/HospitalList.aspx"><i class="uil uil-step-backward"></i> Back</asp:HyperLink>
                </div>
            </div>
            <div class="row justify-content-center" style="margin-bottom: 30px">

                <div class="col-12">
                    <div class="section-title pb-2">
                        <p class="text-muted" style="text-align: justify">
                            <asp:Label ID="lblOverview" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </div>
                <!--end col-->
            </div>
            <div class="row justify-content-center" style="margin-bottom: 30px">
                <div class="col-12">
                    <div class="section-title pb-2">
                        <h3 class="title">Report : </h3>
                    </div>
                </div>
                <div class="col-12">
                    <ul class="list-unstyled mt-4 row">
                        <asp:Repeater ID="rptReport" runat="server">
                            <ItemTemplate>
                                <li class="mt-2 col-md-5"><i class="uil uil-arrow-right text-primary"></i><%# Eval("ReportName") %></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <!--end col-->
            </div>
            <div class="row justify-content-center">
                <div class="col-12">
                    <div class="section-title mb-4 pb-2">
                        <h3 class="title mb-4">Doctors : </h3>
                    </div>
                    <asp:Panel ID="pnlNoDoctorFound" runat="server">
                        <div>
                            No doctor added in this Hospital. Please contact admin to add new doctor
                        </div>
                    </asp:Panel>
                </div>
                <!--end col-->
            </div>
            <div class="row">

                <asp:Repeater ID="rptDoctors" runat="server">
                    <ItemTemplate>
                        <div class="col-xl-3 col-lg-3 col-md-6">
                            <div class="card team border-0 rounded shadow overflow-hidden">
                                <div class="team-img position-relative">
                                    <asp:Image ID="imgDoctorImage" runat="server" ImageUrl='<%# Eval("DoctorImage") %>' CssClass="img-fluid w-100" />
                                </div>
                                <div class="card-body content text-center">
                                    <a class="title text-dark h5 d-block mb-0"><%# Eval("DoctorName") %></a>
                                    <small class="text-muted speciality"><%# Eval("DepartmentName") %></small><br />
                                    <small class="text-muted speciality">Experence : <%# Eval("Experince") %> years</small>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


            </div>
            <!--end row-->
            <div class="row mt-100">
                <div class="row justify-content-center">
                    <div class="col-12">
                        <div class="section-title mb-4 pb-2">
                            <h3 class="title mb-4">Contact Details : </h3>
                        </div>
                    </div>
                    <!--end col-->
                </div>

                <div class="col-lg-4 col-md-6 mt-4 mt-lg-0 pt-2 pt-lg-0">
                    <div class="card features feature-primary text-center border-0">
                        <div class="icon text-center rounded-md mx-auto">
                            <i class="uil uil-map-marker h3 mb-0"></i>
                        </div>
                        <div class="card-body p-0 mt-3">
                            <h5>Address</h5>
                            <asp:HyperLink ID="hlAddress" runat="server" CssClass="link"></asp:HyperLink>
                        </div>
                    </div>
                </div>
                <!--end col-->

                <div class="col-lg-4 col-md-6">
                    <div class="card features feature-primary text-center border-0">
                        <div class="icon text-center rounded-md mx-auto">
                            <i class="uil uil-phone h3 mb-0"></i>
                        </div>
                        <div class="card-body p-0 mt-3">
                            <h5>Phone</h5>
                            <asp:HyperLink ID="hlMobile" runat="server" CssClass="link"></asp:HyperLink>
                        </div>
                    </div>
                </div>
                <!--end col-->

                <div class="col-lg-4 col-md-6 mt-4 mt-sm-0 pt-2 pt-sm-0">
                    <div class="card features feature-primary text-center border-0">
                        <div class="icon text-center rounded-md mx-auto">
                            <i class="uil uil-envelope h3 mb-0"></i>
                        </div>
                        <div class="card-body p-0 mt-3">
                            <h5>Email</h5>
                            <asp:HyperLink ID="hlEmail" runat="server" CssClass="link"></asp:HyperLink>
                        </div>
                    </div>
                </div>
                <!--end col-->

            </div>
            <!--end row-->
        </div>
        <!--end container-->


    </section>
    <!--end section-->
    <!-- End -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>

