<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="FinalProjectEnglish.pages.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../styles/admin.css" />
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
            <h2>Students</h2>
            <asp:Button ID="btnNewUserStudent" runat="server" Text="New Student" OnClick="btnNewUserStudent_Click" />
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <h3>New Student</h3>
                <div id="newStudent">
                    <asp:Label ID="userNameStudent" runat="server" Text="User name: "></asp:Label>
                    <asp:TextBox ID="txtUserNameStudent" runat="server"></asp:TextBox>
                    <asp:Label ID="lblUsernameError" runat="server" ForeColor="Red"></asp:Label>

                    <br />
                    <asp:Label ID="passwordSudent" runat="server" Text="Password: "></asp:Label>
                    <asp:TextBox ID="txtPasswordStudent" runat="server"></asp:TextBox>
                    <asp:Label ID="lblPasswordError" runat="server" ForeColor="Red"></asp:Label>

                    <br />
                    <asp:Label ID="nameStudent" runat="server" Text="Name: "></asp:Label>
                    <asp:TextBox ID="txtNameStudent" runat="server"></asp:TextBox>
                    <asp:Label ID="lblNameError" runat="server" ForeColor="Red"></asp:Label>

                    <br />
                    <asp:Label ID="surnameStudent" runat="server" Text="Surname: "></asp:Label>
                    <asp:TextBox ID="txtSurnameStudent" runat="server"></asp:TextBox>
                    <asp:Label ID="lblSurnameError" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="dboStduent" runat="server" Text="Date of Birth: "></asp:Label>
                    <asp:TextBox ID="txtDboStudent" runat="server"></asp:TextBox>
                    <asp:Label ID="lblDboError" runat="server" ForeColor="Red"></asp:Label>

                    <br />
                    <asp:Label ID="nationalityStudent" runat="server" Text="Nationality: "></asp:Label>
                    <asp:TextBox ID="txtNationalityStudent" runat="server"></asp:TextBox>
                    <asp:Label ID="lblNationalityError" runat="server" ForeColor="Red"></asp:Label>

                    <br />
                    <asp:Label ID="idNumberStudent" runat="server" Text="ID Number: "></asp:Label>
                    <asp:TextBox ID="txtIdNumberStudent" runat="server"></asp:TextBox>
                    <asp:Label ID="lblIdNumberError" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="studentAddress" runat="server" Text="Address: "></asp:Label>
                    <asp:TextBox ID="txtStudentAddess" runat="server"></asp:TextBox>
                    <asp:Label ID="lblAddressError" runat="server" ForeColor="Red"></asp:Label>

                    <br />
                    <asp:Label ID="studentEmail" runat="server" Text="Email: "></asp:Label>
                    <asp:TextBox ID="txtStudentEmail" runat="server"></asp:TextBox>
                    <asp:Label ID="lblEmailError" runat="server" ForeColor="Red"></asp:Label>

                    <br />

                </div>
                <div>
                    <asp:Button ID="addStudent" runat="server" Text="Create new student" OnClick="addStudent_Click" />
                    <asp:Button ID="closePanelStudent" runat="server" Text="Close" OnClick="closePanelStudent_Click" />
                </div>
            </asp:Panel>
            <h3>Information about the students</h3>
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvStudents_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="surname" HeaderText="Surname" />
                    <asp:BoundField DataField="nationality" HeaderText="Nationality" />
                    <asp:BoundField DataField="id_number" HeaderText="ID-Number" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="day_of_birth" HeaderText="Date of birth" />
                    <asp:BoundField DataField="username" HeaderText="Username" />

                    <asp:CommandField ShowDeleteButton="True" HeaderText="Actions" ButtonType="Link" DeleteText="Delete" />
                </Columns>
            </asp:GridView>


            <h3>Add Student to Subject</h3>
            <div>
                <asp:Label ID="lblStudentUsername" runat="server" Text="Student Username: "></asp:Label>
                <asp:TextBox ID="txtStudentUsername" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblSubjectNameForStudent" runat="server" Text="Subject Name: "></asp:Label>
                <asp:TextBox ID="txtSubjectNameForStudent" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnAddStudentToSubject" runat="server" Text="Add Student to Subject" OnClick="btnAddStudentToSubject_Click" />
                <asp:Label ID="lblAddStudentMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
            </div>

            <hr />

            <h3>Remove Student from Subject</h3>
            <div>
                <asp:Label ID="lblRemoveStudentUsername" runat="server" Text="Student Username: "></asp:Label>
                <asp:TextBox ID="txtRemoveStudentUsername" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblRemoveSubjectNameForStudent" runat="server" Text="Subject Name: "></asp:Label>
                <asp:TextBox ID="txtRemoveSubjectNameForStudent" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnRemoveStudentFromSubject" runat="server" Text="Remove Student from Subject" OnClick="btnRemoveStudentFromSubject_Click" />
                <asp:Label ID="lblRemoveStudentMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
            </div>
            <hr />

            <br />
            <h2>Professors</h2>
            <asp:Button ID="btnNewUserProfessor" runat="server" Text="New Professor" OnClick="btnNewUserProfessor_Click" />
            <asp:Panel ID="pnlNewUser" runat="server" Visible="false">
                <h3>New Professor</h3>
                <div id="newProfessor">
                    <asp:Label ID="professorUsername" runat="server" Text="Username: "></asp:Label>
                    <asp:TextBox ID="txtProfessorUsername" runat="server"></asp:TextBox>
                    <asp:Label ID="lblProfessorUsernameError" runat="server" ForeColor="Red"></asp:Label>
                    <br />

                    <asp:Label ID="professorPassword" runat="server" Text="Password: "></asp:Label>
                    <asp:TextBox ID="txtProfessorPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="lblProfessorPasswordError" runat="server" ForeColor="Red"></asp:Label>
                    <br />

                    <asp:Label ID="professorName" runat="server" Text="Name: "></asp:Label>
                    <asp:TextBox ID="txtProfessorName" runat="server"></asp:TextBox>
                    <asp:Label ID="lblProfessorNameError" runat="server" ForeColor="Red"></asp:Label>
                    <br />

                    <asp:Label ID="professorSurname" runat="server" Text="Surname: "></asp:Label>
                    <asp:TextBox ID="txtProfessorSurname" runat="server"></asp:TextBox>
                    <asp:Label ID="lblProfessorSurnameError" runat="server" ForeColor="Red"></asp:Label>
                    <br />

                    <h4>Add Subject</h4>
                    <asp:Label ID="subjectId" runat="server" Text="Subject ID: "></asp:Label>
                    <asp:TextBox ID="txtSubjectId" runat="server"></asp:TextBox>
                    <asp:Label ID="lblSubjectIdError" runat="server" ForeColor="Red"></asp:Label>
                    <br />

                    <asp:Label ID="subjectName" runat="server" Text="Subject Name: "></asp:Label>
                    <asp:TextBox ID="txtSubjectName" runat="server"></asp:TextBox>
                    <asp:Label ID="lblSubjectNameError" runat="server" ForeColor="Red"></asp:Label>
                    <br />

                    <asp:Label ID="subjectCredits" runat="server" Text="Subject Credits: "></asp:Label>
                    <asp:TextBox ID="txtSubjectCredits" runat="server"></asp:TextBox>
                    <asp:Label ID="lblSubjectCreditsError" runat="server" ForeColor="Red"></asp:Label>
                    <br />

                    <asp:Label ID="subjectSemester" runat="server" Text="Subject Semester: "></asp:Label>
                    <asp:TextBox ID="txtSubjectSemester" runat="server"></asp:TextBox>
                    <asp:Label ID="lblSubjectSemesterError" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </div>

                <div>
                    <asp:Button ID="newProfessorButton" runat="server" Text="Create New Professor" OnClick="newProfessorButton_Click" />
                    <asp:Button ID="CancelProfessor" runat="server" Text="Cancel" OnClick="CancelProfessor_Click" />
                </div>
            </asp:Panel>
            <h3>Information about professors</h3>
            <asp:GridView ID="gvProfessors" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="surname" HeaderText="Surname" />
                </Columns>
            </asp:GridView>

            <h3>View Subjects</h3>
            <asp:GridView ID="gvViewSubjects" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Subject Name" />
                    <asp:BoundField DataField="credits" HeaderText="Credits" />
                    <asp:BoundField DataField="semester" HeaderText="Semester" />
                    <asp:BoundField DataField="professor_name" HeaderText="Professor Name" />
                    <asp:BoundField DataField="professor_surname" HeaderText="Professor Surname" />
                </Columns>
            </asp:GridView>

            <footer>
                <p>&copy; 2023 HC University. All rights reserved.</p>
            </footer>
        </div>
    </form>
</body>
</html>
