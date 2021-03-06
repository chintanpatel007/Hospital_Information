<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="SpecialityList.aspx.cs" Inherits="AdminPanel_Other_SpecialityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <link type="text/css" rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.24/css/dataTables.bootstrap5.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.24/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        function specialityAddEditModal() {
            var myModal = new bootstrap.Modal(document.getElementById('specialityAddEditModal'), {
                backdrop: 'static',
                keyboard: false
            })
            myModal.show()
        }

        function updateModalTitle() {
            document.getElementById('<%=lblModalTitle.ClientID %>').innerHTML = 'Speciality Add';
            document.getElementById('<%=txtSpeciality.ClientID %>').value = "";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" Runat="Server">
    Speciality List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" Runat="Server">
    <li class="breadcrumb-item active" aria-current="page">Other
    </li>
    <li class="breadcrumb-item active" aria-current="page">Speciality List
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="row">
        <div class="col-md-12 mt-4">
            <div class="card border-0 p-4 rounded shadow">
                <div class=" border-bottom" style="display: flex; justify-content: space-between; padding: 0px 20px 10px 0px">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="lblErrorMessage"></asp:Label>
                    <asp:LinkButton ID="lbSpecialityAdd" runat="server" CssClass="btn btn-primary m-2" data-bs-toggle="modal" data-bs-target="#specialityAddEditModal">+ Add</asp:LinkButton>
                </div>

                <div class="p-4 table-responsive ">

                    <asp:GridView ID="gvSpeciality" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-bordered" OnRowCommand="gvSpeciality_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="Sr. no." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="SpecialityName" HeaderText="Speciality" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbEdit" runat="server" CommandName="EditRecord" CommandArgument='<%# Eval("SpecialityID") %>' CssClass="btn btn-pills btn-outline-primary"><i class="uil uil-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="DeleteRecord" CommandArgument='<%# Eval("SpecialityID") %>' OnClientClick="return sweetAlertConfirm(this);" CssClass="btn btn-pills btn-outline-danger btn-ml-listPage"><i class="uil uil-trash-alt"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>

    <!-- Modal start -->
    <div class="modal fade" id="specialityAddEditModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header border-bottom p-3">
                    <h5 class="modal-title" id="exampleModalLabel">
                        <asp:Label ID="lblModalTitle" runat="server" Text="Speciality Add"></asp:Label>
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" OnClick="updateModalTitle();"></button>
                </div>
                <div class="modal-body p-3 pt-4">

                    <div class="row">
                        <div class="col-lg-12" style="margin: 10px auto">
                            <div class="mb-3 row">
                                <label class="form-label col-md-2 offset-md-2 labelAlign">Speciality <span class="text-danger">*</span></label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtSpeciality" runat="server" class="form-control" placeholder="Enter Speciality"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSpeciality" runat="server" ErrorMessage="Enter Speciality" ControlToValidate="txtSpeciality" ValidationGroup="SpecialityForm" CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12" style="text-align: center">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" ValidationGroup="SpecialityForm" OnClick="btnSave_Click" />
                            <asp:LinkButton ID="lbCancel" runat="server" CssClass="btn btn-danger btn-ml" OnClientClick="updateModalTitle();">Cancel</asp:LinkButton>
                        </div>
                        <!--end col-->
                    </div>
                    <!--end row-->
                </div>
            </div>
        </div>
    </div>
    <!-- Modal End -->
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=gvSpeciality]').prepend($("<thead></thead>").append($('[id$=gvSpeciality]').find("tr:first"))).DataTable({
                "lengthMenu": [[5, 10, 15, 20, -1], [5, 10, 15, 20, "All"]],
                "order": [[1, "asc"]],
                "columns": [
                    null,
                    null,
                    { "orderable": false }
                ],
            });
        });
    </script>
</asp:Content>

