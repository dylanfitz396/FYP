using FYP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP
{
    public partial class InputPage : Page
    {
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[
            "Database1ConnectionString1"].ConnectionString);

        private string EmpFirstName;
        private string EmpLastName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var currentUserId = User.Identity.GetUserId();
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                EmpFirstName = currentUser.FirstName;
                EmpLastName = currentUser.LastName;
                
                //Populating a DataTable from database.
                var dt = GlobalClass.GetData(EmpFirstName, EmpLastName);

                //Building an HTML string.
                var html = new StringBuilder();

                //Table start.
                html.Append("<table border = '1'>");

                //Building the Header row.
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<th>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");
                }
                html.Append("</tr>");

                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }

                //Table end.
                html.Append("</table>");

                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal {Text = html.ToString()});
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            var currentUserId = User.Identity.GetUserId();
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            EmpFirstName = currentUser.FirstName;
            EmpLastName = currentUser.LastName;

            if (txtSkill.Text != "")
            {
                var dt = new DataTable();
                dt = GetData();
                {
                    var xp =
                        new SqlCommand(
                            "Insert into Skills(Id, EmpName, Skill, ExpertiseLevel, EmpLastName) Values(@Id, @EmpName, @Skill, @ExpertiseLevel, @EmpLastName)",
                            conn);
                    var newId = (dt.Rows.Count + 1).ToString();
                    xp.Parameters.AddWithValue("@Id", newId);
                    xp.Parameters.AddWithValue("@EmpName", EmpFirstName);
                    xp.Parameters.AddWithValue("@Skill", txtSkill.Text);
                    xp.Parameters.AddWithValue("@ExpertiseLevel", txtExpertiseLevel.Text);
                    xp.Parameters.AddWithValue("@EmpLastName", EmpLastName);

                    conn.Open();
                    xp.ExecuteNonQuery();
                    conn.Close();
                }
            }

            Response.Redirect("~/HomePage.aspx");
        }

        private static DataTable GetData()
        {
            var dt = new DataTable();
            var cmd = "select Skill,ExpertiseLevel from Skills";
            var adp = new SqlDataAdapter(cmd, conn);
            adp.Fill(dt);
            return dt;
        }
    }
}