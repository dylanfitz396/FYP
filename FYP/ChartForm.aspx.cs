using System;
using System.Web.UI;

namespace FYP
{
    public partial class ChartForm : Page
    {
        private string SelectedEmployee = "Dylan";
        private string result;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                result = GlobalClass.BindChart(SelectedEmployee);
                lt.Text = result.Replace('*', '"');
            }
        }

        protected void btnDylan_Click(object sender, EventArgs e)
        {
            SelectedEmployee = "Dylan";
            result = GlobalClass.BindChart(SelectedEmployee);
            lt.Text = result.Replace('*', '"');
        }

        protected void btnChris_Click(object sender, EventArgs e)
        {
            SelectedEmployee = "Chris";
            result = GlobalClass.BindChart(SelectedEmployee);
            lt.Text = result.Replace('*', '"');
        }

        protected void btnSarah_Click(object sender, EventArgs e)
        {
            SelectedEmployee = "Sarah";
            result = GlobalClass.BindChart(SelectedEmployee);
            lt.Text = result.Replace('*', '"');
        }

        protected void btnMegan_Click(object sender, EventArgs e)
        {
            SelectedEmployee = "Megan";
            result = GlobalClass.BindChart(SelectedEmployee);
            lt.Text = result.Replace('*', '"');
        }
    }
}