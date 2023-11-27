using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ilias_Otsman_ASP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TestBtn_Click(object sender, EventArgs e)
        {
            TestBtn.Text = "You have clicked!";
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListDays.SelectedIndex != -1)
                LabelDay.Text = "Día seleccionado: " + ListDays.SelectedItem.Text;
            else
                LabelDay.Text = "No has seleccionado ningún día";
        }
    }
}