using FYP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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
                var currentUserId = User.Identity.GetUserId();
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(currentUserId);
                EmpFirstName = currentUser.FirstName;
                EmpLastName = currentUser.LastName;
                
                

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

        protected void btnChangeTeam_Click(object sender, EventArgs e)
        {
            selectedEmployeesTeam = lstSelectedTeam.SelectedValue;
            TeamMembers = GlobalClass.GetTeamMembers(selectedEmployeesTeam);

            script.Append(GlobalClass.GetOpeningChartScript());

            for (TeamMemberIndex = 0; TeamMemberIndex < TeamMembers.Count; TeamMemberIndex++)
            {
                EmpFirstName = TeamMembers[TeamMemberIndex].Item1;
                EmpLastName = TeamMembers[TeamMemberIndex].Item2;
                script.Append(GlobalClass.BindChart(EmpFirstName, EmpLastName, TeamMemberIndex + 1, ChartWidth, ChartHeight));
            }

            script.Append(GlobalClass.GetClosingChartScript());
            script.Replace('*', '"');
            lt.Text = script.ToString();
            //Response.Redirect("ChartForm.aspx");
        }

    }
}