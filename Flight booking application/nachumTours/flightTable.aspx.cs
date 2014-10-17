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
    public partial class flightTable : System.Web.UI.Page
    {
        //string strValue = string.Empty;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string dCountry = (string)(Session["dCountry"]);
            
            string dMonth = (string)(Session["dMonth"]);
            int dDay = (int)Convert.ToInt32(Session["dDay"]);
            int dYear = (int)Convert.ToInt32(Session["dYear"]);

            Boolean isRound = (Boolean)(Session["isRound"]);
            
            string departDate = Convert.ToString(dDay) + "/" + Convert.ToString(getNumOfMonth(dMonth)) + "/" + Convert.ToString(dYear);
            increaseDate(departDate);
            string aCountry = (string)(Session["aCountry"]);
            LinkedList<string> back = null;
            LinkedList<string> along = calculateOneWayFlights(dCountry, aCountry, departDate);
            if (along != null)
            {
                if (isRound)
                {
                    string aMonth = (string)(Session["aMonth"]);
                    int aDay = (int)Convert.ToInt32(Session["aDay"]);
                    int aYear = (int)Convert.ToInt32(Session["aYear"]);
                    string arriveDate = Convert.ToString(aDay) + "/" + Convert.ToString(getNumOfMonth(aMonth)) + "/" + Convert.ToString(aYear);
                    back = calculateOneWayFlights(aCountry, dCountry, arriveDate);
                }
               // int adultsNum = (int)Convert.ToInt32(Session["adultsNum"]);
                //int childNum = (int)Convert.ToInt32(Session["childNum"]);
               // string tickClass = (string)(Session["tickClass"]);
                if (!Page.IsPostBack)
                {
                    FirstListViewRow();
                    foreach (string al in along)
                    {
                        if (back != null)
                        {
                            foreach (string ba in back)
                            {
                                AddNewRow(dCountry, al, aCountry, ba);
                            }
                        }
                        else
                            AddNewRow(dCountry, al, aCountry, null);
                    }
                }
                if (!IsPostBack)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                    dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1].Delete();
                    ViewState["CurrentTable"] = dtCurrentTable;
                    listview1.DataSource = dtCurrentTable;
                    listview1.DataBind();
                }
            }
            else
                Response.Write("<p style=\"color:#FF0000; font-weight:bold;\">No flights available</p>");
        }

        
        
        private void FirstListViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Flight Along", typeof(string)));
            dt.Columns.Add(new DataColumn("Flight Back", typeof(string)));
            dt.Columns.Add(new DataColumn("Stops", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));
            dt.Columns.Add(new DataColumn("Select", typeof(Button)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            listview1.DataSource = dt;
            listview1.DataBind();
        }

        private void AddNewRow(string from, string fromNums,string to,string toNums)
        {
            FlightsBL temp=new FlightsBL();
            Flight_Deatails fd;
            string fromStops = "";
            string fromFlightNum = "";
            double fromPrice = 0;
            string toStops = "";
            string toFlightNum = "";
            double toPrice = 0;
            string a = "";
            string[] fn = fromNums.Split('/');
           
            if (fn.Length == 1)
            {
                fromStops = "direct";
                fd = temp.GetFlightDeatails(Convert.ToInt32(fn[0]));
                fromFlightNum = "" + fd.getFlightNumber();
                fromPrice = fd.getPrice();
            }
            else
            {
                int counter = 1;
                fromStops = "" + (fn.Length-1);
                foreach (string num in fn)
                {
                    fd = temp.GetFlightDeatails(Convert.ToInt32(num));
                    fromFlightNum += num;
                    if (counter < fn.Length)
                        fromFlightNum += ", ";
                    fromPrice += fd.getPrice();
                    counter++;
                }
            }
            if (toNums != null)
            {
                string[] tn = toNums.Split('/');
                if (tn.Length == 1)
                {
                    toStops = "direct";
                    fd = temp.GetFlightDeatails(Convert.ToInt32(tn[0]));
                    toFlightNum = "" + fd.getFlightNumber();
                    toPrice = fd.getPrice();
                }
                else
                {
                    int counter = 1;
                    toStops = "" + (tn.Length - 1);
                    foreach (string num in tn)
                    {
                        fd = temp.GetFlightDeatails(Convert.ToInt32(num));
                        toFlightNum += num;
                        if (counter < tn.Length)
                            toFlightNum += ", ";
                        toPrice += fd.getPrice();
                        counter++;
                    }
                }
               // a = "<div id=ma> From: " + to + " To: " + from + "<br />" + "Flight Number(s): " + toFlightNum+"</div>";
                a = "<div id=all><div id=top><div id=le>From: " + to + "</div><div id=ri> To: " + from + "</div></div><div id=bo>" + "Flight Number(s): " + toFlightNum + "</div></div>";
            }
            else
            {
                a = "No flights";
                toPrice = 0;
                toStops = "Not relevant";
            }
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    string d = "<div id=all><div id=top><div id=le>From: " + from + "</div><div id=ri> To: " + to + "</div></div><div id=bo>" + "Flight Number(s): " + fromFlightNum + "</div></div>";
                    string priceStr = "One Passenger: " + calculateClass(fromPrice + toPrice )+ "$." + "<br />" + " All Passengers: " + calculatePrice(fromPrice + toPrice) + "$.";
                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1]["Flight Along"] = d;
                    dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1]["Flight Back"] = a;
                    dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1]["Stops"] = "Along Stops: " + fromStops+"." + "<br />" + " Back Stops: " + toStops+".";
                    dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1]["Price"] = priceStr;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                       
                    ViewState["CurrentTable"] = dtCurrentTable;
                    listview1.DataSource = dtCurrentTable;
                    listview1.DataBind();
                 }
            }
            else
                 Response.Write("ViewState is null");
        } 
        private double calculatePrice(double pri)
        {
            double adultsNum = (int)Convert.ToInt32(Session["adultsNum"]);
            double childNum = (int)Convert.ToInt32(Session["childNum"]);
            string tickClass = (string)(Session["tickClass"]);
            if (tickClass.Equals("Business Class"))
                pri += 500;
            else if (tickClass.Equals("First Class"))
                pri += 800;
            return (pri*adultsNum+(pri-100)*childNum);
        }
        private double calculateClass(double pri)
        {
            string tickClass = (string)(Session["tickClass"]);
            if (tickClass.Equals("Business Class"))
                pri += 500;
            else if (tickClass.Equals("First Class"))
                pri += 800;
            return pri;
        }
   
        private int getNumOfMonth(string month)
        {
            switch (month)
            {
                case "January":
                    return 1;
                case "February":
                    return 2;
                case "March":
                    return 3;
                case "April":
                    return 4;
                case "May":
                    return 5;
                case "June":
                    return 6;
                case "July":
                    return 7;
                case "August":
                    return 8;
                case "September":
                    return 9;
                case "October":
                    return 10;
                case "November":
                    return 11;
                case "December":
                    return 12;
             }
            return -1;
        }

        
        private LinkedList<string> calculateOneWayFlights(string from, string to, string departDate)
        {
            FlightsBL fb = new FlightsBL();
            Boolean isDirect = (Boolean)(Session["isDirect"]);
            //direct
            LinkedList<Flights> directFl = fb.GetDirectFlights(from, to, departDate);
                if (directFl != null)
                {
                    foreach (Flights i in directFl)
                    {
                        {
                            Flight_Deatails fd = fb.GetFlightDeatails(i.getFlightNumber());
                            Boolean added = fb.addChosenFlight(Convert.ToString(fd.getFlightNumber()), fd.getPrice());
                        }
                    }
                    
                }
            //one stop
                if (!isDirect)
                {
                    LinkedList<Flights> first = fb.GetFirstStop(from, departDate);
                    if (first != null)
                    {
                       
                        foreach (Flights f1 in first)
                        {
                             Flight_Deatails firstDet = fb.GetFlightDeatails(f1.getFlightNumber());
                            string datePlusOne = increaseDate(departDate);
                            string datePlusTwo = increaseDate(datePlusOne);
                            //same day
                            LinkedList<Flights> second = fb.GetDirectFlights(f1.getTo(), to, departDate);
                            if (second != null)
                            {
                                foreach (Flights f2 in second)
                                {
                                    Flight_Deatails secondDet = fb.GetFlightDeatails(f2.getFlightNumber());
                                    //checking if he will make it
                                    if ((firstDet.getDeapartTime() + firstDet.getDuration()) < secondDet.getDeapartTime())
                                      {
                                         Boolean added = fb.addChosenFlight(Convert.ToString(f1.getFlightNumber()) + "/" + Convert.ToString(f2.getFlightNumber()),firstDet.getPrice()+ secondDet.getPrice());
                                      }
                                }
                            }
                            //day after
                            second = fb.GetDirectFlights(f1.getTo(), to, datePlusOne);
                            if (second != null)
                            {
                                foreach (Flights f2 in second)
                                {
                                  Flight_Deatails secondDet = fb.GetFlightDeatails(f2.getFlightNumber());
                                  Boolean added = fb.addChosenFlight(Convert.ToString(f1.getFlightNumber()) + "/" + Convert.ToString(f2.getFlightNumber()), firstDet.getPrice() + secondDet.getPrice());
                                }
                            }
                            //two days after
                            second = fb.GetDirectFlights(f1.getTo(), to, datePlusTwo);
                            if (second != null)
                            {
                                foreach (Flights f2 in second)
                                {
                                    Flight_Deatails secondDet = fb.GetFlightDeatails(f2.getFlightNumber());
                                    Boolean added = fb.addChosenFlight(Convert.ToString(f1.getFlightNumber()) + "/" + Convert.ToString(f2.getFlightNumber()), firstDet.getPrice() + secondDet.getPrice());
                                }
                            }
                        }
                    }

                }
                LinkedList<string> tes = fb.GetFlightsByPrice();
                fb.deleteTable();
                         return tes;
        }

        private string increaseDate(string date)
        {
            string[] words = date.Split('/');
            int d =Convert.ToInt32( words[0]);
            int m = Convert.ToInt32(words[1]);
            int y = Convert.ToInt32(words[2]);
            if ((d == 31) && (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10))
            {
                d = 1;
                m++;
            }
            else if (d == 31 && m == 12)
            {
                d = 1;
                m = 1;
                y++;
            }
            else if ((d == 30) && (m == 4 || m == 6 || m == 9 || m == 11))
            {
                d = 1;
                m++;
            }
            else if (d == 28 && m == 2)
            {
                d = 1;
                m++;
            }
            else
                d++;
         
            string nDate = Convert.ToString(d) + "/" + Convert.ToString(m) + "/" + Convert.ToString(y);
            return nDate;
        }

        protected void details_Command(object sender, CommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Label lb = ((Label)listview1.Items[index].FindControl("txtFName"));

            string alongF = lb.Text;
            alongF = alongF.Substring(alongF.IndexOf("(s): ")+4);
            Session["alongF"] = alongF;
            Boolean isRound = (Boolean)(Session["isRound"]);
            if (isRound)
            {
                Label lb1 = ((Label)listview1.Items[index].FindControl("txtLName"));
                string backF = lb1.Text;
                string resultString = Regex.Match(backF, @"\d+").Value;
                if (resultString.Equals(""))
                {
                   
                    Session["isRound"] = false;
                }
                else
                {
                    backF = backF.Substring(backF.IndexOf("(s): ") + 4);
                    Session["backF"] = backF;

                }
            }
            
             Response.Redirect("flightSummary.aspx");
        }

        

        
        
    }
}