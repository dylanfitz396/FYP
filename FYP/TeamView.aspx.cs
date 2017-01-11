using System;
using System.Web.UI;

namespace FYP
{
    public partial class TeamView : Page
    {
        private string EmpFirstName;
        private string EmpLastName;
        private string result;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                EmpFirstName = "Dylan";
                EmpLastName = "Fitzgerald";
                result = GlobalClass.BindChart(EmpFirstName, EmpLastName, 1);
                lt.Text = result.Replace('*', '"');

                EmpFirstName = "Sarah";
                EmpLastName = "Test";
                result = GlobalClass.BindChart(EmpFirstName, EmpLastName, 1);
                lt1.Text = result.Replace('*', '"');

                EmpFirstName = "Chris";
                EmpLastName = "Test";
                result = GlobalClass.BindChart(EmpFirstName, EmpLastName, 1);
                lt2.Text = result.Replace('*', '"');

                EmpFirstName = "Megan";
                EmpLastName = "Test";
                result = GlobalClass.BindChart(EmpFirstName, EmpLastName, 1);
                lt3.Text = result.Replace('*', '"');
            }
        }
    }
}