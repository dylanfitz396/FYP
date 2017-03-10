
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Collections.Generic;
using System;

namespace FYP
{
    //global class containing methods that can be accessed from all other classes
    public partial class GlobalClass : Page
    {
        //Get connection string from web.config
        private static string connStr = ConfigurationManager.ConnectionStrings[
            "Database1ConnectionString1"].ConnectionString;


        //Get employee data when have their first and last name
        public static DataTable GetSelectedEmployeeData(string EmpFirstName, string EmpLastName)
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                var dt = new DataTable();
                var cmd = "select Skill,ExpertiseLevel, ExpertiseLevelString from Skills where EmpName = '" + EmpFirstName + "' and EmpLastName = '" + EmpLastName + "'";
                var adp = new SqlDataAdapter(cmd, myCon);
                adp.Fill(dt);
                return dt;
            }
        }

        //get maximum expertise level for each skill on team
        public static DataTable GetSkillsTeamData(string selectedTeam, string expertiseLevel)
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                var dt = new DataTable();
                var cmd = "SELECT Skill, MAX(ExpertiseLevel) ExpertiseLevel FROM Skills where SelectedTeam = '" + selectedTeam + 
                    "' and ExpertiseLevel " + expertiseLevel + " GROUP BY Skill";
                var adp = new SqlDataAdapter(cmd, myCon);
                adp.Fill(dt);
                return dt;
            }
        }

        //returns all skills and accompanying expertise levels from skills table
        public static DataTable GetSkillsData()
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                var dt = new DataTable();
                var cmd = "select Skill,ExpertiseLevel from Skills";
                var adp = new SqlDataAdapter(cmd, myCon);
                adp.Fill(dt);
                return dt;
            }
        }

        //Get all data from a selected skill
        public static DataTable GetSelectedSkillsData(string selectedSkill)
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                var dt = new DataTable();
                var cmd = "select Skill, EmpName, EmpLastName, ExpertiseLevel, ExpertiseLevelString from Skills where Skill = '" + selectedSkill + "'";
                var adp = new SqlDataAdapter(cmd, myCon);
                adp.Fill(dt);
                return dt;
            }
        }

        //returns first name, last name of each employee
        public static DataTable GetAllEmployeesDataTable()
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                var dt = new DataTable();
                var cmd = "select Distinct EmpName, EmpLastName from Skills";
                var adp = new SqlDataAdapter(cmd, myCon);
                adp.Fill(dt);
                return dt;
            }
        }

        //returns employees selected team
        public static string GetSelectedEmployeesTeam(string EmpFirstName, string EmpLastName)
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                var cmd = new SqlCommand(
                        "Select SelectedTeam from Skills Where EmpName = '" + EmpFirstName + "' and EmpLastName = '" + EmpLastName + "'",
                        myCon);
                myCon.Open();
                string SelectedTeam = cmd.ExecuteScalar().ToString();
                myCon.Close();
                return SelectedTeam;
            }
        }

        //Returns expertise level when enter name and skill
        public static int GetExpertiseLevel(string EmpFirstName, string EmpLastName, string Skill)
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                var cmd = new SqlCommand(
                        "Select ExpertiseLevel from Skills Where EmpName = '" + EmpFirstName + "' and EmpLastName = '" + EmpLastName + "' and Skill = '" + Skill + "'",
                        myCon);
                myCon.Open();
                int intExpertiseLevel =  int.Parse(cmd.ExecuteScalar().ToString());
                myCon.Close();
                return intExpertiseLevel;
            }
        }

        //Returns list of all distinct skills of an employee
        public static List<string> GetSelectedEmployeesSkills(string EmpFirstName, string EmpLastName)
        {
            var lstSkills = new List<string>();

            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                //The SQL you want to execute
                var cmd = new SqlCommand(
                            "Select Distinct Skill from Skills Where EmpName = '" + EmpFirstName + "' and EmpLastName = '" + EmpLastName + "'",
                            myCon);
                //Open the connection to the database
                myCon.Open();
                //execute your command
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    //Loop through your results
                    while (dataReader.Read())
                    {
                        lstSkills.Add(Convert.ToString(dataReader["Skill"]).ToUpper());
                    }
                }
                myCon.Close();
            }
            return lstSkills;
        }

        //returns all distinct skills in list format
        public static List<string> GetAllSkills()
        {
            var lstSkills = new List<string>();

            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                //The SQL you want to execute
                var cmd = new SqlCommand(
                            "Select Distinct Skill from Skills",
                            myCon);
                //Open the connection to the database
                myCon.Open();
                //execute your command
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    //Loop through your results
                    while (dataReader.Read())
                    {
                        lstSkills.Add(Convert.ToString(dataReader["Skill"]).ToUpper());
                    }
                }
                myCon.Close();
            }
            return lstSkills;
        }

        //returns a list of all the distinct teams
        public static List<string> GetAllTeams()
        {
            var lstTeams = new List<string>();

            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                //The SQL you want to execute
                var cmd = new SqlCommand(
                            "Select Distinct SelectedTeam from Skills",
                            myCon);
                //Open the connection to the database
                myCon.Open();
                //execute your command
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    //Loop through your results
                    while (dataReader.Read())
                    {
                        lstTeams.Add(Convert.ToString(dataReader["SelectedTeam"]).ToUpper());
                    }
                }
                myCon.Close();
            }
            return lstTeams;
        }

        //returns all distinct skills from selected team in list
        public static List<string> GetSelectedTeamSkills(string selectedTeam)
        {
            var lstSkills = new List<string>();

            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                //The SQL you want to execute
                var cmd = new SqlCommand(
                            "Select Distinct Skill from Skills where SelectedTeam = '" + selectedTeam + "'",
                            myCon);
                //Open the connection to the database
                myCon.Open();
                //execute your command
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    //Loop through your results
                    while (dataReader.Read())
                    {
                        lstSkills.Add(Convert.ToString(dataReader["Skill"]).ToUpper());
                    }
                }
                myCon.Close();
            }
            return lstSkills;
        }

        //returns two column list of employee names (first, last)
        public static List<Tuple<string, string>> GetTeamMembers(string TeamName)
        {
            //List<string> lstFirstName = new List<string>();
            var lst = new List<Tuple<string, string>>();

            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                //The SQL you want to execute
                var cmd = new SqlCommand(
                            "Select Distinct EmpName, EmpLastName from Skills Where SelectedTeam = '" + TeamName + "'",
                            myCon);
                //Open the connection to the database
                myCon.Open();
                //execute your command
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    //Loop through your results
                    while (dataReader.Read())
                    {
                        lst.Add(new Tuple<string, string>((Convert.ToString(dataReader["EmpName"])), (Convert.ToString(dataReader["EmpLastName"]))));
                    }
                }
                myCon.Close();
            }   
            return lst;
        }

        //method to update employee's selected team in database
        public static void UpdateSelectedTeamInSkillsDb(string EmpFirstName, string EmpLastName, string SelectedTeam)
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                var dt = new DataTable();
                dt = GetSkillsData();
                {
                    var xp =
                        new SqlCommand(
                            "Update Skills SET SelectedTeam = '" + SelectedTeam + "' Where EmpName = '" + EmpFirstName + "' and EmpLastName = '" + EmpLastName + "'",
                            myCon);

                    myCon.Open();
                    xp.ExecuteNonQuery();
                    myCon.Close();
                }
            }
        }

        public static void UpdateDataRowInSkillsDb(string EmpFirstName, string Skill, string ExpertiseLevelNum, string EmpLastName, string ExpertiseLevelString, string SelectedTeam)
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                var dt = new DataTable();
                dt = GetSkillsData();
                {
                    var xp =
                        new SqlCommand(
                            "Update Skills SET ExpertiseLevel = '" + ExpertiseLevelNum + "', ExpertiseLevelString = '" + ExpertiseLevelString + "', SelectedTeam = '" + SelectedTeam + "' Where EmpName = '" + EmpFirstName + "' and EmpLastName = '" + EmpLastName + "' and Skill = '" + Skill + "'",
                            myCon);

                    myCon.Open();
                    xp.ExecuteNonQuery();
                    myCon.Close();
                }
            }
        }

        public static void DeleteDataRowInSkillsDb(string EmpFirstName, string Skill, string EmpLastName)
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                var dt = new DataTable();
                dt = GetSkillsData();
                {
                    var xp =
                        new SqlCommand(
                            "Delete From Skills Where EmpName = '" + EmpFirstName + "' and EmpLastName = '" + EmpLastName + "' and Skill = '" + Skill + "'",
                            myCon);

                    myCon.Open();
                    xp.ExecuteNonQuery();
                    myCon.Close();
                }
            }
        }

        public static void InsertNewDataRowInSkillsDb(string EmpFirstName, string Skill, string ExpertiseLevelNum, string EmpLastName, string ExpertiseLevelString, string SelectedTeam)
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                int newId = GetLastRowIdFromSkills() + 1;
                {
                    var xp =
                        new SqlCommand(
                            "Insert into Skills(Id, EmpName, Skill, ExpertiseLevel, EmpLastName, ExpertiseLevelString, SelectedTeam) Values(@Id, @EmpName, @Skill, @ExpertiseLevel, @EmpLastName, @ExpertiseLevelString, @SelectedTeam)",
                            myCon);
                    xp.Parameters.AddWithValue("@Id", newId);
                    xp.Parameters.AddWithValue("@EmpName", EmpFirstName);
                    xp.Parameters.AddWithValue("@Skill", Skill);
                    xp.Parameters.AddWithValue("@ExpertiseLevel", ExpertiseLevelNum);
                    xp.Parameters.AddWithValue("@EmpLastName", EmpLastName);
                    xp.Parameters.AddWithValue("@ExpertiseLevelString", ExpertiseLevelString);
                    xp.Parameters.AddWithValue("@SelectedTeam", SelectedTeam);

                    myCon.Open();
                    xp.ExecuteNonQuery();
                    myCon.Close();
                }
            }
        }

        public static int GetLastRowIdFromSkills()
        {
            using (SqlConnection myCon = new SqlConnection(connStr))
            {
                var cmd =
                        new SqlCommand(
                            "Select MAX(Id) From Skills",
                            myCon);

                myCon.Open();
                int LastRowId = int.Parse(cmd.ExecuteScalar().ToString());
                myCon.Close();
                return LastRowId;
            }
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

        public static string BindChart(string EmpFirstName, string EmpLastName, int chartNum, int width, int height, string colour, bool IncludeTitle)
        {
            StringBuilder str = new StringBuilder();
            var dt = new DataTable();
            try
            {
                dt = GetSelectedEmployeeData(EmpFirstName, EmpLastName);
               

                //data
                str.Append("google.setOnLoadCallback(drawChart" + chartNum + ");");
                str.Append("function drawChart" + chartNum + "() {");
                str.Append("var data" + chartNum + " = new google.visualization.DataTable();");
                str.Append("data" + chartNum + ".addColumn('string', 'Skill');");
                str.Append("data" + chartNum + ".addColumn('number', 'ExpertiseLevel');");
                str.Append("data" + chartNum + ".addColumn({type:'string', role:'annotation'});");
                str.Append("data" + chartNum + ".addColumn({type:'string', role:'style'});");

                str.Append("data" + chartNum + @".addRows(" + dt.Rows.Count + ");");

                for (var i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    str.Append("data" + chartNum + ".setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["Skill"] + "');");
                    str.Append("data" + chartNum + ".setValue(" + i + "," + 1 + "," + dt.Rows[i]["ExpertiseLevel"] + ") ;");
                    str.Append("data" + chartNum + ".setValue( " + i + "," + 2 + "," + "'" + dt.Rows[i]["ExpertiseLevelString"] + "');");
                    str.Append("data" + chartNum + ".setValue(" + i + "," + 3 + ",'stroke-color: #006600; stroke-opacity: 0.8; stroke-width: 2; fill-color: " + colour + "; fill-opacity: 0.8');");
                }

                //options
                str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div" + chartNum + "'));");
                str.Append(" chart.draw(data" + chartNum + ", {width: " + width + ", height: " + height + ",");
                if (IncludeTitle == true)
                {
                    str.Append("title: 'Skill Chart: " + EmpFirstName + "',");
                }
                str.Append("hAxis: { textPosition: 'none', maxValue: 4, minValue: 0 },");
                str.Append("legend: { position: 'none' },");
                str.Append("chartArea: {width: '70%', height: '80%'},");
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

        public static string CreateTeamStrengthChart(string EmpFirstName, string selectedTeam, int chartNum, int width, int height, bool isStrongTeam, string colour)
        {
            StringBuilder str = new StringBuilder();
            var dt = new DataTable();
            var ExpertiseLevelString = "";
            var chartTitle = "";
            
            try
            {
                if (isStrongTeam == true)
                {
                    dt = GetSkillsTeamData(selectedTeam, ">= 3");
                    chartTitle = "Skill Chart: " + selectedTeam + " (Strong Skills)";
                }
                else
                {
                    dt = GetSkillsTeamData(selectedTeam, "< 3");
                    chartTitle = "Skill Chart: " + selectedTeam + " (Weak Skills)";
                }
                

                //data
                str.Append("google.setOnLoadCallback(drawChart" + chartNum + ");");
                str.Append("function drawChart" + chartNum + "() {");
                str.Append("var data" + chartNum + " = new google.visualization.DataTable();");
                str.Append("data" + chartNum + ".addColumn('string', 'Skill');");
                str.Append("data" + chartNum + ".addColumn('number', 'ExpertiseLevel');");
                str.Append("data" + chartNum + ".addColumn({type:'string', role:'annotation'});");
                str.Append("data" + chartNum + ".addColumn({type:'string', role:'style'});");

                str.Append("data" + chartNum + @".addRows(" + dt.Rows.Count + ");");

                for (var i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    int expertiseLevelInt = int.Parse(dt.Rows[i]["ExpertiseLevel"].ToString());
                    switch (expertiseLevelInt)
                    {
                        case 1:
                            ExpertiseLevelString = "Beginner";
                            break;
                        case 2:
                            ExpertiseLevelString = "Intermediate";
                            break;
                        case 3:
                            ExpertiseLevelString = "Proficient";
                            break;
                        case 4:
                            ExpertiseLevelString = "Advanced";
                            break;
                        case 5:
                            ExpertiseLevelString = "SME";
                            break;
                        default:
                            ExpertiseLevelString = "Beginner";
                            break;
                    }
                    str.Append("data" + chartNum + ".setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["Skill"] + "');");
                    str.Append("data" + chartNum + ".setValue(" + i + "," + 1 + "," + dt.Rows[i]["ExpertiseLevel"] + ") ;");
                    str.Append("data" + chartNum + ".setValue( " + i + "," + 2 + "," + "'" + ExpertiseLevelString + "');");
                    str.Append("data" + chartNum + ".setValue(" + i + "," + 3 + ",'stroke-color: #006600; stroke-opacity: 0.8; stroke-width: 2; fill-color: " + colour + "; fill-opacity: 0.8');");
                }

                //options
                str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div" + chartNum + "'));");
                str.Append(" chart.draw(data" + chartNum + ", {width: " + width + ", height: " + height + ",");
                str.Append("title: '" + chartTitle + "',");
                str.Append("hAxis: { textPosition: 'none', maxValue: 4, minValue: 0 },");
                str.Append("legend: { position: 'none' },");
                str.Append("chartArea: {width: '70%', height: '80%'},");
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


        public static string CreateSkillSpecificChart(string selectedSkill, int chartNum, int width, int height, string colour, bool IncludeTitle)
        {
            StringBuilder str = new StringBuilder();
            var dt = new DataTable();
            try
            {
                dt = GetSelectedSkillsData(selectedSkill);

                //data
                str.Append("google.setOnLoadCallback(drawChart" + chartNum + ");");
                str.Append("function drawChart" + chartNum + "() {");
                str.Append("var data" + chartNum + " = new google.visualization.DataTable();");
                str.Append("data" + chartNum + ".addColumn('string', 'EmpName');");
                str.Append("data" + chartNum + ".addColumn('number', 'ExpertiseLevel');");
                str.Append("data" + chartNum + ".addColumn({type:'string', role:'annotation'});");
                str.Append("data" + chartNum + ".addColumn({type:'string', role:'style'});");

                str.Append("data" + chartNum + @".addRows(" + dt.Rows.Count + ");");

                for (var i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    str.Append("data" + chartNum + ".setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["EmpName"] + " " + dt.Rows[i]["EmpLastName"] + "');");
                    str.Append("data" + chartNum + ".setValue(" + i + "," + 1 + "," + dt.Rows[i]["ExpertiseLevel"] + ") ;");
                    str.Append("data" + chartNum + ".setValue( " + i + "," + 2 + "," + "'" + dt.Rows[i]["ExpertiseLevelString"] + "');");
                    str.Append("data" + chartNum + ".setValue(" + i + "," + 3 + ",'stroke-color: #006600; stroke-opacity: 0.8; stroke-width: 2; fill-color: " + colour + "; fill-opacity: 0.8');");
                }

                //options
                str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div" + chartNum + "'));");
                str.Append(" chart.draw(data" + chartNum + ", {width: " + width + ", height: " + height + ",");
                if (IncludeTitle == true)
                {
                    str.Append("title: 'Skill Chart: " + selectedSkill + "',");
                }
                str.Append("hAxis: { textPosition: 'none', maxValue: 4, minValue: 0 },");
                str.Append("legend: { position: 'none' },");
                str.Append("chartArea: {width: '70%', height: '80%'},");
                str.Append("animation: {duration: 1500, startup: true, easing: 'out'},");
                str.Append("vAxis: { title: 'Employee Name' },");
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