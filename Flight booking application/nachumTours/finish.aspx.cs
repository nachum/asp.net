﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nachumTours
{
    public partial class finish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string all = (string)Session["passengers"];
            passengersLabel.Text = all;
            passengersLabel.Font.Size = 14;

        }
    }
}