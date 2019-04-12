<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCreateBooking.aspx.cs" Inherits="IceCreamShopWeb.FormCreateBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 231px; width: 1027px">
    <form id="form1" runat="server">
    <div style="height: 217px">
    
        Покупатель&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownListCustomer" runat="server" Height="16px" Width="285px">
        </asp:DropDownList>
        <br />
        <br />
        Мороженое &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownListIceCream" runat="server" Height="16px" Width="285px">
        </asp:DropDownList>
        <br />
        <br />
        Количество&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxCount" runat="server" OnTextChanged="TextBoxCount_TextChanged" Width="274px" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        Сумма&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxSum" runat="server" Enabled="False" Width="274px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ButtonSave" runat="server" Text="Сохранить" OnClick="ButtonSave_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="ButtonCancel" runat="server" Text="Отмена" OnClick="ButtonCancel_Click" Height="25px" Width="63px" />
    
    </div>
    </form>
</body>
</html>
