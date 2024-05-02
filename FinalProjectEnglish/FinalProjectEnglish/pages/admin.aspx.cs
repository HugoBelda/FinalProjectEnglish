using FinalProjectEnglish.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectEnglish.pages
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["username"] as string;
            if (username == null)
            {
                Response.Redirect("logIn.aspx");
            }
            if (!IsPostBack)
            {
                LoadProfessorsGrid();
                LoadStudentsGrid();
                LoadViewSubjectsGrid();
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        protected void addStudent_Click(object sender, EventArgs e)
        {
            string DBpath = Server.MapPath("~/BBDD.db");
            string username = txtUserNameStudent.Text;
            string password_hash = txtPasswordStudent.Text;
            string dbo = txtDboStudent.Text;
            string nationality = txtNationalityStudent.Text;
            string IDNumber = txtIdNumberStudent.Text;
            string address = txtStudentAddess.Text;
            string email = txtStudentEmail.Text;
            string name = txtNameStudent.Text;
            string surname = txtSurnameStudent.Text;

            if (!Regex.IsMatch(username, "^[a-zA-Z0-9]{4,}$"))
            {
                lblUsernameError.Text = "Invalid username.";
                return;
            }
            if (password_hash.Length < 4)
            {
                lblPasswordError.Text = "Invalid password.";
                return;
            }
            if (!Regex.IsMatch(name, "^[a-zA-Z]+$"))
            {
                lblNameError.Text = "Invalid name.";
                return;
            }
            if (!Regex.IsMatch(surname, "^[a-zA-Z]+$"))
            {
                lblSurnameError.Text = "Invalid surname.";
                return;
            }
            if (!Regex.IsMatch(IDNumber, "^[0-9]{8}[A-Z]$"))
            {
                lblIdNumberError.Text = "Invalid ID number.";
                return;
            }
            if (!Regex.IsMatch(nationality, "^[a-zA-Z]+$"))
            {
                lblNationalityError.Text = "Invalid nationality.";
                return;
            }
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                lblEmailError.Text = "Invalid email.";
                return;
            }
            if (!Regex.IsMatch(dbo, @"^\d{2}/\d{2}/\d{4}$"))
            {
                lblDboError.Text = "Invalid date of birth format.";
                return;
            }
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password_hash))
            {
                return;
            }
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password_hash));
                password_hash = BitConverter.ToString(data).Replace("-", string.Empty);
            }
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
                {
                    conn.Open();

                    string query = Query.newUserStudent;
                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@username", username);
                        comm.Parameters.AddWithValue("@password_hash", password_hash);
                        comm.Parameters.AddWithValue("@ROLE", "student");
                        comm.ExecuteNonQuery();
                    }
                    long userId;
                    query = "SELECT last_insert_rowid()";
                    using (SQLiteCommand getIdCommand = new SQLiteCommand(query, conn))
                    {
                        userId = (long)getIdCommand.ExecuteScalar();
                    }
                    using (SQLiteCommand comm = new SQLiteCommand(Query.newStudent, conn))
                    {
                        comm.Parameters.AddWithValue("@user_id", userId);
                        comm.Parameters.AddWithValue("@name", name);
                        comm.Parameters.AddWithValue("@surname", surname);
                        comm.Parameters.AddWithValue("@dbo", dbo);
                        comm.Parameters.AddWithValue("@IDNumber", IDNumber);
                        comm.Parameters.AddWithValue("@address", address);
                        comm.Parameters.AddWithValue("@email", email);
                        comm.Parameters.AddWithValue("@nationality", nationality);
                        comm.ExecuteNonQuery();
                    }
                }
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed"))
                {
                    lblEmailError.Text = "Email already exists.";
                    lblIdNumberError.Text = "ID Number already exists.";
                    lblUsernameError.Text = "Username already exists.";
                }
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        protected void newProfessorButton_Click(object sender, EventArgs e)
        {
            string DBpath = Server.MapPath("~/BBDD.db");
            string username1 = txtProfessorUsername.Text;
            string password_hash1 = txtProfessorPassword.Text;
            string name1 = txtProfessorName.Text;
            string surname1 = txtProfessorSurname.Text;
            string subjectId = txtSubjectId.Text;
            string subjcetName = txtSubjectName.Text;
            string subjectCredits = txtSubjectCredits.Text;
            string subjectSemester = txtSubjectSemester.Text;
            if (string.IsNullOrEmpty(username1) || string.IsNullOrEmpty(password_hash1))
            {
                return;
            }
            if (!Regex.IsMatch(username1, "^[a-zA-Z0-9]{3,}$"))
            {
                lblProfessorUsernameError.Text = "Invalid username.";
                return;
            }
            if (password_hash1.Length < 4)
            {
                lblProfessorPasswordError.Text = "Invalid password.";
                return;
            }
            if (!Regex.IsMatch(name1, "^[a-zA-Z]+$"))
            {
                lblProfessorNameError.Text = "Invalid name.";
                return;
            }
            if (!Regex.IsMatch(surname1, "^[a-zA-Z]+$"))
            {
                lblProfessorSurnameError.Text = "Invalid surname.";
                return;
            }
            if (!Regex.IsMatch(subjectId, "^[0-9]+$"))
            {
                lblSubjectIdError.Text = "Invalid subject ID.";
                return;
            }
          
            if (!Regex.IsMatch(subjectCredits, "^[0-9]+$"))
            {
                lblSubjectCreditsError.Text = "Invalid subject credits.";
                return;
            }
            if (!Regex.IsMatch(subjectSemester, "^[AB]$"))
            {
                lblSubjectSemesterError.Text = "Invalid subject semester. Must be 'A' or 'B'.";
                return;
            }

            if (string.IsNullOrEmpty(username1) || string.IsNullOrEmpty(password_hash1))
            {
                return;
            }
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password_hash1));
                password_hash1 = BitConverter.ToString(data).Replace("-", string.Empty);
            }
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                string query = Query.newUserProfessor;
                using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@username", username1);
                    comm.Parameters.AddWithValue("@password_hash", password_hash1);
                    comm.Parameters.AddWithValue("@ROLE", "professor");
                    comm.ExecuteNonQuery();
                }
                long userId;
                query = "SELECT last_insert_rowid()";
                using (SQLiteCommand getIdCommand = new SQLiteCommand(query, conn))
                {
                    userId = (long)getIdCommand.ExecuteScalar();
                }
                using (SQLiteCommand comm = new SQLiteCommand(Query.newProfessor, conn))
                {
                    comm.Parameters.AddWithValue("@user_id", userId);
                    comm.Parameters.AddWithValue("@name", name1);
                    comm.Parameters.AddWithValue("@surname", surname1);
                    comm.ExecuteNonQuery();
                }

                using (SQLiteCommand comm = new SQLiteCommand(Query.newProfessorSubject, conn))
                {
                    comm.Parameters.AddWithValue("id", subjectId);
                    comm.Parameters.AddWithValue("@name", subjcetName);
                    comm.Parameters.AddWithValue("@credits", subjectCredits);
                    comm.Parameters.AddWithValue("@semester", subjectSemester);
                    comm.Parameters.AddWithValue("@professor_id", userId);
                    comm.ExecuteNonQuery();
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        protected void btnNewUserStudent_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }
        protected void btnNewUserProfessor_Click(object sender, EventArgs e)
        {
            pnlNewUser.Visible = true;
        }
        protected void closePanelStudent_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }
        protected void CancelProfessor_Click(object sender, EventArgs e)
        {
            pnlNewUser.Visible = false;
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private void LoadStudentsGrid()
        {
            string pathDB = Server.MapPath("~/BBDD.db");
            string connectionString = $"Data Source={pathDB};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(Query.informationStudentGrid, conn))
                {
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        gvStudents.DataSource = dt;
                        gvStudents.DataKeyNames = new string[] { "id" };
                        gvStudents.DataBind();
                    }
                }
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private void LoadProfessorsGrid()
        {
            string pathDB = Server.MapPath("~/BBDD.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;"))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(Query.informationProfessorsGrid, conn))
                {
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        gvProfessors.DataSource = dt;
                        gvProfessors.DataBind();
                    }
                }
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        protected void gvStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string userId = gvStudents.DataKeys[e.RowIndex].Value.ToString();
            DeleteUserAndRelatedData(userId);
            LoadStudentsGrid();
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private void DeleteUserAndRelatedData(string userId)
        {
            string pathDB = Server.MapPath("~/BBDD.db");

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;"))
                {
                    conn.Open();
                    using (SQLiteCommand deleteCommand = new SQLiteCommand(Query.deleteStudents, conn))
                    {
                        deleteCommand.Parameters.AddWithValue("@user_id", userId);
                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                ErrorLabel.Text = "An error occurred. Please reload the page or try again later.";
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        protected void btnAddStudentToSubject_Click(object sender, EventArgs e)
        {
            string studentUsername = txtStudentUsername.Text;
            string subjectName = txtSubjectNameForStudent.Text;
            int studentID = GetUserIDByUsername(studentUsername);
            int subjectID = GetSubjectIDByName(subjectName);

            if (studentID != -1 && subjectID != -1)
            {
                if (!IsStudentInSubject(studentID, subjectID))
                {
                    AddStudentToSubject(studentID, subjectID);
                    lblAddStudentMessage.Text = "Student added to the subject successfully.";
                }
                else
                {
                    lblAddStudentMessage.Text = "Student is already in the subject.";
                }
            }
            else
            {
                lblAddStudentMessage.Text = "Student or subject not found.";
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private int GetUserIDByUsername(string username)
        {
            string DBpath = Server.MapPath("~/BBDD.db");

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();

                string query = "SELECT id FROM users WHERE username = @username";
                using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@username", username);
                    object result = comm.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private int GetSubjectIDByName(string subjectName)
        {
            string DBpath = Server.MapPath("~/BBDD.db");

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();

                string query = "SELECT id FROM subjects WHERE name = @name";
                using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@name", subjectName);
                    object result = comm.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private void AddStudentToSubject(int studentID, int subjectID)
        {
            string DBpath = Server.MapPath("~/BBDD.db");
            if (IsStudentInSubject(studentID, subjectID))
            {
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                using (SQLiteCommand comm = new SQLiteCommand(Query.addStudentToSubject, conn))
                {
                    comm.Parameters.AddWithValue("@subject_id", subjectID);
                    comm.Parameters.AddWithValue("@user_id", studentID);
                    comm.ExecuteNonQuery();
                }
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private void RemoveStudentFromSubject(int studentID, int subjectID)
        {
            string DBpath = Server.MapPath("~/BBDD.db");
            if (IsStudentInSubject(studentID, subjectID))
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
                {
                    conn.Open();

                    using (SQLiteCommand comm = new SQLiteCommand(Query.removeStudentFromSubject, conn))
                    {
                        comm.Parameters.AddWithValue("@subject_id", subjectID);
                        comm.Parameters.AddWithValue("@user_id", studentID);
                        comm.ExecuteNonQuery();
                    }
                }
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private bool IsStudentInSubject(int studentID, int subjectID)
        {
            string DBpath = Server.MapPath("~/BBDD.db");

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM subject_students WHERE subject_id = @subject_id AND user_id = @user_id";
                using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@subject_id", subjectID);
                    comm.Parameters.AddWithValue("@user_id", studentID);
                    int count = Convert.ToInt32(comm.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        protected void btnRemoveStudentFromSubject_Click(object sender, EventArgs e)
        {
            string studentUsername = txtRemoveStudentUsername.Text;
            string subjectName = txtRemoveSubjectNameForStudent.Text;
            int studentID = GetUserIDByUsername(studentUsername);
            int subjectID = GetSubjectIDByName(subjectName);
            if (studentID != -1 && subjectID != -1)
            {
                if (IsStudentInSubject(studentID, subjectID))
                {
                    RemoveStudentFromSubject(studentID, subjectID);
                    lblRemoveStudentMessage.Text = "Student removed from the subject successfully.";
                }
                else
                {
                    lblRemoveStudentMessage.Text = "Student is not in the subject.";
                }
            }
            else
            {
                lblRemoveStudentMessage.Text = "Student or subject not found.";
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private void LoadViewSubjectsGrid()
        {
            string pathDB = Server.MapPath("~/BBDD.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;"))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(Query.subjectsGrid, conn))
                {
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        gvViewSubjects.DataSource = dt;
                        gvViewSubjects.DataBind();
                    }
                }
            }
        }
    }
}



