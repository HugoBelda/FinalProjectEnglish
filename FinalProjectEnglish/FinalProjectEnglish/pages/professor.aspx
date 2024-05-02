<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="professor.aspx.cs" Inherits="FinalProjectEnglish.pages.professor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Professor Information</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../styles/professor.css" />
</head>
<body>
    <form id="form1" runat="server">
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


        <div>
            <asp:Label runat="server" ID="ErrorLabel"></asp:Label>
            <h2>Information about your subjetcs</h2>
            <asp:GridView ID="gvProfessorSubjects" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                OnRowCommand="gvProfessorSubjects_RowCommand" DataKeyNames="id">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Subject Name" SortExpression="name" />
                    <asp:BoundField DataField="credits" HeaderText="Credits" SortExpression="credits" />
                    <asp:BoundField DataField="semester" HeaderText="Semester" SortExpression="semester" />
                    <asp:TemplateField HeaderText="View Students">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="View Students" CommandName="ViewStudents" CommandArgument='<%# Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


            <br />

            <asp:GridView ID="gvStudentsInSubject" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Student Name" SortExpression="name" />
                    <asp:BoundField DataField="surname" HeaderText="Student Surname" SortExpression="surname" />
                    <asp:BoundField DataField="id_number" HeaderText="Id Number" SortExpression="id_number" />
                    <asp:BoundField DataField="email" HeaderText="Student email" SortExpression="email" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
