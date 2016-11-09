using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP
{
    public partial class HomePage : System.Web.UI.Page
    {
        private string SelectedEmployee = "Dylan";
        StringBuilder str = new StringBuilder();
        //Get connection string from web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[
            "Database1ConnectionString1"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindChart(SelectedEmployee);
            }
        }

        private DataTable GetData(string SelectedEmployee)
        {
            var dt = new DataTable();
            //var cmd = "select Skill,ExpertiseLevel from Skills where EmpName = 'Chris'";
            var cmd = "select Skill,ExpertiseLevel from Skills where EmpName = '" + SelectedEmployee + "'";
            var adp = new SqlDataAdapter(cmd, conn);
            adp.Fill(dt);
            return dt;
        }

        private void BindChart(string SelectedEmployee)
        {
            var dt = new DataTable();
            try
            {
                dt = GetData(SelectedEmployee);

                str.Append(@"<script =*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
                       google.setOnLoadCallback(drawChart);
                       function drawChart() {
                        var data = new google.visualization.DataTable();
                        data.addColumn('string', 'Skill');
                        data.addColumn('number', 'ExpertiseLevel');     
 
                        data.addRows(" + dt.Rows.Count + ");");

                for (var i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["Skill"] + "');");
                    str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["ExpertiseLevel"] + ") ;");
                }

                str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");
                str.Append(" chart.draw(data, {width: 900, height: 400, title: 'Your Skill Chart: " + SelectedEmployee +
                           "',");
                str.Append("hAxis: {title: 'Level of Expertise', titleTextStyle: {color: 'green'}},");
                str.Append("colors: ['#73a839'],");
                str.Append("animation: {duration: 1500, startup: true},");
                str.Append("vAxis: { title: 'Skill' },");
                str.Append("}); }");
                str.Append("</script>");
                lt.Text = str.ToString().Replace('*', '"');
            }
            catch
            {
            }
        }
    }
}