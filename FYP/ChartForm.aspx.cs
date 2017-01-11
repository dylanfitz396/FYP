using System;
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
                script.Append(GlobalClass.GetOpeningChartScript());

                EmpFirstName = "Chris";
                EmpLastName = "Test";                
                script.Append(GlobalClass.BindChart(EmpFirstName, EmpLastName, 1));

                EmpFirstName = "Dylan";
                EmpLastName = "Fitzgerald";
                script.Append(GlobalClass.BindChart(EmpFirstName, EmpLastName, 2));

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