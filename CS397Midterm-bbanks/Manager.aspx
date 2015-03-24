<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="CS397Midterm_bbanks.Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Welcome
        <asp:Label ID="lblUser" runat="server"></asp:Label>
        <br />
        <br />
        Open Bugs<br />
    
        <asp:DropDownList ID="ddlBugs" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBugs_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:DetailsView ID="dvDisplay" runat="server" Height="50px" Width="251px">
        </asp:DetailsView>
        <br />
        <asp:DropDownList ID="ddlDevs" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" />
    
        <br />
        <br />
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
    
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
