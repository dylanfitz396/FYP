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
            var currentUserId = User.Identity.GetUserId();
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(currentUserId);
            string EmpFirstName = currentUser.FirstName;
            string EmpLastName = currentUser.LastName;
            StringBuilder script = new StringBuilder();

            if (Page.IsPostBack == false)
            {
                script.Append(GlobalClass.GetOpeningChartScript());
                script.Append(GlobalClass.BindChart(EmpFirstName, EmpLastName, 1));
                script.Append(GlobalClass.GetClosingChartScript());
                script.Replace('*', '"');
                lt.Text = script.ToString();
            }
        }
    }
}