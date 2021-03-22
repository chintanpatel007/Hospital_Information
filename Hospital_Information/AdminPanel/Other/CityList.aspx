<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link type="text/css" rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.24/css/dataTables.bootstrap5.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.24/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        function cityAddEditModal() {
            var myModal = new bootstrap.Modal(document.getElementById('cityAddEditModal'), {
                backdrop: 'static',
                keyboard: false
            })
            myModal.show()
        }

        function updateModalTitle() {
            document.getElementById('<%=lblModalTitle.ClientID %>').innerHTML = 'City Add';
            document.getElementById('<%=txtCity.ClientID %>').value = "";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    City List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li class="breadcrumb-item active" aria-current="page">Other
    </li>
    <li class="breadcrumb-item active" aria-current="page">City List
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-md-12 mt-4">
            <div class="card border-0 p-4 rounded shadow">
                <div class=" border-bottom" style="display: flex; justify-content: space-between; padding: 0px 20px 10px 0px">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="lblErrorMessage"></asp:Label>
                    <asp:LinkButton ID="lbCityAdd" runat="server" CssClass="btn btn-primary m-2" data-bs-toggle="modal" data-bs-target="#cityAddEditModal">+ Add</asp:LinkButton>
                </div>

                <div class="p-4 table-responsive ">

                    <asp:GridView ID="gvCity" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-bordered" OnRowCommand="gvCity_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="Sr. no." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CityName" HeaderText="City" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbEdit" runat="server" CommandName="EditRecord" CommandArgument='<%# Eval("CityID") %>' CssClass="btn btn-pills btn-outline-primary"><i class="uil uil-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID") %>' OnClientClick="return sweetAlertConfirm(this);" CssClass="btn btn-pills btn-outline-danger btn-ml-listPage"><i class="uil uil-trash-alt"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>

    <!-- Modal start -->
    <div class="modal fade" id="cityAddEditModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header border-bottom p-3">
                    <h5 class="modal-title" id="exampleModalLabel">
                        <asp:Label ID="lblModalTitle" runat="server" Text="City Add"></asp:Label>
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" OnClick="updateModalTitle();"></button>
                </div>
                <div class="modal-body p-3 pt-4">

                    <div class="row">
                        <div class="col-lg-12" style="margin: 10px auto">
                            <div class="mb-3 row">
                                <label class="form-label col-md-2 offset-md-2 labelAlign">City <span class="text-danger">*</span></label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtCity" runat="server" class="form-control" placeholder="Enter City"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Enter City" ControlToValidate="txtCity" ValidationGroup="CityForm" CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12" style="text-align: center">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="CityForm" />
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
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=gvCity]').prepend($("<thead></thead>").append($('[id$=gvCity]').find("tr:first"))).DataTable({
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

