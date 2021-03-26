<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="HospitalDetail.aspx.cs" Inherits="AdminPanel_Hospital_HospitalDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script type="text/javascript">
        function doctorEdit() {
            var myModal = new bootstrap.Modal(document.getElementById('doctorEdit'), {
                backdrop: 'static',
                keyboard: false
            })
            myModal.show()
        }

        function editUserNameDoctor() {
            var myModal = new bootstrap.Modal(document.getElementById('editUserNameDoctor'), {
                backdrop: 'static',
                keyboard: false
            })
            myModal.show()
        }

        function editPasswordDoctor() {
            var myModal = new bootstrap.Modal(document.getElementById('editPasswordDoctor'), {
                backdrop: 'static',
                keyboard: false
            })
            myModal.show()
        }

    </script>
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
                <h4 class="mt-2 mb-2 col-md-6 offset-md-3" style="color: white">
                    <asp:Label ID="lblHospitalName" runat="server"></asp:Label>
                    (<asp:Label ID="lblSpeciality" runat="server"></asp:Label>)
                </h4>
                <div class="col-md-3 backBtn">
                    <asp:LinkButton ID="lbEditHospital" runat="server" CssClass="btn btn-dark btn-pills " OnClick="lbEditHospital_Click"><i class="uil uil-edit"></i> Edit</asp:LinkButton>
                    <asp:LinkButton ID="lbBack" runat="server" CssClass="btn btn-dark btn-pills m-1 ms-3" OnClick="lbBack_Click"><i class="uil uil-step-backward"></i> Back</asp:LinkButton>
                    <%--<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark btn-pills m-1 ms-3" OnClick="btnBack_Click" />--%>
                </div>
            </div>
        </div>

        <div class="card border-0 rounded-0 p-5 mb-2 ">
            <div class="row">
                <div class="col-md-12 mb-4">
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                    <p class="text-muted" style="text-align: justify">
                        <asp:Label ID="lblOverview" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
                <div class="col-md-12 mb-4">
                    <h5 class="mb-0">Report: </h5>

                    <ul class="list-unstyled mt-4 row">
                        <asp:Repeater ID="rptReport" runat="server">
                            <ItemTemplate>
                                <li class="mt-2 col-md-5"><i class="uil uil-arrow-right text-primary"></i><%# Eval("ReportName") %></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="col-md-12 mb-4">

                    <div class="mb-0" style="display: flex; justify-content: space-between; padding: 0px 20px 0px 0px">
                        <h5>My Team: </h5>
                        <asp:LinkButton ID="lbDoctorAdd" runat="server" CssClass="btn btn-primary " OnClick="lbDoctorAdd_Click">+ Add</asp:LinkButton>
                    </div>

                    <asp:Panel ID="pnlNoDoctorFound" runat="server">
                        <div>
                            No doctor added in this Hospital. Please contact admin to add new doctor
                        </div>
                    </asp:Panel>

                    <div class="row row-cols-xl-5">

                        <asp:Repeater ID="rptDoctors" runat="server" OnItemCommand="rptDoctors_ItemCommand" OnItemDataBound="rptDoctors_ItemDataBound">
                            <ItemTemplate>


                                <div class="col-xl col-lg-4 col-md-6 mt-4">
                                    <div class="card team border-0 rounded shadow overflow-hidden" style="box-shadow: 0 0 3px rgb(52 58 64 / 30%) !important">
                                        <div class="team-img position-relative">
                                            <asp:Image ID="imgDoctorImage" runat="server" ImageUrl='<%# Eval("DoctorImage") %>' CssClass="img-fluid" />
                                        </div>
                                        <div class="card-body text-center">

                                            <asp:HiddenField ID="hfDoctorID" runat="server" Value='<%# Eval("DoctorID") %>'/>

                                            <a class="title text-dark h5 d-block mb-0"><%# Eval("DoctorName") %></a>
                                            <small class="text-muted speciality"><%# Eval("DepartmentName") %></small><br />
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

                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <!--end row-->

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
                                    <asp:HyperLink ID="hlAddress" runat="server" CssClass="link"></asp:HyperLink>
                                    <%--<a class="link">Rajkot, Rajkot, Rajkot, Rajkot,</a>--%>
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
                                    <asp:HyperLink ID="hlMobile" runat="server" CssClass="link"></asp:HyperLink>
                                    <%--<a href="tel:+152534-468-854" class="link">+152 534-468-854</a>--%>
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
                                    <asp:HyperLink ID="hlEmail" runat="server" CssClass="link"></asp:HyperLink>
                                    <%--<a href="mailto:contact@example.com" class="link">contact@example.com</a>--%>
                                </div>
                            </div>
                        </div>
                        <!--end col-->

                    </div>

                </div>
            </div>
        </div>
    </div>

    <!-- Ask User to edit profile or username or password -- Modal start -->
    <div class="modal fade" id="doctorEdit" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header border-bottom p-3">
                    <h5 class="modal-title" id="exampleModalLabel">Edit
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body p-3 pt-4">

                    <div class="row mb-3">

                        <div class="col-md-2 offset-md-2" style="text-align: center">
                            <asp:LinkButton ID="lbEditProfile" runat="server" CssClass="btn btn-primary btn-pills" OnClick="lbEditProfile_Click">Profile</asp:LinkButton>
                        </div>
                        <div class="col-md-1" style="text-align: center; padding: 10px">Or</div>
                        <div class="col-md-2" style="text-align: center">
                            <asp:LinkButton ID="lbEditUserName" runat="server" CssClass="btn btn-primary btn-pills" OnClick="lbEditUserName_Click">UserName</asp:LinkButton>
                        </div>
                        <div class="col-md-1" style="text-align: center; padding: 10px">Or</div>
                        <div class="col-md-2" style="text-align: center">
                            <asp:LinkButton ID="lbEditPassword" runat="server" CssClass="btn btn-primary btn-pills" OnClick="lbEditPassword_Click">Password</asp:LinkButton>
                        </div>

                    </div>
                    <!--end row-->
                </div>
            </div>
        </div>
    </div>
    <!-- Ask User to edit profile or username or password -- Modal End -->

    <!-- UserName Edit Modal start -->
    <div class="modal fade" id="editUserNameDoctor" tabindex="-1" aria-labelledby="exampleModalLabel1" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header border-bottom p-3">
                    <h5 class="modal-title" id="exampleModalLabel1">Edit UserName
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body p-3 pt-4">

                    <div class="row">
                        <div class="col-lg-12" style="margin: 10px auto">


                            <div class="row mb-3">
                                <div class="col-md-2 offset-md-2 labelAlign">
                                    Name
                                </div>
                                <div class="col-md-3" style="padding: 7px 0px 0px 16px;">
                                    Abc
                                </div>
                            </div>

                            <div class="mb-3 row">
                                <label class="form-label col-md-2 offset-md-2 labelAlign">UserName <span class="text-danger">*</span></label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="Enter UserName"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Enter City" ControlToValidate="txtCity" ValidationGroup="CityForm" CssClass="text-danger"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12" style="text-align: center">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" />
                            <asp:LinkButton ID="lbCancel" runat="server" CssClass="btn btn-danger btn-ml">Cancel</asp:LinkButton>
                        </div>
                        <!--end col-->
                    </div>
                    <!--end row-->
                </div>
            </div>
        </div>
    </div>
    <!-- UserName Edit Modal End -->

    <!-- UserName Edit Modal start -->
    <div class="modal fade" id="editPasswordDoctor" tabindex="-1" aria-labelledby="exampleModalLabel2" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header border-bottom p-3">
                    <h5 class="modal-title" id="exampleModalLabel2">Edit Password
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body p-3 pt-4">

                    <div class="row">
                        <div class="col-lg-12" style="margin: 10px auto">

                            <div class="row mb-3">
                                <div class="col-md-4 offset-md-1 labelAlign">
                                    Name
                                </div>
                                <div class="col-md-6" style="padding: 7px 0px 0px 16px;">
                                    Abc
                                </div>
                            </div>

                            <div class="mb-3 row">
                                <label class="form-label col-md-4 offset-md-1 labelAlign">Old Password <span class="text-danger">*</span></label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtOldPasssword" runat="server" class="form-control" placeholder="Enter Old Password" TextMode="Password"></asp:TextBox>
                                    <i id="oldPasswordStatus" class="uil uil-eye-slash passwordStatus" style="bottom : 2px !important"></i>
                                </div>
                            </div>

                            <div class="mb-3 row">
                                <label class="form-label col-md-4 offset-md-1 labelAlign">New Password <span class="text-danger">*</span></label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtNewPassword" runat="server" class="form-control" placeholder="Enter New Password" TextMode="Password"></asp:TextBox>
                                    <i id="newPasswordStatus" class="uil uil-eye-slash passwordStatus" style="bottom : 2px !important"></i>
                                </div>
                            </div>

                            <div class="mb-3 row">
                                <label class="form-label col-md-4 offset-md-1 labelAlign">Re-type New Password <span class="text-danger">*</span></label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtReTypeNewPassword" runat="server" class="form-control" placeholder="Enter Re-type New Password" TextMode="Password"></asp:TextBox>
                                    <i id="reTypenewPasswordStatus" class="uil uil-eye-slash passwordStatus" style="bottom : 2px !important"></i>
                                </div>
                            </div>

                        </div>
                        <div class="col-lg-12" style="text-align: center">
                            <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn btn-primary" />
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger btn-ml">Cancel</asp:LinkButton>
                        </div>
                        <!--end col-->
                    </div>
                    <!--end row-->
                </div>
            </div>
        </div>
    </div>
    <!-- UserName Edit Modal End -->

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
    <script type="text/javascript">

        $(document).ready(function () {

            $("#oldPasswordStatus").click(function () {

                if ($('[id$=txtOldPasssword]').attr("type") == "password") {
                    //Change type attribute
                    $('[id$=txtOldPasssword]').attr("type", "text");
                    $("#oldPasswordStatus").removeClass('uil uil-eye-slash').addClass('uil uil-eye');
                }
                else {
                    //Change type attribute
                    $('[id$=txtOldPasssword]').attr("type", "password");
                    $("#oldPasswordStatus").removeClass('uil uil-eye').addClass('uil uil-eye-slash');
                }
            });

        });

        $(document).ready(function () {

            $("#newPasswordStatus").click(function () {

                if ($('[id$=txtNewPassword]').attr("type") == "password") {
                    //Change type attribute
                    $('[id$=txtNewPassword]').attr("type", "text");
                    $("#newPasswordStatus").removeClass('uil uil-eye-slash').addClass('uil uil-eye');
                }
                else {
                    //Change type attribute
                    $('[id$=txtNewPassword]').attr("type", "password");
                    $("#newPasswordStatus").removeClass('uil uil-eye').addClass('uil uil-eye-slash');
                }
            });

        });

        $(document).ready(function () {

            $("#reTypenewPasswordStatus").click(function () {

                if ($('[id$=txtReTypeNewPassword]').attr("type") == "password") {
                    //Change type attribute
                    $('[id$=txtReTypeNewPassword]').attr("type", "text");
                    $("#reTypenewPasswordStatus").removeClass('uil uil-eye-slash').addClass('uil uil-eye');
                }
                else {
                    //Change type attribute
                    $('[id$=txtReTypeNewPassword]').attr("type", "password");
                    $("#reTypenewPasswordStatus").removeClass('uil uil-eye').addClass('uil uil-eye-slash');
                }
            });

        });
    </script>
</asp:Content>

