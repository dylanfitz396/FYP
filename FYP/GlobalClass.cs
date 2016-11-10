using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace FYP
{
    public class GlobalClass
    {
        public static string SelectedEmployee = "Dylan";
        public static StringBuilder str = new StringBuilder();
        //Get connection string from web.config
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[
            "Database1ConnectionString1"].ConnectionString);



        public static DataTable GetData(string SelectedEmployee)
        {
            var dt = new DataTable();
            var cmd = "select Skill,ExpertiseLevel from Skills where EmpName = '" + SelectedEmployee + "'";
            var adp = new SqlDataAdapter(cmd, conn);
            adp.Fill(dt);
            return dt;
        }

        public static string BindChart(string SelectedEmployee)
        {
            var dt = new DataTable();
            try
            {
                dt = GetData(SelectedEmployee);

                //data
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

                //options
                str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");
                //str.Append(" google.visualization.events.addListener(chart, 'ready', changeBorderRadius)); google.visualization.events.addListener(chart, 'select', changeBorderRadius); google.visualization.events.addListener(chart, 'onmouseover', changeBorderRadius); google.visualization.events.addListener(chart, 'onmouseout', changeBorderRadius); function changeBorderRadius() { chartColumns = document.getElementById('chart_div').getElementsByTagName('rect'); Array.prototype.forEach.call(chartColumns, function(column) { if ((colors.indexOf(column.getAttribute('fill')) > -1) || (column.getAttribute('fill') === 'none') || (column.getAttribute('stroke') === '#ffffff')) { column.setAttribute('rx', 20); column.setAttribute('ry', 20); } }");
                str.Append(" chart.draw(data, {width: 900, height: 400, title: 'Your Skill Chart: " + SelectedEmployee + "',");
                str.Append("hAxis: {title: 'Level of Expertise', titleTextStyle: {color: 'black'}},");
                str.Append("colors: ['#73a839'],");
                str.Append("dataOpacity: 0.8,");
                str.Append("legend: { position: 'none' },");
                str.Append("animation: {duration: 1500, startup: true, easing: 'out'},");
                str.Append("vAxis: { title: 'Skill' },");
                str.Append("}); }");
                str.Append("</script>");

                return str.ToString();
            }
            catch
            {
                return str.ToString();
            }
        }
    }
}