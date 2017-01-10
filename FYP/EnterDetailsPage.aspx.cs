using FYP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FYP
{
    public partial class EnterDetailsPage : System.Web.UI.Page
    {

        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[
            "Database1ConnectionString1"].ConnectionString);
        static int newRowIndex = 3;


        protected void Page_Load(object sender, EventArgs e)
        {
            var container = Master.FindControl("MainContent");
            int DropDownListIndex = 1;

            //populate the dropdownlist for expertise level
            for(DropDownListIndex = 1; DropDownListIndex < 4; DropDownListIndex++)
            {
                string controlNamelstExpertiseLevel = "lstExpertiseLevel" + DropDownListIndex.ToString();
                var controllstExpertiseLevel = container.FindControl(controlNamelstExpertiseLevel);
                DropDownList lstExpertiseLevel = (DropDownList)controllstExpertiseLevel;
                lstExpertiseLevel.Visible = true;

                lstExpertiseLevel.Items.Add("Beginner");
                lstExpertiseLevel.Items.Add("Intermediate");
                lstExpertiseLevel.Items.Add("Proficient");
                lstExpertiseLevel.Items.Add("Advanced");
                lstExpertiseLevel.Items.Add("SME");
            }
        }


        protected void AddSkill_Click(object sender, EventArgs e)
        {
            newRowIndex++;

            var container = Master.FindControl("MainContent");

            string controlNamelblSkill = "Skill" + newRowIndex.ToString();
            var controllblSkill = container.FindControl(controlNamelblSkill);
            controllblSkill.Visible = true;

            string controlNametxtSkill = "txtSkill" + newRowIndex.ToString();
            var controltxtSkill = container.FindControl(controlNametxtSkill);
            controltxtSkill.Visible = true;

            string controlNamelblExpertiseLevel = "ExpertiseLevel" + newRowIndex.ToString();
            var controllblExpertiseLevel = container.FindControl(controlNamelblExpertiseLevel);
            controllblExpertiseLevel.Visible = true;

            string controlNamelstExpertiseLevel = "lstExpertiseLevel" + newRowIndex.ToString();
            var controllstExpertiseLevel = container.FindControl(controlNamelstExpertiseLevel);
            DropDownList lstExpertiseLevel = (DropDownList)controllstExpertiseLevel;
            lstExpertiseLevel.Visible = true;

            //Populate the DropDownList
            lstExpertiseLevel.Items.Add("Beginner");
            lstExpertiseLevel.Items.Add("Intermediate");
            lstExpertiseLevel.Items.Add("Proficient");
            lstExpertiseLevel.Items.Add("Advanced");
            lstExpertiseLevel.Items.Add("SME");


            if (newRowIndex > 7)
            {
                btnAddSkill.Enabled = false;
                ErrorMessage.Text = "Maximum number of skills added. A user cannot enter more than 8 Skills so please prioritise based on level of expertise";
            }

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var currentUserId = User.Identity.GetUserId();
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            string EmpFirstName = currentUser.FirstName;
            string EmpLastName = currentUser.LastName;
            int rowNum = 1;

            for (rowNum = 1; rowNum < 9; rowNum++)
            {
                string controlNameSkill = "txtSkill" + rowNum.ToString();
                var containerSkill = Master.FindControl("MainContent");
                var controlSkill = containerSkill.FindControl(controlNameSkill);
                TextBox txtSkill = (TextBox)controlSkill;

                string controlNameExpertiseLevel = "lstExpertiseLevel" + rowNum.ToString();
                var containerExpertiseLevel = Master.FindControl("MainContent");
                var controlExpertiseLevel = containerExpertiseLevel.FindControl(controlNameExpertiseLevel);
                DropDownList lstExpertiseLevel = (DropDownList)controlExpertiseLevel;

                if (txtSkill == null)
                {
                    break;
                }

                if ((txtSkill.Text != ""))
                {
                    int intExpertiseLevel;

                    switch (lstExpertiseLevel.SelectedIndex)
                    {
                        case 0:
                            intExpertiseLevel = 1;
                            break;
                        case 1:
                            intExpertiseLevel = 2;
                            break;
                        case 2:
                            intExpertiseLevel = 3;
                            break;
                        case 3:
                            intExpertiseLevel = 4;
                            break;
                        case 4:
                            intExpertiseLevel = 5;
                            break;
                        default:
                            intExpertiseLevel = 1;
                            break;
                    }

                    var dt = new DataTable();
                    dt = GetSkillsData();
                    {
                        var xp =
                            new SqlCommand(
                                "Insert into Skills(Id, EmpName, Skill, ExpertiseLevel, EmpLastName, ExpertiseLevelString) Values(@Id, @EmpName, @Skill, @ExpertiseLevel, @EmpLastName, @ExpetiseLevelString)",
                                conn);
                        var newId = (dt.Rows.Count + 1).ToString();
                        xp.Parameters.AddWithValue("@Id", newId);
                        xp.Parameters.AddWithValue("@EmpName", EmpFirstName);
                        xp.Parameters.AddWithValue("@Skill", txtSkill.Text);
                        xp.Parameters.AddWithValue("@ExpertiseLevel", intExpertiseLevel.ToString());
                        xp.Parameters.AddWithValue("@EmpLastName", EmpLastName);
                        xp.Parameters.AddWithValue("@ExpertiseLevelString", lstExpertiseLevel.SelectedValue);

                        conn.Open();
                        xp.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

            IdentityHelper.RedirectToReturnUrl("/HomePage.aspx", Response);

        }

        private static DataTable GetSkillsData()
        {
            var dt = new DataTable();
            var cmd = "select Skill,ExpertiseLevel from Skills";
            var adp = new SqlDataAdapter(cmd, conn);
            adp.Fill(dt);
            return dt;
        }

    }
}