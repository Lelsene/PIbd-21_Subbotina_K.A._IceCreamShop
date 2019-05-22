<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCustomerBookings.aspx.cs" Inherits="IceCreamShopWeb.FormCustomerBookings" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        С
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        По
        <asp:Calendar ID="Calendar2" runat="server" Style="margin-bottom: 0px"></asp:Calendar>
        <br />
        <asp:Button ID="ButtonMake" runat="server" OnClick="ButtonMake_Click" Text="Сформировать" />
        <asp:Button ID="ButtonToPdf" runat="server" OnClick="ButtonToPdf_Click" Text="Сохранить в PDF" />
        <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="Назад" Height="25px" />
        <br />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" SplitterBackColor="" Style="margin-top: 0px" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
            <LocalReport ReportPath="RecordViewer.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetBookings" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCustomerBookings" TypeName="IceCreamShopServiceImplementDataBase.Implementations.RecordServiceDB">
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="model" Type="Object"></asp:Parameter>
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <div style="position: absolute; top: 480px; left: 21px;">
        </div>
    </form>
</body>
</html>
