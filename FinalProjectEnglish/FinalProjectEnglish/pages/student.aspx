<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="FinalProjectEnglish.pages.student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Student Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../styles/student.css" />

</head>
<body>
    <div class="container">
        <header>
            <div class="logo">
                <img src="../img/logo.jpeg" alt="Logo">
            </div>
            <nav>
                <ul>
                    <li><a href="../index.aspx">Home Page</a></li>
                    <li><a href="../index.aspx">Log Out</a></li>
                </ul>
            </nav>
        </header>

        <form id="form1" runat="server">
            <asp:Label runat="server" ID="ErrorLabel"></asp:Label>

         
            <div>
                <p>Personal student's data:</p>
            </div>
            <div id="studentData">
                <div>
                    <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
                    <asp:Label ID="lblActualName" runat="server" Text=""></asp:Label>             
                    <asp:TextBox ID="txtName" runat="server" CssClass="alignedInput"></asp:TextBox>
                    

                </div>
                <div>
                    <asp:Label ID="lblSurname" runat="server" Text="Surname: "></asp:Label>
                    <asp:Label ID="lblActualSurname" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtSurname" runat="server" CssClass="alignedInput"></asp:TextBox>

                </div>
                <div>
                    <asp:Label ID="lblNationality" runat="server" Text="Nationality: "></asp:Label>
                    <asp:Label ID="actualNationality" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtNationalty" runat="server" CssClass="alignedInput"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lbldbo" runat="server" Text="Date of birth: "></asp:Label>
                    <asp:Label ID="actualDbo" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtDbo" runat="server" CssClass="alignedInput"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblIDNumber" runat="server" Text="ID Number: "></asp:Label>
                    <asp:Label ID="actualId" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtIDNumber" runat="server" CssClass="alignedInput"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblAddress" runat="server" Text="Address: "></asp:Label>
                    <asp:Label ID="actualAddress" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="alignedInput"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                    <asp:Label ID="actualEmail" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="alignedInput"></asp:TextBox>
                </div>
                <br />
                <asp:Button ID="btnUpdate" runat="server" Text="Update Data" OnClick="btnUpdateClick" />
                <asp:Label ID="Updated" runat="server" Text=""></asp:Label>

            </div>

            <div>
                <p>Your Subjects</p>
            </div>
            <asp:GridView ID="gvSubjects" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Subject ID" SortExpression="id" />
                    <asp:BoundField DataField="name" HeaderText="Subject Name" SortExpression="name" />
                    <asp:BoundField DataField="credits" HeaderText="Credits" SortExpression="credits" />
                    <asp:BoundField DataField="semester" HeaderText="Semester" SortExpression="semester" />
                    <asp:BoundField DataField="professor_name" HeaderText="Professor Name" SortExpression="professor_name" />
                    <asp:BoundField DataField="professor_surname" HeaderText="Professor Surname" SortExpression="professor_surname" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </form>
        </div>
</body>
</html>