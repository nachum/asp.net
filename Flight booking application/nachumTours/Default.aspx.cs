using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;


namespace nachumTours
{
    public partial class _Default : Page
    {
        public List<int> days = new List<int>();
        public Boolean done = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            FlightsBL fb = new FlightsBL();
            LinkedList<string> countries=fb.GetAllCountries();
            if (!Dmonth.AutoPostBack)
            {
                Dmonth.AutoPostBack = true;
                done = true;
                foreach (string s in countries)
                {
                    deaparture.Items.Add(s);
                    Arrival.Items.Add(s);
                }
                Dday.Enabled = false;
                loadMonth();
                loadYear();
                loadPeople();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string dCountry = deaparture.SelectedValue;
            string dMonth = Dmonth.SelectedValue;
            int dDay = 0; ;
            if(!Dday.SelectedValue.Equals(""))
                dDay = Convert.ToInt32(Dday.SelectedValue);
            int dYear = 0;
            if(!Dyear.SelectedValue.Equals(""))
                dYear = Convert.ToInt32(Dyear.SelectedValue);
            
            string aCountry = Arrival.SelectedValue;
            string aMonth = Amonth.SelectedValue;
            int aDay = 0; ;
            if (!Aday.SelectedValue.Equals(""))
                aDay = Convert.ToInt32(Aday.SelectedValue);
            int aYear = 0;
            if (!Ayear.SelectedValue.Equals(""))
                aYear = Convert.ToInt32(Ayear.SelectedValue);

            Boolean round;
            if (RoundCheckBox.Checked)
                round = true;
            else
                round = false;


            Boolean direct;
            if (directOnly.Checked)
                direct = true;
            else
                direct = false;

            if (dCountry.Equals("") || dMonth.Equals("") || dDay==0 || dYear==0 ||
                aCountry.Equals(""))
            {
                Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Please fill in all the fields</p>");
            }
            else if (round && (aMonth.Equals("") || aDay == 0 || aYear == 0))
                Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Please fill in all the fields</p>");
            else
            {
                Session["dDay"] = dDay;
                Session["dMonth"] = dMonth;
                Session["dYear"] = dYear;
                Session["dCountry"] = dCountry;

                Session["aCountry"] = aCountry;
                if (round)
                {
                    Session["aMonth"] = aMonth;
                    Session["aYear"] = aYear;
                    Session["aDay"] = aDay;
                }
                Session["isRound"] = round;
                Session["isDirect"] = direct;

                Session["adultsNum"] = (adultsDropDownList.SelectedValue);
               Session["childNum"] = (childDropDownList.SelectedValue);
                Session["tickClass"]= classDropDownList.SelectedValue;

                Response.Redirect("flightTable.aspx");
            }
        }

        protected void Dmonth_Load(object sender, EventArgs e)
        {
            
        }

        private void loadMonth()
        {
            //Dmonth.Items.Clear();
            LinkedList<string> months = new LinkedList<string>();
            months.AddLast("");
            months.AddLast("January");
            months.AddLast("February");
            months.AddLast("March");
            months.AddLast("April");
            months.AddLast("May");
            months.AddLast("June");
            months.AddLast("July");
            months.AddLast("August");
            months.AddLast("September");
            months.AddLast("October");
            months.AddLast("November");
            months.AddLast("December");
            foreach (string s in months)
            {
                Dmonth.Items.Add(s);
                Amonth.Items.Add(s);
            }

        }

        private void loadPeople()
        {
            int i;
            for(i=1;i<9;i++)
            {
                adultsDropDownList.Items.Add(Convert.ToString(i));
            }
            for (i = 0; i < 5; i++)
            {
                childDropDownList.Items.Add(Convert.ToString(i));
            }
            classDropDownList.Items.Add("Economy");
            classDropDownList.Items.Add("Business Class");
            classDropDownList.Items.Add("First Class");

        }

        protected void Dmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dday.Items.Clear();
            int days = 0;
            if (Dmonth.SelectedItem != null)
            {
                string month = Dmonth.SelectedValue;
                
                Dday.Enabled = true;
                Dday.ToolTip = "Choose day";
                
                if(month.Equals("January") || month.Equals ("March") ||month.Equals("May") || month.Equals("July") || month.Equals("August") || month.Equals("October") || month.Equals("December"))
                    days=31;
                else if(month.Equals("February"))
                    days=28;
                else if(month.Equals("April") || month.Equals("June") || month.Equals("September") || month.Equals("November"))
                    days=30;


                }
                loadDays(days,Dday);
            }
        

        private void loadDays(int num, DropDownList d)
        {
            d.Items.Add("");
            for (int i = 1; i <= num; i++)
            {
                d.Items.Add(Convert.ToString(i));
            }
        }

        private void loadYear()
        {
            Dyear.Items.Add("2013");
            Dyear.Items.Add("2014");
            Dyear.Items.Add("2015");
            Ayear.Items.Add("2013");
            Ayear.Items.Add("2014");
            Ayear.Items.Add("2015");
        }

