using FYP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Text;
using System.Web.UI;

namespace FYP
{
    public partial class HomePage : Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            string EmpFirstName;
            string EmpLastName;

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

            StringBuilder script = new StringBuilder();
            int chartWidth = 760;
            int chartHeight = 360;

            if (Page.IsPostBack == false)
            {
                string teamName = GlobalClass.GetSelectedEmployeesTeam(EmpFirstName, EmpLastName);
                lblSelectedTeam.Text = teamName;

                script.Append(GlobalClass.GetOpeningChartScript());
                script.Append(GlobalClass.BindChart(EmpFirstName, EmpLastName, 1, chartWidth, chartHeight));
                script.Append(GlobalClass.GetClosingChartScript());
                script.Replace('*', '"');
                lt.Text = script.ToString();
            }
        }
    }
}