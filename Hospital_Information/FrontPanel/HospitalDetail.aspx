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
            <div class="row justify-content-center" style="margin-bottom: 50px">
                <div class="col-12">
                    <div class="section-title pb-2">
                        <p class="text-muted" style="text-align: justify">
                            Great doctor if you need your family member to get effective immediate assistance, emergency treatment or a simple consultation.Great doctor if you need your family member to get effective immediate assistance, emergency treatment or a simple consultation.Great doctor if you need your family member to get effective immediate assistance, emergency treatment or a simple consultation.Great doctor if you need your family member to get effective immediate assistance, emergency treatment or a simple consultation.Great doctor if you need your family member to get effective immediate assistance, emergency treatment or a simple consultation.Great doctor if you need your family member to get effective immediate assistance, emergency treatment or a simple consultation.
                        </p>
                    </div>
                </div>
                <!--end col-->
            </div>
            <div class="row justify-content-center" style="margin-bottom: 50px">
                <div class="col-12">
                    <div class="section-title pb-2">
                        <h4 class="title">Report : </h4>
                    </div>
                </div>
                <div class="col-12">
                    <ul class="list-unstyled mt-4 row">
                        <li class="mt-1 col-md-5"><i class="uil uil-arrow-right text-primary"></i>Women's health services</li>
                        <li class="mt-1 col-md-5"><i class="uil uil-arrow-right text-primary"></i>Pregnancy care</li>
                        <li class="mt-1 col-md-5"><i class="uil uil-arrow-right text-primary"></i>Surgical procedures</li>
                        <li class="mt-1 col-md-5"><i class="uil uil-arrow-right text-primary"></i>Specialty care</li>
                        <li class="mt-1 col-md-5"><i class="uil uil-arrow-right text-primary"></i>Conclusion</li>
                    </ul>
                </div>
                <!--end col-->
            </div>
            <div class="row justify-content-center">
                <div class="col-12">
                    <div class="section-title mb-4 pb-2">
                        <h4 class="title mb-4">Doctors : </h4>
                    </div>
                </div>
                <!--end col-->
            </div>
            <div class="row">
                <div class="col-xl-3 col-lg-3 col-md-6">
                    <div class="card team border-0 rounded shadow overflow-hidden">
                        <div class="team-img position-relative">
                            <img src="images/doctors/01.jpg" class="img-fluid" alt="">
                            <ul class="list-unstyled team-social mb-0">
                                <li><a href="#" class="btn btn-icon btn-pills btn-soft-primary"><i data-feather="facebook" class="icons"></i></a></li>
                                <li class="mt-2"><a href="#" class="btn btn-icon btn-pills btn-soft-primary"><i data-feather="linkedin" class="icons"></i></a></li>
                                <li class="mt-2"><a href="#" class="btn btn-icon btn-pills btn-soft-primary"><i data-feather="github" class="icons"></i></a></li>
                                <li class="mt-2"><a href="#" class="btn btn-icon btn-pills btn-soft-primary"><i data-feather="twitter" class="icons"></i></a></li>
                            </ul>
                        </div>
                        <div class="card-body content text-center">
                            <a href="#" class="title text-dark h5 d-block mb-0">Calvin Carlo</a>
                            <small class="text-muted speciality">Eye Care</small>
                        </div>
                    </div>
                </div>
                <!--end col-->


            </div>
            <!--end row-->
            <div class="row mt-100">
                <div class="row justify-content-center">
                    <div class="col-12">
                        <div class="section-title mb-4 pb-2">
                            <h4 class="title mb-4">Contact Details : </h4>
                        </div>
                    </div>
                    <!--end col-->
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="card features feature-primary text-center border-0">
                        <div class="icon text-center rounded-md mx-auto">
                            <i class="uil uil-phone h3 mb-0"></i>
                        </div>
                        <div class="card-body p-0 mt-3">
                            <h5>Phone</h5>
                            <p class="text-muted mt-3">Great doctor if you need your family member to get effective assistance</p>
                            <a href="tel:+152534-468-854" class="link">+152 534-468-854</a>
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
                            <p class="text-muted mt-3">Great doctor if you need your family member to get effective assistance</p>
                            <a href="mailto:contact@example.com" class="link">contact@example.com</a>
                        </div>
                    </div>
                </div>
                <!--end col-->

                <div class="col-lg-4 col-md-6 mt-4 mt-lg-0 pt-2 pt-lg-0">
                    <div class="card features feature-primary text-center border-0">
                        <div class="icon text-center rounded-md mx-auto">
                            <i class="uil uil-map-marker h3 mb-0"></i>
                        </div>
                        <div class="card-body p-0 mt-3">
                            <h5>Location</h5>
                            <p class="text-muted mt-3">
                                C/54 Northwest Freeway, Suite 558,
                                <br>
                                Houston, USA 485
                            </p>
                            <a href="#" class="link">View on Google map</a>
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

