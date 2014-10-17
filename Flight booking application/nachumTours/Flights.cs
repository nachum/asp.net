using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nachumTours
{
    public class Flights
    {
        private int flightNumber;
        private string from;
        private string to;
        private string date;
       
        public Flights(int flightNumber, string from, string to,string date)
        {
            this.flightNumber = flightNumber;
            this.from = from;
            this.to = to;
            this.date = date;
        }

        public int getFlightNumber() { return this.flightNumber; }
        public string getFrom() { return this.from; }
        public string getTo() { return this.to; }
        public string getDate() { return this.date; }
       
        public void setFlightNumber(int flightNumber) { this.flightNumber = flightNumber; }
        public void setFrom(string from) { this.from = from; }
        public void setTo(string to) { this.to = to; }
        public void setDate(string date) { this.date = date; }
        
    }
}