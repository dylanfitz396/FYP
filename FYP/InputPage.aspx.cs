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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string selectedEmployee = "Dylan";
                //Populating a DataTable from database.
                DataTable dt = GlobalClass.GetData(selectedEmployee);

                //Building an HTML string.
                StringBuilder html = new StringBuilder();

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
            if (txtSkill.Text != "")
            {

                var dt = new DataTable();
                dt = GetData();
                {
                    var xp =
                        new SqlCommand(
                            "Insert into Skills(Id, EmpName, Skill, ExpertiseLevel) Values(@Id, @EmpName, @Skill, @ExpertiseLevel)",
                            conn);
                    var newId = (dt.Rows.Count + 1).ToString();
                    xp.Parameters.AddWithValue("@Id", newId);
                    xp.Parameters.AddWithValue("@EmpName", GlobalClass.SelectedEmployee);
                    xp.Parameters.AddWithValue("@Skill", txtSkill.Text);
                    xp.Parameters.AddWithValue("@ExpertiseLevel", txtExpertiseLevel.Text);

                    conn.Open();
                    xp.ExecuteNonQuery();
                    conn.Close();
                }
            }

            Response.Redirect("~/ChartForm.aspx");
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