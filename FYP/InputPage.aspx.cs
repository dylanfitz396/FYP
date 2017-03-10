using FYP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP
{
    public partial class InputPage : Page
    {
        private static string connStr = ConfigurationManager.ConnectionStrings[
            "Database1ConnectionString1"].ConnectionString;

        private string EmpFirstName;
        private string EmpLastName;
        private int intExpertiseLevel;
        private static string teamName;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnInsert.Visible = false;
            btnDelete.Visible = false;
            btnChangeTeam.Visible = true;
            lblExpertiseLevel.Visible = false;
            lstExpertiseLevel.Visible = false;
            lstSelectedTeam.Enabled = false;

            //using try catch to make sure employee is selected for tests
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

            //populate seleted team dropdownlist
            if (lstSelectedTeam.Items.Count == 0)
            {
                lstSelectedTeam.Items.Add("Developers");
                lstSelectedTeam.Items.Add("Analysts");
                lstSelectedTeam.Items.Add("QA");

                teamName = GlobalClass.GetSelectedEmployeesTeam(EmpFirstName, EmpLastName);
                lstSelectedTeam.SelectedValue = teamName;
            }

            if (lstExpertiseLevel.Items.Count == 0)
            {
                //Populate the expertise level DropDownList
                lstExpertiseLevel.Items.Add("Beginner");
                lstExpertiseLevel.Items.Add("Intermediate");
                lstExpertiseLevel.Items.Add("Proficient");
                lstExpertiseLevel.Items.Add("Advanced");
                lstExpertiseLevel.Items.Add("SME");
            }

            //Populating a DataTable from database.
            var dt = GlobalClass.GetSelectedEmployeeData(EmpFirstName, EmpLastName);

            //Building an HTML string.
            var html = new StringBuilder();

            //Table start.
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

            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal {Text = html.ToString()});
            
        }

        protected void btnChangeTeam_Click(object sender, EventArgs e)
        {
            lstSelectedTeam.Enabled = true;
            btnChangeTeam.Visible = false;
        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            string title = "Information";
            string message = "Please enter the name of the Skill you would like to Update, Insert or Delete. Once entered, click Proceed";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "','" + message + "');", true);
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if ((txtSkill.Text != "") || (lstSelectedTeam.SelectedValue != teamName))
            {

                List<string> EmployeesSkills = GlobalClass.GetSelectedEmployeesSkills(EmpFirstName, EmpLastName);
                btnProceed.Visible = false;         
                txtSkill.Enabled = false;
                lstSelectedTeam.Enabled = false;
                btnChangeTeam.Visible = false;

                if (lstSelectedTeam.SelectedValue != teamName)
                {
                    GlobalClass.UpdateSelectedTeamInSkillsDb(EmpFirstName, EmpLastName, lstSelectedTeam.SelectedValue);
                    teamName = lstSelectedTeam.SelectedValue;
                    Response.Redirect(Request.RawUrl);
                }

            
                if (EmployeesSkills.Contains(txtSkill.Text.ToUpper()))
                {
                    lblExpertiseLevel.Visible = true;
                    lstExpertiseLevel.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnUpdate.Focus();
                    lstExpertiseLevel.SelectedIndex = (GlobalClass.GetExpertiseLevel(EmpFirstName, EmpLastName, txtSkill.Text)) - 1;
                }
                else if (txtSkill.Text != "")
                {
                    lblExpertiseLevel.Visible = true;
                    lstExpertiseLevel.Visible = true;
                    btnInsert.Visible = true;
                    btnInsert.Focus();
                }
                else
                {
                    txtSkill.Focus();
                }
                
            }
            else
            {
                string title = "Error Message";
                string message = "A detail must be changed before continuing. Please either enter a skill or change team. If no change is needed, return to your homepage by clicking on the Home button";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "','"  + message + "');", true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
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

                GlobalClass.UpdateDataRowInSkillsDb(EmpFirstName, txtSkill.Text, intExpertiseLevel.ToString(), EmpLastName, lstExpertiseLevel.SelectedValue, lstSelectedTeam.SelectedValue);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
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

                GlobalClass.InsertNewDataRowInSkillsDb(EmpFirstName, txtSkill.Text, intExpertiseLevel.ToString(), EmpLastName, lstExpertiseLevel.SelectedValue, lstSelectedTeam.SelectedValue);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GlobalClass.DeleteDataRowInSkillsDb(EmpFirstName, txtSkill.Text, EmpLastName);
            Response.Redirect(Request.RawUrl);
        }
        
    }
}