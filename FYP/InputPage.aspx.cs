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
        private int intExpertiseLevel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //using try catch for dev purposes to make sure employee is selected for tests
                try
                {
                    var currentUserId = User.Identity.GetUserId();
                    var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                    var currentUser = manager.FindById(currentUserId);
                    EmpFirstName = currentUser.FirstName;
                    EmpLastName = currentUser.LastName;
                }
                catch
                {
                    EmpFirstName = "Dylan";
                    EmpLastName = "Fitzgerald";
                }

                //Populate the DropDownList
                lstExpertiseLevel.Items.Add("Beginner");
                lstExpertiseLevel.Items.Add("Intermediate");
                lstExpertiseLevel.Items.Add("Proficient");
                lstExpertiseLevel.Items.Add("Advanced");
                lstExpertiseLevel.Items.Add("SME");

                //Populating a DataTable from database.
                var dt = GlobalClass.GetSelectedEmployeeData(EmpFirstName, EmpLastName);

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
            var currentUser = manager.FindById(currentUserId);
            EmpFirstName = currentUser.FirstName;
            EmpLastName = currentUser.LastName;
            string SelectedTeam = GlobalClass.GetSelectedEmployeesTeam(EmpFirstName, EmpLastName);

            if (txtSkill.Text != "")
            {

                switch (lstExpertiseLevel.SelectedIndex)
                {
                    case 0:
                        intExpertiseLevel = 1;
                        break;
                    case 1:
                        intExpertiseLevel = 2;
                        break;
                    case 2:
                        intExpertiseLevel = 3;
                        break;
                    case 3:
                        intExpertiseLevel = 4;
                        break;
                    case 4:
                        intExpertiseLevel = 5;
                        break;
                    default:
                        intExpertiseLevel = 1;
                        break;
                }

                GlobalClass.InsertNewDataRowInSkillsDb(EmpFirstName, txtSkill.Text, intExpertiseLevel.ToString(), EmpLastName, lstExpertiseLevel.SelectedValue, SelectedTeam);
            }

            Response.Redirect("~/HomePage.aspx");
        }

        
    }
}