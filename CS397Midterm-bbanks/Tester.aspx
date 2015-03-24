<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tester.aspx.cs" Inherits="CS397Midterm_bbanks.Tester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Welcome
        <asp:Label ID="lblUser" runat="server"></asp:Label>
        <br />
        <br />
        Subject:
        <asp:TextBox ID="tbxSubject" runat="server"></asp:TextBox>
        <br />
        <br />
        Priority
        <asp:DropDownList ID="ddlPriority" runat="server">
            <asp:ListItem>High</asp:ListItem>
            <asp:ListItem>Medium</asp:ListItem>
            <asp:ListItem>Low</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Description:<br />
        <asp:TextBox ID="tbxDescription" TextMode="MultiLine" runat="server" Height="102px" Width="284px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit Bug" />
        <br />
        <asp:Label ID="lblCount" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvDisplay" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
    </form>
</body>
</html>
