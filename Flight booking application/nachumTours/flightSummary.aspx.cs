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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string ro = (string)Session["backF"];
                createAlong();
                Boolean isRound = (Boolean)(Session["isRound"]);
                if (isRound )
                    createBack();
                createPrices();
                getData();
    
                DataTable dtCurrentTable = (DataTable)ViewState["alongTable"];
                dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1].Delete();
                ViewState["alongTable"] = dtCurrentTable;
                listAlong.DataSource = dtCurrentTable;
                listAlong.DataBind();
                
                if (isRound )
                {
                    dtCurrentTable = (DataTable)ViewState["backTable"];
                    dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1].Delete();
                    ViewState["backTable"] = dtCurrentTable;
                    ListBack.DataSource = dtCurrentTable;
                    ListBack.DataBind();
                }
                dtCurrentTable = (DataTable)ViewState["pricesTable"];
                dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1].Delete();
                ViewState["pricesTable"] = dtCurrentTable;
                priceBuy.DataSource = dtCurrentTable;
                priceBuy.DataBind();
               
                
            }
        }

        private void getData()
        {
            string alNums=(string)Session["alongF"];
            string[] alFliNums = alNums.Split(',');
            foreach (string num in alFliNums)
            {
                AddAlongNewRow(num);
            }
            string baNums = "";
            Boolean isRound = (Boolean)(Session["isRound"]);
            
            if (isRound )
            {
                baNums = (string)Session["backF"];
                string[] baFliNums = baNums.Split(',');
                foreach (string num in baFliNums)
                {
                    AddBackNewRow(num);
                }
            }
            else
                baNums = null;
            addPricesRow((string)Session["alongF"],baNums);

        }

        private void createAlong()
        {
            DataTable Adt = new DataTable();
            DataRow Adr = null;
            Adt.Columns.Add(new DataColumn("Along", typeof(string)));
           
            Adr = Adt.NewRow();
            Adt.Rows.Add(Adr);
            ViewState["alongTable"] = Adt;
            listAlong.DataSource = Adt;
            listAlong.DataBind();
            
        }

        private void createBack()
        {
            DataTable Bdt = new DataTable();
            DataRow Bdr = null;
            Bdt.Columns.Add(new DataColumn("Back", typeof(string)));

            Bdr = Bdt.NewRow();
            Bdt.Rows.Add(Bdr);
            ViewState["backTable"] = Bdt;
            ListBack.DataSource = Bdt;
            ListBack.DataBind();
        }
        private void createPrices()
        {
            DataTable Pdt = new DataTable();
            DataRow Pdr = null;
            Pdt.Columns.Add(new DataColumn("prices", typeof(string)));

            Pdr = Pdt.NewRow();
            Pdt.Rows.Add(Pdr);
            ViewState["pricesTable"] = Pdt;
            priceBuy.DataSource = Pdt;
            priceBuy.DataBind();

        }
        private void AddAlongNewRow(string flightNum)
        {
            flightNum = flightNum.Trim();
            string resultString = Regex.Match(flightNum, @"\d+").Value;
            int flNu = Int32.Parse(resultString);
            FlightsBL bl = new FlightsBL();
            Flights mainDet = bl.GetFlight(flNu);
            Flight_Deatails allDet = bl.GetFlightDeatails(flNu);
             string a = "<div id=all>"+
                            "<div id=leave>Leave:" + mainDet.getDate() + "<br/><br/>" + "Depart: " + calculateTime((double)allDet.getDeapartTime(), 0) + "<br/><br/>" + "Arrive: " + calculateTime((double)allDet.getDeapartTime(), allDet.getDuration()) + "</div>" +
                            "<div id=loc><br/><br/>" + mainDet.getFrom() + "<br/><br/>" + mainDet.getTo() + "</div>" +
                            "<div id=air><div id=airName>"+allDet.getAirline()+"</div><br/><div id=airPic>"+"<img src=\"Images\\"+bl.GetAirlinePic(allDet.getAirline())+"\" alt=\"\" align=\"middle\" width=\"100\" height=\"50\">"+"</div></div>"+
                        "</div>";
            
            if (ViewState["alongTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["alongTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1]["Along"] = a;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["alongTable"] = dtCurrentTable;
                    listAlong.DataSource = dtCurrentTable;
                    listAlong.DataBind();
                }
            }
            else
                Response.Write("ViewState is null");
        }
        private void AddBackNewRow(string flightNum)
        {
            flightNum = flightNum.Trim();
            string resultString = Regex.Match(flightNum, @"\d+").Value;
            int flNu = Int32.Parse(resultString);
            FlightsBL bl = new FlightsBL();
            Flights mainDet = bl.GetFlight(flNu);
            Flight_Deatails allDet = bl.GetFlightDeatails(flNu);
            string a = "<div id=all>" +
                           "<div id=leave>Leave:" + mainDet.getDate() + "<br/><br/>" + "Depart: " + calculateTime((double)allDet.getDeapartTime(),0) + "<br/><br/>" + "Arrive: " +calculateTime((double) allDet.getDeapartTime() , allDet.getDuration()) + "</div>" +
                           "<div id=loc><br/><br/>" + mainDet.getFrom() + "<br/><br/>" + mainDet.getTo() + "</div>" +
                           "<div id=air><div id=airName>" + allDet.getAirline() + "</div><br/><div id=airPic>" + "<img src=\"Images\\" + bl.GetAirlinePic(allDet.getAirline()) + "\" alt=\"\" align=\"middle\" width=\"100\" height=\"50\">" + "</div></div>" +
                       "</div>";

           

            if (ViewState["backTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["backTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1]["Back"] = a;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["backTable"] = dtCurrentTable;
                    ListBack.DataSource = dtCurrentTable;
                    ListBack.DataBind();
                }
            }
            else
                Response.Write("ViewState is null");
        }
        private void addPricesRow(string alNum,string baNum)
        {
            double price = 0;
            FlightsBL temp = new FlightsBL();
            Flight_Deatails fd;
            string[] allFliNums = alNum.Split(',');
            foreach (string num in allFliNums)
            {
                string resultString = Regex.Match(num, @"\d+").Value;
                int flNu = Int32.Parse(resultString);
                fd = temp.GetFlightDeatails(flNu);
                price += (double)fd.getPrice();
            }
            if (baNum != null)
            {
                allFliNums = baNum.Split(',');
                foreach (string num in allFliNums)
                {
                    string resultString = Regex.Match(num, @"\d+").Value;
                    int flNu = Int32.Parse(resultString);
                    fd = temp.GetFlightDeatails(flNu);
                    price += (double)fd.getPrice();
                }
            }
            string tickClass = (string)(Session["tickClass"]);
            if (tickClass.Equals("Business Class"))
                price += 500;
            else if (tickClass.Equals("First Class"))
                price += 800;
            string a="<div id=prices>" +
                           "<div id=person>" + " <div id=perPic>" + "<img src=\"Images\\person.png" + "\" alt=\"\" align=\"middle\" width=\"50\" height=\"70\">" + "</div>" +
                           "<div id=perDet><p>Adult</p>" + price + "$ X " + Session["adultsNum"] + "<br/><div id=prColor>" + (price * ((int)Convert.ToInt32(Session["adultsNum"]))) + "$</div></div></div>" +
                           "<div id=child>" + " <div id=chilPic>" + "<img src=\"Images\\person.png" + "\" alt=\"\" align=\"middle\" width=\"30\" height=\"40\">" + "</div>" +
                           "<div id=perDet><p>Child</p>" + (price - 100) + "$X" + Session["childNum"] + "<br/><div id=prColor>" + ((price - 100) * ((int)Convert.ToInt32(Session["childNum"]))) + "$</div></div></div>" +
                           "<div id=total><p>Total Price</p>" + ((int)Convert.ToInt32(Session["adultsNum"]) + (int)Convert.ToInt32(Session["childNum"])) + " Passengers<br/>"+
                           ((int)Convert.ToInt32(Session["childNum"]) * (price - 100) + (int)Convert.ToInt32(Session["adultsNum"])*price) +"$"+
                           "</div>" +
                           "</div>";
            if (ViewState["pricesTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["pricesTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1]["prices"] = a;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["pricesTable"] = dtCurrentTable;
                    priceBuy.DataSource = dtCurrentTable;
                    priceBuy.DataBind();
                }
            }
        }
        private string calculateTime(double accualTime, double addTime)
        {
            TimeSpan interval = TimeSpan.FromHours(accualTime);
            TimeSpan addInterval = TimeSpan.FromHours(addTime);
            interval=interval.Add(addInterval);
            
            return interval.ToString();
        }

        protected void Buy_Click(object sender, EventArgs e)
        {
            Boolean seatsLeft = true;
            int passengers = (int)Convert.ToInt32(Session["adultsNum"]) + (int)Convert.ToInt32(Session["childNum"]);
            FlightsBL temp = new FlightsBL();
            Flight_Deatails fd;
            string alNums = (string)Session["alongF"];
            string[] alFliNums = alNums.Split(',');
            foreach (string num in alFliNums)
            {
                string resultString = Regex.Match(num, @"\d+").Value;
                int number = (int)Convert.ToInt32(resultString);
                fd = temp.GetFlightDeatails(number);
                int seats = fd.getSeatsLeft();
                if (seats - passengers < 0)
                {
                    seatsLeft = false;
                    break;
                }
            }
             Boolean isRound = (Boolean)(Session["isRound"]);
             if (isRound)
             {
                string baNums = (string)Session["backF"];
                 string[] baFliNums = baNums.Split(',');
                 foreach (string num in baFliNums)
                 {
                     string resultString = Regex.Match(num, @"\d+").Value;
                     int number = (int)Convert.ToInt32(resultString);
                     fd = temp.GetFlightDeatails(number);
                     int seats = fd.getSeatsLeft();
                     if (seats - passengers < 0)
                     {
                         seatsLeft = false;
                         break;
                     }
                 }
             }
             if (!seatsLeft)
             {
                 Response.Write("flight is full, pick differnt flight");
             }
             else
                Response.Redirect("payment.aspx");
        }
    }
}