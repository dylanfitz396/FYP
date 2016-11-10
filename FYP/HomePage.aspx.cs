using System;
using System.Web.UI;

namespace FYP
{
    public partial class HomePage : Page
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
    }
}