        protected void Amonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Aday.Items.Clear();
            int days = 0;
            if (Dmonth.SelectedItem != null)
            {
                string month = Amonth.SelectedValue;
                Aday.Enabled = true;
                Aday.ToolTip = "Choose day";
                
                if(month.Equals("January") || month.Equals ("March") ||month.Equals("May") || month.Equals("July") || month.Equals("August") || month.Equals("October") || month.Equals("December"))
                    days=31;
                else if(month.Equals("February"))
                    days=28;
                else if(month.Equals("April") || month.Equals("June") || month.Equals("September") || month.Equals("November"))
                    days=30;


                }
                loadDays(days,Aday);
            }

        protected void OneWayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OneWayCheckBox.Checked)
            {
                RoundCheckBox.Checked = false;
                roundLabel.ForeColor = Color.FromName("#e799d3");
                oneLabel.ForeColor = Color.White;
                Amonth.Visible = false;
                Aday.Visible = false;
                Ayear.Visible = false;
                OneWayCheckBox.Enabled = false;
                RoundCheckBox.Enabled = true;
                returnLabel.Visible = false;
            }
            
       }

        protected void RoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RoundCheckBox.Checked)
            {
                OneWayCheckBox.Checked = false;
                oneLabel.ForeColor = Color.FromName("#e799d3");
                roundLabel.ForeColor = Color.White;
                Amonth.Visible = true;
                Aday.Visible = true;
                Ayear.Visible = true;
                OneWayCheckBox.Enabled = true;
                RoundCheckBox.Enabled = false;
                returnLabel.Visible = true;
                
            }
        }

        protected void prRaButton_Click(object sender, EventArgs e)
        {
            prRaButton.Visible = false;
            minLabel.Visible = true;
            minTextBox.Visible = true;
            maxLabel.Visible = true;
            maxTextBox.Visible = true;
            getButton.Visible = true;

        }

        protected void getButton_Click(object sender, EventArgs e)
        {
            if (minTextBox.Text.Equals("") || maxTextBox.Text.Equals(""))
                Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Please fill in all the fields</p>");
            else
            {
                string priceFlight = "";
                string resultString = Regex.Match(minTextBox.Text.Trim(), @"\d+").Value;
                if (resultString.Equals(""))
                {
                    Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Not a number</p>");
                    return;
                }
                double min = Double.Parse(resultString);
                resultString = Regex.Match(minTextBox.Text.Trim(), @"\d+").Value;
                if (resultString.Equals(""))
                {
                    Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Not a number</p>");
                    return;
                }
                double max = Double.Parse(resultString);
                
                //double min = Convert.ToDouble(minTextBox.Text.Trim());
               // double max = Convert.ToDouble(maxTextBox.Text.Trim());
                FlightsBL fb = new FlightsBL();
                LinkedList<Flight_Deatails> betFlights = fb.GetFlightsBetweenPrice(min,max);
                if (betFlights == null)
                {
                    Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">No flights were found</p>");
                    return;
                }
                foreach (Flight_Deatails fd in betFlights)
                {
                    Flights fl = fb.GetFlight(fd.getFlightNumber());
                    priceFlight += "<div id=betPrices>"
                        +"Flight number: "+fl.getFlightNumber()+",  From: "+fl.getFrom()+",  To: "+fl.getTo()+"<br/>"
                        + "Date: " + fl.getDate() + ", Time: " + calculateTime(fd.getDeapartTime(), 0) + "<br/>"
                        + "Price: " + fd.getPrice() + "$" + "<br/>"
                        + "</div>";
                }
                prRaButton.Visible = true;
                minLabel.Visible = false;
                minTextBox.Visible = false;
                maxLabel.Visible = false;
                maxTextBox.Visible = false;
                getButton.Visible = false;
                Session["pricesBet"] = priceFlight;
                Response.Redirect("flightsBetween.aspx");
            }
        }

        private string calculateTime(double accualTime, double addTime)
        {
            TimeSpan interval = TimeSpan.FromHours(accualTime);
            TimeSpan addInterval = TimeSpan.FromHours(addTime);
            interval = interval.Add(addInterval);

            return interval.ToString();
        }

        protected void dateBu_Click(object sender, EventArgs e)
        {
            dateBu.Visible = false;
            stLabel.Visible = true;
            stTextBox.Visible = true;
            endLabel.Visible = true;
            endTextBox.Visible = true;
            getDateButton.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (stTextBox.Text.Equals("") || endTextBox.Text.Equals(""))
                Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Please fill in all the fields</p>");
            else
            {
                string dateFlight = "";
                DateTime start = Convert.ToDateTime(stTextBox.Text.Trim());
                DateTime end = Convert.ToDateTime(endTextBox.Text.Trim());
                FlightsBL fb = new FlightsBL();
                LinkedList<Flights> betFlights = fb.GetFlightsBetweenDate(start, end);
                if (betFlights == null)
                {
                    Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">No flights were found</p>");
                    return;
                }
                foreach (Flights fl in betFlights)
                {
                    Flight_Deatails fd = fb.GetFlightDeatails(fl.getFlightNumber());
                    dateFlight += "<div id=betPrices>"
                        + "Flight number: " + fl.getFlightNumber() + ",  From: " + fl.getFrom() + ",  To: " + fl.getTo() + "<br/>"
                        + "Date: " + fl.getDate() + ", Time: " + calculateTime(fd.getDeapartTime(), 0) + "<br/>"
                        + "Price: " + fd.getPrice() + "$" + "<br/>"
                        + "</div>";
                }
                dateBu.Visible = true;
                stLabel.Visible = false;
                stTextBox.Visible = false;
                endLabel.Visible = false;
                endTextBox.Visible = false;
                getDateButton.Visible = false;
                Session["pricesBet"] = dateFlight;
                Response.Redirect("flightsBetween.aspx");
            }
        }
    }
}

