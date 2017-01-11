using FYP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.UI;

namespace FYP
{
    public partial class HomePage : Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUserId = User.Identity.GetUserId();
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            string EmpFirstName = currentUser.FirstName;
            string EmpLastName = currentUser.LastName;
            string result;

            if (Page.IsPostBack == false)
            {
                result = GlobalClass.BindChart(EmpFirstName, EmpLastName, 1);
                lt.Text = result.Replace('*', '"');
            }
        }
    }
}