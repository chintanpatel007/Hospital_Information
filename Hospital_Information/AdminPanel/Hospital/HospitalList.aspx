<%@ Page Title="Hospital List - Hospital Information" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="HospitalList.aspx.cs" Inherits="AdminPanel_Hospital_HospitalList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <link type="text/css" rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.24/css/dataTables.bootstrap5.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.24/js/dataTables.bootstrap5.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" Runat="Server">
    Hospital List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" Runat="Server">
    <li class="breadcrumb-item active" aria-current="page">
        Hosptial
    </li>
    <li class="breadcrumb-item active" aria-current="page">
        Hosptial List
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="row">
        <div class="col-md-12 mt-4">
            <div class="card border-0 p-4 rounded shadow">
                <div class=" border-bottom" style="display: flex; justify-content: space-between; padding: 0px 20px 10px 0px">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="lblErrorMessage"></asp:Label>
                    <%--<asp:LinkButton ID="lbHospitalAdd" runat="server" CssClass="btn btn-primary m-2" >+ Add</asp:LinkButton>--%>
                    <asp:HyperLink ID="hlHospitalAdd" runat="server" CssClass="btn btn-primary m-2" NavigateUrl="~/AdminPanel/Hospital/HospitalAddEdit.aspx">+ Add</asp:HyperLink>
                </div>

                <div class="p-4 table-responsive ">

                    <asp:GridView ID="gvHospital" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-bordered">
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="Sr. no." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="HospitalName" HeaderText="Hospital" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CityName" HeaderText="City" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="SpecialityName" HeaderText="Speciality" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-pills btn-outline-primary" NavigateUrl='<%# "~/AdminPanel/Hospital/HospitalDetail.aspx?HospitalID=" + Eval("HospitalID").ToString() %>'><i class="uil uil-eye"></i></asp:HyperLink>
                                    <asp:HyperLink ID="hlEdit" runat="server" CssClass="btn btn-pills btn-outline-primary btn-ml-listPage" NavigateUrl='<%# "~/AdminPanel/Hospital/HospitalAddEdit.aspx?HospitalID=" + Eval("HospitalID").ToString() %>'><i class="uil uil-edit "></i></asp:HyperLink>
                                    <%--<asp:LinkButton ID="lbEdit" runat="server" CommandName="EditRecord" CommandArgument='<%# Eval("HospitalID") %>' CssClass="btn btn-pills btn-outline-primary"><i class="uil uil-edit"></i></asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="DeleteRecord" CommandArgument='<%# Eval("HospitalID") %>' OnClientClick="return sweetAlertConfirm(this);" CssClass="btn btn-pills btn-outline-danger btn-ml-listPage"><i class="uil uil-trash-alt"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=gvHospital]').prepend($("<thead></thead>").append($('[id$=gvHospital]').find("tr:first"))).DataTable({
                "lengthMenu": [[5, 10, 15, 20, -1], [5, 10, 15, 20, "All"]],
                "order": [[0, "asc"]],
                "columns": [
                    null,
                    null,
                    null,
                    null,
                    null,
                    { "orderable": false }
                ],
            });
        });
    </script>
</asp:Content>

