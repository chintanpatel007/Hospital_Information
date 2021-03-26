<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="AdminList.aspx.cs" Inherits="AdminPanel_Admin_AdminList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link type="text/css" rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.24/css/dataTables.bootstrap5.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.24/js/dataTables.bootstrap5.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    Admin List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li class="breadcrumb-item active" aria-current="page">Admin
    </li>
    <li class="breadcrumb-item active" aria-current="page">Admin List
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-md-12 mt-4">
            <div class="card border-0 p-4 rounded shadow">
                <div id="divAdminAddButton" runat="server" class=" border-bottom text-end" style="padding: 0px 20px 10px 0px">
                    <asp:LinkButton ID="lbAdminAdd" runat="server" CssClass="btn btn-primary m-2" OnClick="lbAdminAdd_Click">+ Add</asp:LinkButton>
                </div>

                <div class="p-4 table-responsive ">

                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="lblErrorMessage"></asp:Label>

                    <asp:GridView ID="gvAdmin" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowDataBound="gvAdmin_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="Sr. no." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AdminName" HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlEdit" runat="server" CssClass="btn btn-pills btn-outline-primary" NavigateUrl='<%# "~/AdminPanel/Admin/AdminAddEdit.aspx?AdminID=" + Eval("AdminID").ToString() %>'><i class="uil uil-edit"></i></asp:HyperLink>
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="DeleteRecord" CommandArgument='<%# Eval("AdminID") %>' OnClientClick="return sweetAlertConfirm(this);" CssClass="btn btn-pills btn-outline-danger btn-ml-listPage" Visible='<%# Eval("AdminID").ToString().Trim() != Session["UserID"].ToString().Trim() && Convert.ToBoolean(Application["CheckAdmin"]) == true %>'><i class="uil uil-trash-alt"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=gvAdmin]').prepend($("<thead></thead>").append($('[id$=gvAdmin]').find("tr:first"))).DataTable({
                "lengthMenu": [[5, 10, 15, 20, -1], [5, 10, 15, 20, "All"]],
                "order": [[0, "asc"]],
                //"columns": [
                //    null,
                //    null,
                //    null,
                //    null,
                //    null,
                //    { "orderable": false }
                //],
            });
        });
    </script>
</asp:Content>

