using FYP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                //try catch. if no employee is selected default to dylan fitzgerald
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
                    var lstTeams = GlobalClass.GetAllTeams();
                    for (var i = 0; i < lstTeams.Count; i++)
                    {
                        lstSelectedTeam.Items.Add(lstTeams[i].ToString());
                    }

                    selectedEmployeesTeam = GlobalClass.GetSelectedEmployeesTeam(EmpFirstName, EmpLastName);
                    lstSelectedTeam.SelectedValue = selectedEmployeesTeam;
                }

            }

        }

        //change displayed charts depending on selected team
        protected void btnSelectTeam_Click(object sender, EventArgs e)
        {
            script.Clear();
            selectedEmployeesTeam = lstSelectedTeam.SelectedValue;
            TeamMembers = GlobalClass.GetTeamMembers(selectedEmployeesTeam);
            string Colour = "#73a839";

            script.Append(GlobalClass.GetOpeningChartScript());

            //different colour charts for different employees
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
                script.Append(GlobalClass.BindChart(EmpFirstName, EmpLastName, TeamMemberIndex + 1, ChartWidth, ChartHeight, Colour, true));
            }

            script.Append(GlobalClass.GetClosingChartScript());
            script.Replace('*', '"');
            lt.Text = script.ToString();
        }

        //display team view of overall team strong and weak skills as well as missing skills
        protected void btnTeamView_Click(object sender, EventArgs e)
        {
            script.Clear();
            selectedEmployeesTeam = lstSelectedTeam.SelectedValue;
            TeamMembers = GlobalClass.GetTeamMembers(selectedEmployeesTeam);

            script.Append(GlobalClass.GetOpeningChartScript());
            script.Append(GlobalClass.CreateTeamStrengthChart(EmpFirstName, selectedEmployeesTeam, 1, ChartWidth, ChartHeight, true, "#73a839"));
            script.Append(GlobalClass.CreateTeamStrengthChart(EmpFirstName, selectedEmployeesTeam, 2, ChartWidth, ChartHeight, false, "#FF0000"));
            script.Append(GlobalClass.GetClosingChartScript());
            script.Replace('*', '"');
            lt.Text = script.ToString();

            var lstAllSkills = GlobalClass.GetAllSkills();
            var lstTeamSkills = GlobalClass.GetSelectedTeamSkills(selectedEmployeesTeam);
            var lstMissingSkills = lstAllSkills.Except(lstTeamSkills).ToList();
            var divisibleBy3Int = 0;

            //Building an HTML string.
            var html = new StringBuilder();

            //Table start.
            //Building the Header row.
            html.Append("<thead class=*bg-success*>");
            html.Append("<tr class=*table-success*>");
                html.Append("<th class=*table-success*>");
                html.Append("Missing Skills");
                html.Append("</th>");
                html.Append("<th class=*table-success*>");
                html.Append("");
                html.Append("</th>");
                html.Append("<th class=*table-success*>");
                html.Append("");
                html.Append("</th>");
            html.Append("</tr>");
            html.Append("</thead>");

            html.Append("<tr class=*table-success*>");

            //adding missing skills to missing skills table
            foreach (var Skill in lstMissingSkills)
            {
                divisibleBy3Int++;

                html.Append("<td class=*table-success*>");
                html.Append(Skill.ToString());
                html.Append("</td>");
                
                while (divisibleBy3Int >= 0)
                {
                    divisibleBy3Int -= 3;
                }
                while (divisibleBy3Int < 0)
                {
                    divisibleBy3Int += 3;
                }
                if (divisibleBy3Int == 0)
                {
                    html.Append("</tr>");
                    html.Append("<tr class=*table-success*>");
                }
            }

            html.Append("</tr>");
            html.Replace('*', '"');

            //Append the HTML string to Placeholder.
            MissingSkillsTablePlaceholder.Controls.Add(new Literal { Text = html.ToString() });

        }
    }
}