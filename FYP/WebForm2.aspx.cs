using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            string[] names = { "Ram", "Ankit", "Sam", "Sahil", "Rajan", "Sajan" };
            var namesList = from tmp in names where tmp.ToLower().StartsWith(prefixText) select tmp;
            return namesList.ToArray();
        }
    }
}