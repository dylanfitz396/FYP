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


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        TextBox tb;
        TextBox tb1;
        Label lb;
        Label lb1;
        static int i = 0;

        protected void addnewtext_Click(object sender, EventArgs e)
        {
            i++;
            int j;
            for (j = 0; j < i; j++)
            {
                int rowNum = j + 4;

                lb = new Label();
                lb.ID = "Skill" + rowNum.ToString();
                lb.Text = "Skill " + rowNum.ToString() + ":";
                lb.CssClass = "col-md-2 control-label";
                tb = new TextBox();
                tb.ID = "txtSkill" + rowNum.ToString();
                tb.CssClass = "form-control";

                lb1 = new Label();
                lb1.ID = "ExpertiseLevel" + rowNum.ToString();
                lb1.Text = "Expertise Level " + rowNum.ToString() + ":";
                lb1.CssClass = "col-md-3 control-label";
                tb1 = new TextBox();
                tb1.ID = "txtExpertiseLevel" + rowNum.ToString();
                tb1.CssClass = "form-control";

                PlaceHolder1.Controls.Add(lb);
                PlaceHolder1.Controls.Add(tb);
                
                PlaceHolder2.Controls.Add(lb1);
                PlaceHolder2.Controls.Add(tb1);
            }

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var currentUserId = User.Identity.GetUserId();
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            string EmpFirstName = currentUser.FirstName;
            string EmpLastName = currentUser.LastName;

            i++;

            for (i = 1; i < 11; i++)
            {
                string controlNameSkill = "txtSkill" + i.ToString();
                var containerSkill = Master.FindControl("MainContent");
                var controlSkill = containerSkill.FindControl(controlNameSkill);
                TextBox txtSkill = (TextBox)controlSkill;

                string controlNameExpertiseLevel = "txtExpertiseLevel" + i.ToString();
                var containerExpertiseLevel = Master.FindControl("MainContent");
                var controlExpertiseLevel = containerExpertiseLevel.FindControl(controlNameExpertiseLevel);
                TextBox txtExpertiseLevel = (TextBox)controlExpertiseLevel;

                if (txtSkill == null)
                {
                    break;
                }

                if ((txtSkill.Text != "") && (txtExpertiseLevel.Text != ""))
                {
                    var dt = new DataTable();
                    dt = GetData();
                    {
                        var xp =
                            new SqlCommand(
                                "Insert into Skills(Id, EmpName, Skill, ExpertiseLevel, EmpLastName) Values(@Id, @EmpName, @Skill, @ExpertiseLevel, @EmpLastName)",
                                conn);
                        var newId = (dt.Rows.Count + 1).ToString();
                        xp.Parameters.AddWithValue("@Id", newId);
                        xp.Parameters.AddWithValue("@EmpName", EmpFirstName);
                        xp.Parameters.AddWithValue("@Skill", txtSkill.Text);
                        xp.Parameters.AddWithValue("@ExpertiseLevel", txtExpertiseLevel.Text);
                        xp.Parameters.AddWithValue("@EmpLastName", EmpLastName);

                        conn.Open();
                        xp.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

        IdentityHelper.RedirectToReturnUrl("/HomePage.aspx", Response);

        }

        private static DataTable GetData()
        {
            var dt = new DataTable();
            var cmd = "select Skill,ExpertiseLevel from Skills";
            var adp = new SqlDataAdapter(cmd, conn);
            adp.Fill(dt);
            return dt;
        }

    }
}