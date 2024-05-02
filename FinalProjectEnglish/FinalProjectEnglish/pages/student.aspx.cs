using FinalProjectEnglish.classes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectEnglish.pages
{
    public partial class student : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] != null)
                {
                    int userId = (int)Session["userId"];
                    ShowStudentInformation(userId);
                    ViewStudentSubjects(userId);
                }
                else
                {
                    Response.Redirect("logIn.aspx");
                }
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private void ShowStudentInformation(int userId)
        {
            try
            {
                string pathDB = Server.MapPath("~/BBDD.db");
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;"))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(Query.GetStudentInformationQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblActualName.Text = reader["name"].ToString();
                                lblActualSurname.Text = reader["surname"].ToString();
                                actualNationality.Text = reader["nationality"].ToString();
                                actualDbo.Text = reader["day_of_birth"].ToString();
                                actualId.Text = reader["id_number"].ToString();
                                actualAddress.Text = reader["address"].ToString();
                                actualEmail.Text = reader["email"].ToString();
                            }
                        }
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
        protected void btnUpdateClick(object sender, EventArgs e)
        {
            try
            {
                if (Session["userId"] != null)
                {
                    int userId = (int)Session["userId"];

                    Student student = GetStudentInformation(userId);

                    student.Nationality = txtNationalty.Text.Trim();
                    student.DateOfBirth = txtDbo.Text.Trim();
                    student.IdNumber = txtIDNumber.Text.Trim();
                    student.Address = txtAddress.Text.Trim();
                    student.Email = txtEmail.Text.Trim();
                    student.Name = txtName.Text.Trim(); 
                    student.Surname =txtSurname.Text.Trim();    

                    string pathDB = Server.MapPath("~/BBDD.db");
                    using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;"))
                    {
                        conn.Open();

                        student.UpdateInformation(conn);

                        ShowStudentInformation(userId);
                    }
                }
                else
                {
                    Response.Redirect("logIn.aspx");
                }
            }
            catch (Exception)
            {
                ErrorLabel.Text = "An error occurred. Please reload the page or try again later.";
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private Student GetStudentInformation(int userId)
        {
            return new Student(userId, "Name", "Nationality","Surname", "DateOfBirth", "IDNumber", "Address", "Email");
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private void ViewStudentSubjects(int userId)
        {
            try
            {
                string pathDB = Server.MapPath("~/BBDD.db");
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;"))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(Query.ViewStudentSubjectsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            gvSubjects.DataSource = reader;
                            gvSubjects.DataBind();
                        }
                    }
                }
            }
            catch (Exception)
            {
                ErrorLabel.Text = "An error occurred. Please reload the page or try again later.";
            }
        }
    }
}