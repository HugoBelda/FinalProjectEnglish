using FinalProjectEnglish.classes;
using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace FinalProjectEnglish.pages
{
    public partial class logIn : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        protected void Button1_Click(object sender, EventArgs e)
        {
            string pathDB = Server.MapPath("~/BBDD.db");
            string username = TextBox1.Text;http://localhost:64603/pages/logIn.aspx.cs
            string password = TextBox2.Text;

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(Query.logInQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["id"]);
                            string storedHash = reader["password_hash"].ToString();
                            string userRole = reader["role"].ToString();

                            if (VerifyPassword(password, storedHash))
                            {
                                Session["username"] = username;
                                Session["userId"] = userId;
                                RedirectBasedOnRole(userRole);
                            }
                            else
                            {
                                lblMessage.Text = "Invalid username or password.";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Invalid username or password.";
                        }
                    }
                }
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] enteredData = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                string enteredHash = BitConverter.ToString(enteredData).Replace("-", string.Empty);
                return enteredHash == storedHash;
            }
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private void RedirectBasedOnRole(string userRole)
        {
            switch (userRole.ToLower())
            {
                case "admin":
                    Response.Redirect("admin.aspx");
                    break;
                case "professor":
                    Response.Redirect("professor.aspx");
                    break;
                case "student":
                    Response.Redirect("student.aspx");
                    break;
                default:
                    lblMessage.Text = "Invalid role.";
                    break;
            }
        }
    }
}
