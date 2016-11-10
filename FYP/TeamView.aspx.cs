using System;
using System.Web.UI;

namespace FYP
{
    public partial class TeamView : Page
    {
        private string SelectedEmployee;
        private string result;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                SelectedEmployee = "Dylan";
                result = GlobalClass.BindChart(SelectedEmployee);
                lt.Text = result.Replace('*', '"');

                SelectedEmployee = "Sarah";
                result = GlobalClass.BindChart(SelectedEmployee);
                lt1.Text = result.Replace('*', '"');

                SelectedEmployee = "Chris";
                result = GlobalClass.BindChart(SelectedEmployee);
                lt2.Text = result.Replace('*', '"');

                SelectedEmployee = "Megan";
                result = GlobalClass.BindChart(SelectedEmployee);
                lt3.Text = result.Replace('*', '"');
            }
        }
    }
}