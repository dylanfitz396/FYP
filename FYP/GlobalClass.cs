﻿using FYP.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Providers.Entities;
using Microsoft.AspNet.Identity;
using System.Web.UI;

namespace FYP
{
    public partial class GlobalClass : Page
    {

        public static StringBuilder str = new StringBuilder();
        //Get connection string from web.config
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[
            "Database1ConnectionString1"].ConnectionString);


        public static DataTable GetEmployeeData(string EmpFirstName, string EmpLastName)
        { 
            var dt = new DataTable();
            var cmd = "select Skill,ExpertiseLevel, ExpertiseLevelString from Skills where EmpName = '" + EmpFirstName + "' and EmpLastName = '" + EmpLastName + "'";
            var adp = new SqlDataAdapter(cmd, conn);
            adp.Fill(dt);
            return dt;
        }

        public static string GetOpeningChartScript()
        {
            string openingScript;
            openingScript = "<script =*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});";
            return openingScript;
        }
        
        public static string GetClosingChartScript()
        {           
            string closingScript;
            closingScript = "</script>";
            return closingScript;
        }

        public static string BindChart(string EmpFirstName, string EmpLastName, int chartNum)
        {
            var dt = new DataTable();
            try
            {
                dt = GetEmployeeData(EmpFirstName, EmpLastName);

                //data
                str.Append("google.setOnLoadCallback(drawChart" + chartNum + ");");
                str.Append("function drawChart" + chartNum + "() {");
                str.Append("var data" + chartNum + " = new google.visualization.DataTable();");
                str.Append("data" + chartNum + ".addColumn('string', 'Skill');");
                str.Append("data" + chartNum + ".addColumn('number', 'ExpertiseLevel');");
                str.Append("data" + chartNum + ".addColumn({type:'string', role:'annotation'});");
                           
                str.Append("data" + chartNum + @".addRows(" + dt.Rows.Count + ");");

                for (var i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    str.Append("data" + chartNum + ".setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["Skill"] + "');");
                    str.Append("data" + chartNum + ".setValue(" + i + "," + 1 + "," + dt.Rows[i]["ExpertiseLevel"] + ") ;");
                    str.Append("data" + chartNum + ".setValue( " + i + "," + 2 + "," + "'" + dt.Rows[i]["ExpertiseLevelString"] + "');");
                }

                //options
                str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div" + chartNum + "'));");
                //str.Append(" google.visualization.events.addListener(chart, 'ready', changeBorderRadius)); google.visualization.events.addListener(chart, 'select', changeBorderRadius); google.visualization.events.addListener(chart, 'onmouseover', changeBorderRadius); google.visualization.events.addListener(chart, 'onmouseout', changeBorderRadius); function changeBorderRadius() { chartColumns = document.getElementById('chart_div').getElementsByTagName('rect'); Array.prototype.forEach.call(chartColumns, function(column) { if ((colors.indexOf(column.getAttribute('fill')) > -1) || (column.getAttribute('fill') === 'none') || (column.getAttribute('stroke') === '#ffffff')) { column.setAttribute('rx', 20); column.setAttribute('ry', 20); } }");
                str.Append(" chart.draw(data" + chartNum + ", {width: 900, height: 400, title: 'Skill Chart: " + EmpFirstName +
                           "',");
                str.Append("hAxis: {title: 'Level of Expertise', titleTextStyle: {color: 'black'}},");
                str.Append("colors: ['#73a839'],");
                str.Append("dataOpacity: 0.8,");
                str.Append("legend: { position: 'right' },");
                str.Append("animation: {duration: 1500, startup: true, easing: 'out'},");
                str.Append("vAxis: { title: 'Skill' },");
                str.Append("}); }");
                

                return str.ToString();
            }
            catch
            {
                return str.ToString();
            }
        }
    }
}