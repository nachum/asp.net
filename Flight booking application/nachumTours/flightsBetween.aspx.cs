using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nachumTours
{
    public partial class flightsBetween : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string temp=(string)Session["pricesBet"];
            if (temp.Equals(""))
                betLabel.Text = "No flights were found";
            betLabel.Text = temp;
        }
    }
}