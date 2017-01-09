using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP
{
    public partial class EnterDetailsPage : System.Web.UI.Page
    {
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
        }

    }
}