<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanel.master" AutoEventWireup="true" CodeFile="HospitalList.aspx.cs" Inherits="FrontPanel_HospitalList" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" runat="Server">
    <link href="<%=ResolveClientUrl("~/Content/Pagination/pagination.css") %>" rel="stylesheet">

    <style type="text/css">
        #topnav {
            background-color: #3c3c3c !important;
        }

        td label {
            margin-left: 10px !important;
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
                        <h3 class="sub-title">Hospital List</h3>

                        <nav aria-label="breadcrumb" class="d-inline-block mt-3">
                            <ul class="breadcrumb bg-transparent mb-0">
                                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                <li class="breadcrumb-item active">Hospital List</li>
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
    <section class="section bg-white">

        <div class="container mt-100 mt-0">
            <div class="row ">

                <div class="col-lg-4 col-md-5 mt-4 mt-sm-0 pt-2 pt-sm-0">
                    <div class="card border-0 sidebar sticky-bar rounded shadow">
                        <div class="card-body">
                            <!-- SEARCH -->
                            <div class="widget mb-4">
                                <h5 class="widget-title">Filter</h5>
                            </div>
                            <!-- SEARCH -->

                            <!-- TAG CLOUDS -->
                            <div class="widget mb-4 pb-2">
                                <h5 class="widget-title">City</h5>
                                <asp:CheckBoxList ID="chklCity" runat="server" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="10" AutoPostBack="True" OnSelectedIndexChanged="chklCity_SelectedIndexChanged"></asp:CheckBoxList>
                                <h5 class="widget-title mt-3">Speciality</h5>
                                <asp:CheckBoxList ID="chklSpeciality" runat="server" RepeatDirection="Horizontal" RepeatColumns="2" CellPadding="10" AutoPostBack="True" OnSelectedIndexChanged="chklSpeciality_SelectedIndexChanged"></asp:CheckBoxList>
                            </div>
                            <!-- TAG CLOUDS -->

                        </div>
                    </div>
                </div>


                <div class="col-md-8" style="padding-left: 25px">
                    <div class="me-xl-3">
                        <div class="section-title mb-4 ">
                            <h4 class="title mb-4">Hospital List</h4>
                        </div>
                        <asp:Panel ID="pnlHospitalList" runat="server">
                            <asp:Repeater ID="rptHospital" runat="server">
                                <ItemTemplate>

                                    <asp:HyperLink ID="hlHospitalDetail" runat="server" NavigateUrl='<%# "~/FrontPanel/HospitalDetail.aspx?HospitalID=" + Eval("HospitalID").ToString() %>'>
                                    <div class="features feature-bg-primary d-flex bg-white p-4 rounded-md shadow position-relative overflow-hidden m-3">
                                        <h5 class="text-body titles"><%# Eval("RowNumber") %>.</h5>
                                        <div class="ms-3">
                                            <h5 class="text-body titles"><%# Eval("HospitalName") %></h5>
                                            <p class="text-muted para mb-0">
                                                City : <%# Eval("CityName") %> <br />
                                                Speciality : <%# Eval("SpecialityName") %>
                                            </p>
                                        </div>
                                    </div>
                                    </asp:HyperLink>

                                </ItemTemplate>
                            </asp:Repeater>

                            <div class="align-items-center" id="divPaging" runat="server">

                                <nav class="pagination-container">
                                    <div class="pagination">
                                        <asp:LinkButton ID="lbFirst" runat="server" Text="First" CssClass="pagination-newer" OnClick="lbFirst_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="lbPrevious" runat="server" Text="<<" CssClass="pagination-newer" OnClick="lbPrevious_Click"></asp:LinkButton>
                                        <asp:Repeater ID="rptPager" runat="server" OnItemCommand="rptPager_ItemCommand">
                                            <ItemTemplate>
                                                <span class="pagination-inner">
                                                    <asp:LinkButton ID="lbPages" runat="server" Text='<%#Eval("Text") %>' CommandName="ChangePage" CommandArgument='<%# Eval("Value") %>'></asp:LinkButton>
                                                </span>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <asp:LinkButton ID="lbNext" runat="server" Text=">>" CssClass="pagination-older" OnClick="lbNext_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="lbLast" runat="server" Text="Last" CssClass="pagination-older" OnClick="lbLast_Click"></asp:LinkButton>
                                    </div>
                                </nav>

                            </div>

                        </asp:Panel>
                        <asp:Panel ID="pnlHospitalEmpty" runat="server">
                            <h4 style="text-align: center">No Hospital Found for this Filter.</h4>
                        </asp:Panel>

                    </div>
                </div>
                <!--end col-->


            </div>
            <!--end row-->
        </div>
        <!--end container-->
    </section>
    <!--end section-->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScript" runat="Server">
    <script type="text/javascript">
        $('.pagination-inner a').on('click', function () {
            $(this).siblings().removeClass('pagination-active');
            $(this).addClass('pagination-active');
        })
    </script>
</asp:Content>

