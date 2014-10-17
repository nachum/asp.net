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

namespace nachumTours
{
    public partial class AdminZone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if ((numberTextBox.Text.Equals("") || fromTextBox.Text.Equals("") || toTextBox.Text.Equals("") || dateTextBox.Text.Equals("") ||
                 durationTextBox.Text.Equals("") || priceTextBox.Text.Equals("") || departTextBox.Text.Equals("") || airlineDropDownList.SelectedValue.Equals("") ||
                seatsTextBox.Text.Equals("")))
            {
                Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Fill in all the fields</p>");
            }
            else
            {
                FlightsBL bl = new FlightsBL();
                bl.addCountry(fromTextBox.Text.Trim());
                bl.addCountry(toTextBox.Text.Trim());
                int flightNum=Convert.ToInt32((string)numberTextBox.Text.Trim());
                Flights fl=new Flights(flightNum,fromTextBox.Text.Trim(),toTextBox.Text.Trim(),dateTextBox.Text.Trim());
                Boolean flWorked=bl.addFlight(fl);
                Flight_Deatails fd = new Flight_Deatails(flightNum, Convert.ToDouble(durationTextBox.Text.Trim()), Convert.ToDouble(priceTextBox.Text.Trim()), Convert.ToDouble(departTextBox.Text.Trim()), airlineDropDownList.SelectedValue, Convert.ToInt32(seatsTextBox.Text.Trim()));
                Boolean detWorked=bl.addFlightDeatails(fd);
                if (!flWorked || !detWorked)
                    Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">ERROR: Flight was not added</p>");
                else
                    Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Flight has been added</p>");
            }
            hideFields();
        }

        protected void addShow_Click(object sender, EventArgs e)
        {
            FlightsBL fb = new FlightsBL();
            LinkedList<string> airlines = fb.GetAllAirlines();
            foreach (string s in airlines)
            {
                airlineDropDownList.Items.Add(s);
            }
            showFields();
        }
        private void showFields()
        {
            addShow.Visible = false;
            numberTextBox.Visible = true;
            flightLabel.Visible = true;
            fromTextBox.Visible = true;
            fromLabel.Visible = true;
            toTextBox.Visible = true;
            toLabel.Visible = true;
            dateTextBox.Visible = true;
            dateLabel.Visible = true;
            durationTextBox.Visible = true;
            durationLabel.Visible = true;
            priceTextBox.Visible = true;
            priceLabel.Visible = true;
            departTextBox.Visible = true;
            departLabel.Visible = true;
            airlineDropDownList.Visible = true;
            airlineLabel.Visible = true;
            seatsTextBox.Visible = true;
            seatsLabel.Visible = true;
            addButton.Visible = true;
        }
        private void hideFields()
        {
            addShow.Visible = true;
            numberTextBox.Visible = false;
            flightLabel.Visible = false;
            fromTextBox.Visible = false;
            fromLabel.Visible = false;
            toTextBox.Visible = false;
            toLabel.Visible = false;
            dateTextBox.Visible = false;
            dateLabel.Visible = false;
            durationTextBox.Visible = false;
            durationLabel.Visible = false;
            priceTextBox.Visible = false;
            priceLabel.Visible = false;
            departTextBox.Visible = false;
            departLabel.Visible = false;
            airlineDropDownList.Visible = false;
            airlineLabel.Visible = false;
            seatsTextBox.Visible = false;
            seatsLabel.Visible = false;
            addButton.Visible = false;
        }

        protected void showPriceButton_Click(object sender, EventArgs e)
        {
            showPriceButton.Visible = false;
            flLabel.Visible = true;
            flTextBox.Visible = true;
            Label1.Visible = true;
            prTextBox.Visible = true;
            changeButton.Visible = true;
        }

        protected void changeButton_Click(object sender, EventArgs e)
        {
            if (flTextBox.Text.Equals("") || prTextBox.Text.Equals(""))
                Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Fill in all the fields</p>");
            else
            {
                FlightsBL fb = new FlightsBL();
                Boolean worked = fb.updatePrice(Convert.ToInt32(flTextBox.Text.Trim()),Convert.ToDouble(prTextBox.Text.Trim()));
                if (worked)
                    Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Price has been changed</p>");
                else
                    Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">ERROR: Price was not changed</p>");
            }
            showPriceButton.Visible = true;
            flLabel.Visible = false;
            flTextBox.Visible = false;
            Label1.Visible = false;
            prTextBox.Visible = false;
            changeButton.Visible = false;
        }

        protected void passeButton_Click(object sender, EventArgs e)
        {
            passeButton.Visible = false;
            infoLabel.Visible = true;
            infoTextBox.Visible = true;
            infoButton.Visible = true;
        }

        protected void infoButton_Click(object sender, EventArgs e)
        {
            if (infoTextBox.Text.Equals(""))
                Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Fill in all the fields</p>");
            else if(infoTextBox.Text.Trim().Length!=9)
                Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">passport must have 9 numbers</p>");
            else
            {
                FlightsBL fb=new FlightsBL();
                string passport = infoTextBox.Text.Trim();
                Passenger_Details pd = fb.GetPassenger_Details(passport);
                string details = "Name: "+pd.getFirstName()+" "+pd.getLastName()+"<br />"
                    + "Age: " + pd.getAge() + "<br />"
                    + "Birth date: " + pd.getBirthDate() + "<br />"
                    + "Passport number: " + pd.getPassport() + "<br />"
                    + "E-mail: " + pd.getEmail() + "<br />"
                    + "Card type: " + pd.getCardType() + "<br />"
                    + "Card number: " + pd.getCardNumber() + ",   Security code: " + pd.getSecurityCode() + "<br />"
                    + "Expiration date: " + pd.getExpireDate() + "<br />"
                    + "Name on card: " + pd.getNameOnCard() + "<br />";
                allInfoLabel.Text = details;
                allInfoLabel.Visible = true;
                infoButton.Visible = false;
                retButton.Visible = true;
            }
        }

        protected void retButton_Click(object sender, EventArgs e)
        {
            retButton.Visible = false;
            allInfoLabel.Visible = false;
            passeButton.Visible = true;
            infoLabel.Visible = false;
            infoTextBox.Visible = false;
            infoButton.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            listLabel.Visible = false;
            Button1.Visible = false;
            flNuLabel.Visible = true;
            flNuTextBox.Visible = true;
            getListButton.Visible = true;
        }

        protected void getListButton_Click(object sender, EventArgs e)
        {
            string allPersons = "";
            if (flNuTextBox.Text.Equals(""))
                Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Fill in the flight number fields</p>");
            else
            {
                FlightsBL fb=new FlightsBL();
                string resultString = Regex.Match(flNuTextBox.Text.Trim(), @"\d+").Value;
                if (resultString.Equals(""))
                {
                    Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">Not a number</p>");
                    return;
                }
                int flNu = Int32.Parse(resultString);
                
                    LinkedList<people> temp = fb.GetPassengersOnFlight(flNu);
                    foreach (people p in temp)
                    {
                        allPersons += "<div id=pers>Name: " + p.getFirstName() + " " + p.getLastName() + "<br/>"
                            + "Passport: " + p.getPassport() + ",  E-Mail: " + p.getEmail() + "</div>";
                    }
                    passengersList.Text = allPersons;
                    passengersList.Visible = true;
                    listLabel.Visible = false;
                    Button1.Visible = false;
                    flNuLabel.Visible = false;
                    flNuTextBox.Visible = false;
                    getListButton.Visible = false;
                    
                
            }
        }
        
    }
}