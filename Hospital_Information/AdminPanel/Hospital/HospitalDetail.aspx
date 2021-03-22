<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="HospitalDetail.aspx.cs" Inherits="AdminPanel_Hospital_HospitalDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    Hospital Detail
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li class="breadcrumb-item active" aria-current="page">Hosptial
    </li>
    <li class="breadcrumb-item active" aria-current="page">Hosptial Detail
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">

    <div class="card bg-white rounded shadow overflow-hidden mt-4 border-0">
        <div class="p-2 bg-primary bg-gradient">
            <div class="mt-1 pt-3 text-center row">
                <h4 class="mt-2 mb-2 col-md-8 offset-md-2" style="color: white">Dr. Calvin Carlo(speci...)
                </h4>
                <div class="col-md-2 backBtn">
                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark btn-pills m-1 " OnClick="btnBack_Click" />
                </div>
            </div>
        </div>

        <div class="card border-0 rounded-0 p-5 mb-2 ">
            <div class="row">
                <div class="col-md-12 mb-4">
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                    <p class="text-muted" style="text-align: justify">A gynecologist is a surgeon who specializes in the female reproductive system, which includes the cervix, fallopian tubes, ovaries, uterus, vagina and vulva. Menstrual problems, contraception, sexuality, menopause and infertility issues are diagnosed and treated by a gynecologist; most gynecologists also provide prenatal care, and some provide primary care.</p>
                </div>
                <div class="col-md-12 mb-4">
                    <h5 class="mb-0">Report: </h5>

                    <ul class="list-unstyled mt-4 row">
                        <li class="mt-2 col-md-5"><i class="uil uil-arrow-right text-primary"></i>Women's health services</li>
                        <li class="mt-2 col-md-5"><i class="uil uil-arrow-right text-primary"></i>Pregnancy care</li>
                        <li class="mt-2 col-md-5"><i class="uil uil-arrow-right text-primary"></i>Surgical procedures</li>
                        <li class="mt-2 col-md-5"><i class="uil uil-arrow-right text-primary"></i>Specialty care</li>
                        <li class="mt-2 col-md-5"><i class="uil uil-arrow-right text-primary"></i>Conclusion</li>
                    </ul>
                </div>
                <div class="col-md-12 mb-4">

                    <div class="mb-0" style="display: flex; justify-content: space-between; padding: 0px 20px 0px 0px">
                        <h5>My Team: </h5>
                        <asp:LinkButton ID="lbDoctorAdd" runat="server" CssClass="btn btn-primary " OnClick="lbDoctorAdd_Click">+ Add</asp:LinkButton>
                    </div>

                    <asp:Repeater ID="rptDoctors" runat="server" OnItemCommand="rptDoctors_ItemCommand">
                        <ItemTemplate>
                            <div class="row row-cols-xl-5">

                                <div class="col-xl col-lg-4 col-md-6 mt-4">
                                    <div class="card team border-0 rounded shadow overflow-hidden" style="box-shadow: 0 0 3px rgb(52 58 64 / 30%) !important">
                                        <div class="team-img position-relative">
                                            <asp:Image ID="imgDoctorImage" runat="server" ImageUrl='<%# Eval("DoctorImage") %>' CssClass="img-fluid" />
                                        </div>
                                        <div class="card-body text-center">
                                            <a class="title text-dark h5 d-block mb-0"><%# Eval("DoctorName") %></a>
                                            <small class="text-muted speciality"><%# Eval("Department") %></small><br />
                                            <small class="text-muted speciality">Experence : <%# Eval("Experince") %> years</small>
                                        </div>
                                        <div class="text-center" style="padding: 0rem 1.5rem 1.5rem 1.5rem">
                                            <%--<asp:HyperLink ID="hlEdit" runat="server" CssClass="btn btn-pills btn-outline-primary" NavigateUrl='<%# "~/AdminPanel/Hospital/DoctorAddEdit.aspx?HospitalID=" + Request.QueryString["HospitalID"].ToString() %>'><i class="uil uil-edit"></i></asp:HyperLink>--%>
                                            <%--<asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-pills btn-outline-primary" NavigateUrl='<%# "~/AdminPanel/Hospital/DoctorAddEdit.aspx?HospitalID=" + HttpUtility.UrlEncode(Eval("HospitalID").ToString()) %>'><i class="uil uil-edit"></i></asp:HyperLink>--%>
                                            <%--<asp:HyperLink ID="hlEdit" runat="server" CssClass="btn btn-pills btn-outline-primary" NavigateUrl='<%# "~/AdminPanel/Hospital/DoctorAddEdit.aspx?HospitalID=" + Request.QueryString["HospitalID"].ToString() +"&DoctorID=1" %>'><i class="uil uil-edit"></i></asp:HyperLink>--%>
                                            <asp:LinkButton ID="lbEdit" runat="server" CommandName="EditRecord" CommandArgument='<%# Eval("DoctorID") %>' CssClass="btn btn-pills btn-outline-primary"><i class="uil uil-edit"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lbDelete" runat="server" CommandName="DeleteRecord" CommandArgument='<%# Eval("DoctorID") %>' OnClientClick="return sweetAlertConfirm(this);" CssClass="btn btn-pills btn-outline-danger btn-ml-listPage"><i class="uil uil-trash-alt"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>


                                <!--end col-->

                            </div>
                            <!--end row-->
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-md-12 mb-4">
                    <div class="row">

                        <div class="col-md-12 mb-4">
                            <h5 class="mb-0">Contact Details:</h5>
                        </div>

                        <div class="col-lg-4 col-md-6 mt-4 mt-lg-0 pt-2 pt-lg-0">
                            <div class="card border-0 text-center features feature-primary">
                                <div class="icon text-center mx-auto rounded-md">
                                    <i class="uil uil-location-point h3 mb-0"></i>
                                </div>

                                <div class="card-body p-0 mt-4">
                                    <h5 class="title fw-bold">Address</h5>
                                    <a class="link">Rajkot, Rajkot, Rajkot, Rajkot,</a>
                                </div>
                            </div>
                        </div>
                        <!--end col-->

                        <div class="col-lg-4 col-md-6 mt-4 mt-lg-0 pt-2 pt-lg-0">
                            <div class="card border-0 text-center features feature-primary">
                                <div class="icon text-center mx-auto rounded-md">
                                    <i class="uil uil-phone h3 mb-0"></i>
                                </div>

                                <div class="card-body p-0 mt-4">
                                    <h5 class="title fw-bold">Phone</h5>
                                    <a href="tel:+152534-468-854" class="link">+152 534-468-854</a>
                                </div>
                            </div>
                        </div>
                        <!--end col-->

                        <div class="col-lg-4 col-md-6 mt-4 mt-lg-0 pt-2 pt-lg-0">
                            <div class="card border-0 text-center features feature-primary">
                                <div class="icon text-center mx-auto rounded-md">
                                    <i class="uil uil-envelope h3 mb-0"></i>
                                </div>

                                <div class="card-body p-0 mt-4">
                                    <h5 class="title fw-bold">Email</h5>
                                    <a href="mailto:contact@example.com" class="link">contact@example.com</a>
                                </div>
                            </div>
                        </div>
                        <!--end col-->

                    </div>

                </div>
            </div>
    </div>
    </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>

