using FYP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;

namespace FYP
{
    public partial class ChartForm : Page
    {
        private string EmpFirstName;
        private string EmpLastName;
        private string selectedEmployeesTeam;
        List<Tuple<string, string>> TeamMembers;
        private static StringBuilder script = new StringBuilder();
        int TeamMemberIndex = 0;
        int ChartWidth = 550;
        int ChartHeight = 250;

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




                //StringBuilder strBuild1 = new StringBuilder();
                //var dt1 = new DataTable();
                //dt1 = GlobalClass.GetMaxTeamData("Developers");
                //for (var i = 0; i < dt1.Rows.Count; i++)
                //{
                //    strBuild1.Append(dt1.Rows[i]["Skill"]);
                //    strBuild1.Append(dt1.Rows[i]["ExpertiseLevel"]);
                //    strBuild1.Append("----");

                //}

                //StringBuilder strBuild = new StringBuilder();
                //var dt = new DataTable();
                //dt = GlobalClass.GetSelectedTeamData("Developers");
                //for (var i = 0; i < dt.Rows.Count; i++)
                //{
                //    strBuild.Append(dt.Rows[i]["Skill"]);
                //    strBuild.Append(dt.Rows[i]["ExpertiseLevel"]);
                //    strBuild.Append("----");

                //}

                //populate seleted team dropdownlist
                if (lstSelectedTeam.Items.Count == 0)
                {
                    lstSelectedTeam.Items.Add("Developers");
                    lstSelectedTeam.Items.Add("Analysts");
                    lstSelectedTeam.Items.Add("QA");

                    selectedEmployeesTeam = GlobalClass.GetSelectedEmployeesTeam(EmpFirstName, EmpLastName);
                    lstSelectedTeam.SelectedValue = selectedEmployeesTeam;
                }

            }

        }

        protected void btnSelectTeam_Click(object sender, EventArgs e)
        {
            script.Clear();
            selectedEmployeesTeam = lstSelectedTeam.SelectedValue;
            TeamMembers = GlobalClass.GetTeamMembers(selectedEmployeesTeam);
            string Colour = "#73a839";

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
                script.Append(GlobalClass.BindChart(EmpFirstName, EmpLastName, TeamMemberIndex + 1, ChartWidth, ChartHeight, Colour));
            }

            script.Append(GlobalClass.GetClosingChartScript());
            script.Replace('*', '"');
            lt.Text = script.ToString();
        }

        protected void btnTeamView_Click(object sender, EventArgs e)
        {
            script.Clear();
            selectedEmployeesTeam = lstSelectedTeam.SelectedValue;
            TeamMembers = GlobalClass.GetTeamMembers(selectedEmployeesTeam);

            TeamMemberIndex = 0;
            script.Append(GlobalClass.GetOpeningChartScript());
            script.Append(GlobalClass.CreateTeamStrengthChart(selectedEmployeesTeam, TeamMemberIndex + 1, 1000, 600));
            script.Append(GlobalClass.GetClosingChartScript());
            script.Replace('*', '"');
            lt.Text = script.ToString();

        }
    }
}