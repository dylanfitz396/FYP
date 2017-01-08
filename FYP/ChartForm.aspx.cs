using System;
using System.Web.UI;

namespace FYP
{
    public partial class ChartForm : Page
    {
        private string EmpFirstName = "Dylan";
        private string EmpLastName = "Fitzgerald";
        private string result;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                result = GlobalClass.BindChart(EmpFirstName, EmpLastName);
                lt.Text = result.Replace('*', '"');
            }
        }

        protected void btnDylan_Click(object sender, EventArgs e)
        {
            EmpFirstName = "Dylan";
            EmpLastName = "Fitzgerald";
            result = GlobalClass.BindChart(EmpFirstName, EmpLastName);
            lt.Text = result.Replace('*', '"');
        }

        protected void btnChris_Click(object sender, EventArgs e)
        {
            EmpFirstName = "Chris";
            EmpLastName = "Test";
            result = GlobalClass.BindChart(EmpFirstName, EmpLastName);
            lt.Text = result.Replace('*', '"');
        }

        protected void btnSarah_Click(object sender, EventArgs e)
        {
            EmpFirstName = "Sarah";
            EmpLastName = "Test";
            result = GlobalClass.BindChart(EmpFirstName, EmpLastName);
            lt.Text = result.Replace('*', '"');
        }

        protected void btnMegan_Click(object sender, EventArgs e)
        {
            EmpFirstName = "Megan";
            EmpLastName = "Test";
            result = GlobalClass.BindChart(EmpFirstName, EmpLastName);
            lt.Text = result.Replace('*', '"');
        }
    }
}