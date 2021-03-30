<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanel.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="FrontPanel_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphbreadcrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!-- Start Hero -->
    <section class="bg-half-170 d-table w-100" id="home">
        <div class="bg-overlay bg-dark" style="opacity: 0.7;"></div>
        <div class="container">
            <div class="row justify-content-center mt-5">
                <div class="col-xl-10">
                    <div class="heading-title text-center">
                        <img src="images/logo-icon.png" class="avatar avatar-md-sm" alt="">
                        <h4 class="heading fw-bold text-white mt-3 mb-4">Booking Your Appointments</h4>
                        <p class="para-desc mx-auto text-white-50 mb-0">Great doctor if you need your family member to get effective immediate assistance, emergency treatment or a simple consultation.</p>

                        <div class="mt-4 pt-2">
                            <form class="rounded text-start shadow p-4 bg-white-50">
                                <div class="row align-items-center">
                                    <div class="col-md">
                                        <div class="input-group bg-white border rounded" style="opacity: 0.7;">
                                            <span class="input-group-text bg-white border-0"><i class="ri-map-pin-line text-primary h5 fw-normal mb-0"></i></span>
                                            <input name="name" id="location" type="text" class="form-control border-0" placeholder="Location:">
                                        </div>
                                    </div>
                                    <!--end col-->

                                    <div class="col-md mt-4 mt-sm-0">
                                        <div class="input-group bg-white border rounded" style="opacity: 0.7;">
                                            <span class="input-group-text bg-white border-0"><i class="ri-user-2-line text-primary h5 fw-normal mb-0"></i></span>
                                            <input name="name" id="name" type="text" class="form-control border-0" placeholder="Doctor Name:">
                                        </div>
                                    </div>
                                    <!--end col-->

                                    <div class="col-md-auto mt-4 mt-sm-0">
                                        <div class="d-grid d-md-block">
                                            <button type="submit" class="btn btn-primary">Search</button>
                                        </div>
                                    </div>
                                    <!--end col-->
                                </div>
                                <!--end row-->
                            </form>
                            <!--end form-->
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
    <!-- End Hero -->



    <!-- Start -->
    <section class="section bg-white pb-0">
        <div class="container">
            <div class="row align-items-center">
                hospital list here
            </div>
            <!--end row-->
        </div>
        <!--end container-->


    </section>
    <!-- End -->


    
    <!-- End -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>

