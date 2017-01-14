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
        private static StringBuilder script = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                var currentUserId = User.Identity.GetUserId();
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(currentUserId);
                EmpFirstName = currentUser.FirstName;
                EmpLastName = currentUser.LastName;
                string selectedEmployeesTeam = GlobalClass.GetSelectedEmployeesTeam(EmpFirstName, EmpLastName);
                List<Tuple<string, string>> TeamMembers = GlobalClass.GetTeamMembers(selectedEmployeesTeam);
                int TeamMemberIndex = 0;

                script.Append(GlobalClass.GetOpeningChartScript());

                for (TeamMemberIndex = 0; TeamMemberIndex < TeamMembers.Count; TeamMemberIndex++)
                {
                    EmpFirstName = TeamMembers[TeamMemberIndex].Item1;
                    EmpLastName = TeamMembers[TeamMemberIndex].Item2;
                    script.Append(GlobalClass.BindChart(EmpFirstName, EmpLastName, TeamMemberIndex+1));
                }

                //EmpFirstName = TeamMembers[1].Item1;
                //EmpLastName = TeamMembers[1].Item2;
                //script.Append(GlobalClass.BindChart(EmpFirstName, EmpLastName, 2));

                script.Append(GlobalClass.GetClosingChartScript());
                script.Replace('*', '"');
                lt.Text = script.ToString();
            }
        }

        
        //protected void btnDylan_Click(object sender, EventArgs e)
        //{
        //    EmpFirstName = "Dylan";
        //    EmpLastName = "Fitzgerald";
        //    result = GlobalClass.BindChart(EmpFirstName, EmpLastName, 1);
        //    lt.Text = result.Replace('*', '"');
        //}

        //protected void btnChris_Click(object sender, EventArgs e)
        //{
        //    EmpFirstName = "Chris";
        //    EmpLastName = "Test";
        //    result = GlobalClass.BindChart(EmpFirstName, EmpLastName, 1);
        //    lt.Text = result.Replace('*', '"');
        //}

        //protected void btnSarah_Click(object sender, EventArgs e)
        //{
        //    EmpFirstName = "Sarah";
        //    EmpLastName = "Test";
        //    result = GlobalClass.BindChart(EmpFirstName, EmpLastName, 1);
        //    lt.Text = result.Replace('*', '"');
        //}

        //protected void btnMegan_Click(object sender, EventArgs e)
        //{
        //    EmpFirstName = "Megan";
        //    EmpLastName = "Test";
        //    result = GlobalClass.BindChart(EmpFirstName, EmpLastName, 1);
        //    lt.Text = result.Replace('*', '"');
        //}
    }
}