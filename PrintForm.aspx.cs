using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinalProject
{
    public partial class PrintForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbName.Text = Session["TeachName"].ToString();
            lbStrDate.Text = Session["DayOne"].ToString();
            lbStrTime.Text = Session["TimeStr"].ToString();
            lbEndTime.Text = Session["TimeEnd"].ToString();

            string i = Session["Room"].ToString();

            if(i == "952")
            {
                cbRoom952.Checked.Equals(true);
            }
            else if (Session["Room"].ToString() == "953")
            {
                cbRoom953.Checked.Equals(true);
            }
            else if (Session["Room"].ToString() == "962")
            {
                cbRoom962.Checked.Equals(true);
            }
            else if (Session["Room"].ToString() == "963")
            {
                cbRoom963.Checked.Equals(true);
            }
            else if (Session["Room"].ToString() == "971")
            {
                cbRoom971.Checked.Equals(true);
            }
            else if (Session["Room"].ToString() == "972")
            {
                cbRoom972.Checked.Equals(true);
            }
            else if (Session["Room"].ToString() == "973")
            {
                cbRoom973.Checked.Equals(true);
            }
            else if (Session["Room"].ToString() == "981")
            {
                cbRoom981.Checked.Equals(true);
            }
            else if (Session["Room"].ToString() == "982")
            {
                cbRoom982.Checked.Equals(true);
            }
            else if (Session["Room"].ToString() == "983")
            {
                cbRoom983.Checked.Equals(true);
            }
        }
    }
}