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
    public partial class payment : System.Web.UI.Page
    {
        private Table table = new Table();
        protected void Page_Load(object sender, EventArgs e)
        {
            ////
            if (!visaCheckBox.AutoPostBack)
            {
                visaCheckBox.AutoPostBack = true;
                loadMonth();
                loadYear();
                 Session["exist"]="false";
            }
            /////
            int AdultRows = (int)Convert.ToInt32(Session["adultsNum"]);
            int childRows = (int)Convert.ToInt32(Session["childNum"]);
            
            
            table.ID = "Table1";
            PlaceHolder1.Controls.Add(table);
            GenerateTable(0,AdultRows,"Adult");
            if (childRows > 0)
                GenerateTable(AdultRows, AdultRows + childRows, "Child");
             
          
        }

        private void GenerateTable(int start,int rows,string type)
        {
            for (int i = start; i < rows; i++)
            {
                TableRow row = new TableRow();
                {
                    TableCell cell = new TableCell();
                    Label passNum = new Label();
                    passNum.ID = "title" + i;
                    if (i == 0)
                    {
                        passNum.Text = "Traveler 1 - Adult (you)" + "<br/>";
                    }
                    else
                        passNum.Text = "Traveler " + (i + 1) + " - "+type + "<br/>";
                    passNum.Width=150;
                    passNum.Font.Size = 10;
                    passNum.ForeColor = System.Drawing.ColorTranslator.FromHtml("#b21261");
                    passNum.Style["font-weight"] = "bold";
                    TextBox tb = new TextBox();
                    tb.Width=100;
                    Label lb = new Label();
                    tb.Font.Size = 8;
                    lb.Font.Size = 9;
                    tb.ID = "TextBoxRow_first" + i ;
                    lb.ID = "LableRow_first" + i;
                    lb.Text = "First name:<br/>";
                    cell.Controls.Add(passNum);
                    cell.Controls.Add(lb);
                    cell.Controls.Add(tb);
                    row.Cells.Add(cell);
                    //
                    cell = new TableCell();
                    tb = new TextBox();
                    tb.Width = 100;
                    lb = new Label();
                    tb.Font.Size = 8;
                    lb.Font.Size = 9;
                    tb.ID = "TextBoxRow_last" + i;
                    lb.ID = "LableRow_last" + i;
                    lb.Text = "<br/>Last name:<br/>";
                    cell.Controls.Add(lb);
                    cell.Controls.Add(tb);
                    row.Cells.Add(cell);
                    //
                    cell = new TableCell();
                    tb = new TextBox();
                    tb.Width = 100;
                    tb.Font.Size = 8; 
                    lb = new Label();
                    tb.ID = "TextBoxRow_age" + i ;
                    lb.ID = "LableRow_age" + i;
                    lb.Text = "<br/>Age:<br/>";
                    lb.Font.Size = 9;
                    cell.Controls.Add(lb);
                    cell.Controls.Add(tb);
                    row.Cells.Add(cell);
                    //
                    cell = new TableCell();
                    tb = new TextBox();
                    tb.Width = 100;
                    tb.ToolTip = "dd/mm/yyyy";
                    lb = new Label();
                    tb.Font.Size = 8;
                    lb.Font.Size = 9;
                    tb.ID = "TextBoxRow_date" + i ;
                    lb.ID = "LableRow_date" + i;
                    lb.Text = "<br/><br/>Date of birth:<br/>";
                    RegularExpressionValidator rv = new RegularExpressionValidator();
                    rv.ID = "RegularExpressionValidator" + i;
                    rv.ControlToValidate = "TextBoxRow_date" + i;
                    rv.ValidationExpression = "^[0-9m]{1,2}/[0-9d]{1,2}/[0-9y]{4}$";
                    rv.ErrorMessage = "Input valid date!";
                    cell.Controls.Add(lb);
                    cell.Controls.Add(tb);
                    cell.Controls.Add(rv);
                    row.Cells.Add(cell);
                    //
                    cell = new TableCell();
                    tb = new TextBox();
                    tb.Width = 100;
                    lb = new Label();
                    tb.Font.Size = 8;
                    lb.Font.Size = 9;
                    tb.ID = "TextBoxRow_pass" + i;
                    lb.ID = "LableRow_pass" + i;
                    lb.Text = "<br/>Passport number: <br/>";
                    cell.Controls.Add(lb);
                    cell.Controls.Add(tb);
                    row.Cells.Add(cell);
                    //
                    cell = new TableCell();
                    tb = new TextBox();
                    tb.Width = 100;
                    lb = new Label();
                    tb.Font.Size = 8;
                    lb.Font.Size = 9;
                    tb.ID = "TextBoxRow_email" + i;
                    lb.ID = "LableRow_email" + i;
                    lb.Text = "<br/><br/>E-mail: <br/>";
                    rv = new RegularExpressionValidator();
                    rv.ID="RegularExpressionValidator1"+i;
                    rv.ControlToValidate = "TextBoxRow_email" + i;
                    rv.ValidationExpression="\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                    rv.ErrorMessage="Input valid email address!";
                   cell.Controls.Add(lb);
                    cell.Controls.Add(tb);
                    cell.Controls.Add(rv);
                    row.Cells.Add(cell);
                }

                // Add the TableRow to the Table
                table.Rows.Add(row);
            }
        }

        protected void done_Click(object sender, EventArgs e)
        {
            if (perExist())
                Session["exist"] = true;
            TextBox t1;
            TextBox t2;
            TextBox t3;
            TextBox t4;
            TextBox t5;
            TextBox t6;
            string userFirst = "";
            string userLast = "";
            string userAge = "";
            string userDate = "";
            string userPass = "";
            string userEmail = "";
            string cardType = "";
            string cardNumber = "";
            string secCode = "";
            string expDate = "";
            string nameOn = "";

            string passengerDet = "";
           
            int numPass=(int)Convert.ToInt32(Session["adultsNum"])+ (int)Convert.ToInt32(Session["childNum"]);
            for (int i = 0; i < numPass; i++)
            {
                t1 = (TextBox)PlaceHolder1.FindControl("TextBoxRow_first" + i.ToString());
                t2 = (TextBox)PlaceHolder1.FindControl("TextBoxRow_last" + i.ToString());
                t3 = (TextBox)PlaceHolder1.FindControl("TextBoxRow_age" + i.ToString());
                t4 = (TextBox)PlaceHolder1.FindControl("TextBoxRow_date" + i.ToString());
                t5 = (TextBox)PlaceHolder1.FindControl("TextBoxRow_pass" + i.ToString());
                t6 = (TextBox)PlaceHolder1.FindControl("TextBoxRow_email" + i.ToString());
                if((t1.Text.Equals("")) || (t2.Text.Equals("")) || (t3.Text.Equals("")) || (t4.Text.Equals("")) || (t5.Text.Equals("")) || (t6.Text.Equals("")))
                {
                    Response.Write("Fill in all empty fields");
                    break;
                }
                string Str = t3.Text.Trim();
                double Num;
                bool isNum = double.TryParse(Str, out Num);
                if (isNum)
                {
                    if (Num < 0 || Num > 120)
                    {
                        Response.Write("Illegal age");
                        return;
                    }
                }
                else
                {
                    Response.Write("Illegal age");
                    return;
                }
                if (t5.Text.Trim().Length != 9)
                {
                    Response.Write("Illegal passport number");
                    return;
                }
                if (i == 0)
                {
                    userFirst = t1.Text.Trim();
                    userLast = t2.Text.Trim();
                    userAge = t3.Text.Trim();
                    userDate = t4.Text.Trim();
                    userPass = t5.Text.Trim();
                    userEmail = t6.Text.Trim();
                }
                ////
                FlightsBL bl = new FlightsBL();
                string alNums = (string)Session["alongF"];
                string[] alFliNums = alNums.Split(',');
                foreach (string num in alFliNums)
                {
                    string fNum = num.Trim();
                    string resultString = Regex.Match(fNum, @"\d+").Value;
                    int flNu = Int32.Parse(resultString);
                    people temp = new people(t5.Text.Trim(), t1.Text.Trim(), t2.Text.Trim(),t6.Text.Trim(), flNu);
                    bl.addPerson(temp); 
                }
                Boolean isRound = (Boolean)(Session["isRound"]);
                if (isRound)
                {
                    string baNums = (string)Session["backF"];
                    string[] baFliNums = baNums.Split(',');
                    foreach (string num in baFliNums)
                    {
                        string fNum = num.Trim();
                        string resultString = Regex.Match(fNum, @"\d+").Value;
                        int flNu = Int32.Parse(resultString);
                        people temp = new people(t5.Text.Trim(), t1.Text.Trim(), t2.Text.Trim(), t6.Text.Trim(), flNu);
                        bl.addPerson(temp); 
                    }
                }
                /////
                
                passengerDet += "<div id=det> Traveler "+(i+1)+":<br /> Name - "+t1.Text+" "+t2.Text+"<br />"
                                +"Passport Number : "+t5.Text+"<br/>"
                                +"E-mail: "+t6.Text.Trim()+"</div>";
            }

            if (Session["exist"].Equals("false") )
            {
                if (visaCheckBox.Checked)
                    cardType = "visa";
                else if (masterCheckBox.Checked)
                    cardType = "MasterCard";
                else
                {
                    Response.Write("Choose card type!");
                    return;
                }
                if (cardTextBox.Text.Trim().Length != 16)
                {
                    Response.Write("Card number not valid!");
                    return;
                }
                else
                    cardNumber = cardTextBox.Text.Trim();
                if (secTextBox.Text.Trim().Length != 3)
                {
                    Response.Write("Security number not valid! <br/> enter 3 numbers from back of card");
                    return;
                }
                else
                    secCode = secTextBox.Text.Trim();
                if (!monthDropDownList.SelectedValue.Equals("") && !yearDropDownList.SelectedValue.Equals(""))
                {
                    expDate = monthDropDownList.SelectedValue + "/" + yearDropDownList.SelectedValue;
                }
                else
                {
                    Response.Write("Fill in expiration date!");
                    return;
                }
                if (!nameTextBox.Equals(""))
                    nameOn = nameTextBox.Text.Trim();
                else
                {
                    Response.Write("Fill in name as it appears on the card!");
                    return;
                }
            }
            Passenger_Details pd = new Passenger_Details(userFirst, userLast, Convert.ToInt32(userAge), userDate, userPass, userEmail, cardType, cardNumber, secCode ,expDate ,nameOn);
            if (rememberCheckBox.Checked)
            {
                FlightsBL b = new FlightsBL();
                Boolean did = b.addPassenger(pd);
                if (!did)
                    Response.Write("Passenger was not added");
            }
            updateSeats();
            Session["passengers"] = passengerDet;
            Response.Redirect("finish.aspx");
        }

        private void updateSeats()
        {
            FlightsBL bl = new FlightsBL();
            int numPass = (int)Convert.ToInt32(Session["adultsNum"]) + (int)Convert.ToInt32(Session["childNum"]);
            string alNums = (string)Session["alongF"];
            string[] alFliNums = alNums.Split(',');
            foreach (string num in alFliNums)
            {
                string fNum = num.Trim();
                string resultString = Regex.Match(fNum, @"\d+").Value;
                int flNu = Int32.Parse(resultString);
                bl.updateSeats(flNu, numPass);
            }
            Boolean isRound = (Boolean)(Session["isRound"]);
            if (isRound)
            {
                string baNums = (string)Session["backF"];
                string[] baFliNums = baNums.Split(',');
                foreach (string num in baFliNums)
                {
                    string fNum = num.Trim();
                    string resultString = Regex.Match(fNum, @"\d+").Value;
                    int flNu = Int32.Parse(resultString);
                    bl.updateSeats(flNu, numPass);
                }
            }
        }

        private void loadMonth()
        {
            //Dmonth.Items.Clear();
            LinkedList<string> months = new LinkedList<string>();
           // months.AddLast("");
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
                monthDropDownList.Items.Add(s);
            }

        }

        private void loadYear()
        {
            yearDropDownList.Items.Add("2013");
            yearDropDownList.Items.Add("2014");
            yearDropDownList.Items.Add("2015");
            yearDropDownList.Items.Add("2016");
            yearDropDownList.Items.Add("2017");
            yearDropDownList.Items.Add("2018");
            yearDropDownList.Items.Add("2019");
           
        }

        protected void visaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (visaCheckBox.Checked)
                masterCheckBox.Checked = false;
        }

        protected void masterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (masterCheckBox.Checked)
                visaCheckBox.Checked = false;
        }

        protected void checkButton_Click(object sender, EventArgs e)
        {
            TextBox tPass = (TextBox)PlaceHolder1.FindControl("TextBoxRow_pass0");
            string passport=tPass.Text;
            if (!passport.Equals(""))
            {
                FlightsBL bl = new FlightsBL();
                if (bl.PassengerExist(passport))
                {
                    validLabel.Text = "You exist in the system continue to \"submit order\"";
                    validLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0800ff");
                    Session["exist"]="true";
                }
                else
                {
                    validLabel.Text = "You do not exist in the system fill in the \"Billing information\" to continue";
                    validLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                }
            }
            else
                validLabel.Text = "fill in Passport number";
            validLabel.Visible = true;
             
            
        }
        public Boolean perExist()
        {
            TextBox tPass = (TextBox)PlaceHolder1.FindControl("TextBoxRow_pass0");
            string passport = tPass.Text;
            if (!passport.Equals(""))
            {
                FlightsBL bl = new FlightsBL();
                if (bl.PassengerExist(passport))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                validLabel.Text = "fill in Passport number";
            
            return false;
        }
        
        
    }
}