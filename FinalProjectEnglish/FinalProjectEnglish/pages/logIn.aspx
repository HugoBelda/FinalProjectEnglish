<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="FinalProjectEnglish.pages.logIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link rel="stylesheet" href="../styles/logIn.css" />

</head>
<body>
    <header>
        <div class="logo">
            <img src="../img/logo.jpeg" alt="Logo">
        </div>
        <nav>
            <ul>
                <li><a href="../index.aspx">Home Page</a></li>
                <li><a href="login.aspx">Log In</a></li>
            </ul>
        </nav>
    </header>
    <form id="form" runat="server">
        <div id="loginContainer">
            <asp:Label ID="Label1" runat="server" Text="Please, log in:"></asp:Label>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Username: "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Password: "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Log in" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
