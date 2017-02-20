using FYP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP
{
    public partial class SearchPage : System.Web.UI.Page
    {
        private string EmpFirstName;
        private string EmpLastName;
        private string selectedEmployeesTeam;
        private string selectedEmployee;
        List<Tuple<string, string>> TeamMembers;
        private static StringBuilder script = new StringBuilder();
        int TeamMemberIndex = 0;
        int chartWidth;
        int chartHeight;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {
                //try catch for dev purposes. Remove for final version
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

                //populate Search By dropdownlist
                if (lstSearchBy.Items.Count == 0)
                {
                    lstSearchBy.Items.Add("Skill");
                    lstSearchBy.Items.Add("Employee");
                    lstSearchBy.Items.Add("Team");

                    lstSearchBy.SelectedValue = "Skill";
                }

            }

        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            btnProceed.Visible = false;
            btnChangeSearchByQuery.Visible = true;
            btnSearch.Visible = true;
            lblEnterCriteria.Visible = true;
            lstEnterCriteria.Visible = true;
            lstSearchBy.Enabled = false;
            lstEnterCriteria.Items.Clear();
            script.Clear();

            if (lstSearchBy.SelectedValue == "Skill")
            {
                lblEnterCriteria.Text = "Select Skill:";
                var lstAllSkills = GlobalClass.GetAllSkills();

                //populate lstEnterCriteria Dropdown List
                for (var i = 0; i < lstAllSkills.Count; i++)
                {
                    lstEnterCriteria.Items.Add(lstAllSkills[i].ToString());
                }
                
            }
            else if (lstSearchBy.SelectedValue == "Employee")
            {
                lblEnterCriteria.Text = "Select Employee:";
                var dtAllEmployees = GlobalClass.GetAllEmployeesDataTable();

                //populate lstEnterCriteria Dropdown List
                for (var i = 0; i < dtAllEmployees.Rows.Count; i++)
                {
                    lstEnterCriteria.Items.Add((dtAllEmployees.Rows[i]["EmpName"].ToString()) + 
                        " " + dtAllEmployees.Rows[i]["EmpLastName"].ToString());
                }
            }
            else if (lstSearchBy.SelectedValue == "Team")
            {
                lblEnterCriteria.Text = "Select Team:";
                var lstTeams = GlobalClass.GetAllTeams();

                //populate lstEnterCriteria Dropdown List
                for (var i = 0; i < lstTeams.Count; i++)
                {
                    lstEnterCriteria.Items.Add(lstTeams[i].ToString());
                }
            }
        }

        protected void btnChangeSearchByQuery_Click(object sender, EventArgs e)
        {
            btnChangeSearchByQuery.Visible = false;
            btnProceed.Visible = true;
            btnSearch.Visible = false;
            lblEnterCriteria.Visible = false;
            lstEnterCriteria.Visible = false;
            lstSearchBy.Enabled = true;
            lstSearchBy.Focus();
            script.Clear();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Search by Skill
            if (lstSearchBy.SelectedValue == "Skill")
            {
                script.Clear();
                var selectedSkill = lstEnterCriteria.SelectedValue;
                string Colour = "#73a839";
                int chartWidth = 1020;
                int chartHeight = 400;
                var index = lstEnterCriteria.SelectedIndex;
                var lstAllSkills = GlobalClass.GetAllSkills();

                script.Append(GlobalClass.GetOpeningChartScript());
                script.Append(GlobalClass.CreateSkillSpecificChart(selectedSkill, 1, chartWidth, chartHeight, Colour, false));
                script.Append(GlobalClass.GetClosingChartScript());
                script.Replace('*', '"');
                lt.Text = script.ToString();
            }

            //Search By Employee Name
            if (lstSearchBy.SelectedValue == "Employee")
            {
                script.Clear();
                selectedEmployee = lstEnterCriteria.SelectedValue;
                string Colour = "#73a839";
                var index = lstEnterCriteria.SelectedIndex;
                var dtAllEmployees = GlobalClass.GetAllEmployeesDataTable();
                EmpFirstName = dtAllEmployees.Rows[index]["EmpName"].ToString();
                EmpLastName = dtAllEmployees.Rows[index]["EmpLastName"].ToString();
                int chartWidth = 1020;
                int chartHeight = 400;


                script.Append(GlobalClass.GetOpeningChartScript());
                script.Append(GlobalClass.BindChart(EmpFirstName, EmpLastName, 1, chartWidth, chartHeight, Colour, false));
                script.Append(GlobalClass.GetClosingChartScript());
                script.Replace('*', '"');
                lt.Text = script.ToString();
            }


            //Search By Team
            if (lstSearchBy.SelectedValue == "Team")
            {
                script.Clear();
                selectedEmployeesTeam = lstEnterCriteria.SelectedValue;
                TeamMembers = GlobalClass.GetTeamMembers(selectedEmployeesTeam);
                string Colour = "#73a839";
                chartWidth = 550;
                chartHeight = 250;

                script.Append(GlobalClass.GetOpeningChartScript());

                for (TeamMemberIndex = 0; TeamMemberIndex < TeamMembers.Count; TeamMemberIndex++)
                {
                    switch (TeamMemberIndex)
                    {
                        case 0:
                            Colour = "#73a839";
                            break;
                        case 1:
                            Colour = "#333399";
                            break;
                        case 2:
                            Colour = "#CC9933";
                            break;
                        case 3:
                            Colour = "#993366";
                            break;
                        default:
                            Colour = "#73a839";
                            break;
                    }
                    EmpFirstName = TeamMembers[TeamMemberIndex].Item1;
                    EmpLastName = TeamMembers[TeamMemberIndex].Item2;
                    script.Append(GlobalClass.BindChart(EmpFirstName, EmpLastName, TeamMemberIndex + 1, chartWidth, chartHeight, Colour, true));
                }

                script.Append(GlobalClass.GetClosingChartScript());
                script.Replace('*', '"');
                lt.Text = script.ToString();
            }
        }
    }
}