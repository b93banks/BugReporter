<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Developer.aspx.cs" Inherits="CS397Midterm_bbanks.Developer" %>

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
        Bugs Assigned:<br />
    
        <asp:DropDownList ID="ddlBugs" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBugs_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:DetailsView ID="dvDisplay" runat="server" Height="50px" Width="300px">
        </asp:DetailsView>
        <br />
        Steps taken to fix problem:<br />
        <asp:TextBox ID="tbxChanges" runat="server" Height="74px" TextMode="MultiLine" Width="255px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnFix" runat="server" Text="Fixed" OnClick="btnFix_Click" />
    
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
        <br />
        <br />
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
    
    </div>
    </form>
</body>
</html>
