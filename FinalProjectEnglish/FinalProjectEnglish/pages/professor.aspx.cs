using FinalProjectEnglish.classes;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectEnglish.pages
{
    public partial class professor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] != null)
                {
                    int professorId = (int)Session["userId"];
                    ViewProfessorSubjects(professorId);
                    ViewStudentsInSubject(professorId, 1);
                }
                else
                {
                    Response.Redirect("logIn.aspx");
                }
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private void ViewProfessorSubjects(int professorId)
        {
            try
            {
                string pathDB = Server.MapPath("~/BBDD.db");
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;"))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(Query.ViewProfessorSubjects, conn))
                    {
                        cmd.Parameters.AddWithValue("@professorId", professorId);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            gvProfessorSubjects.DataSource = reader;
                            gvProfessorSubjects.DataBind();
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
        private void ViewStudentsInSubject(int professorId, int subjectId)
        {
            try
            {
                string pathDB = Server.MapPath("~/BBDD.db");
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;"))
                {
                    conn.Open();

               
                    using (SQLiteCommand cmd = new SQLiteCommand(Query.studentsInSubject, conn))
                    {
                        cmd.Parameters.AddWithValue("@subjectId", subjectId);
                        cmd.Parameters.AddWithValue("@professorId", professorId);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            gvStudentsInSubject.DataSource = reader;
                            gvStudentsInSubject.DataBind();
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
        protected void gvProfessorSubjects_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewStudents")
            {
                if (Session["userId"] != null)
                {
                    int professorId = (int)Session["userId"];
                    int subjectId = Convert.ToInt32(e.CommandArgument);
                    ViewStudentsInSubject(professorId, subjectId);
                }
                else
                {
                    Response.Redirect("logIn.aspx");
                }
            }
        }
    }
}
