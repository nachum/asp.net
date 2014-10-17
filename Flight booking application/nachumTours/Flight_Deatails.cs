using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nachumTours
{
    public class Flight_Deatails
    {
        private int flightNumber;
        private double duration;
        private double price;
        private double deapartTime;
        private string airline;
        private int seatsLeft;

        public Flight_Deatails(int flightNumber, double duration, double price, double deapartTime, string airline, int seatsLeft)
        {
            this.flightNumber = flightNumber;
            this.duration = duration;
            this.price = price;
            this.deapartTime = deapartTime;
            this.airline = airline;
            this.seatsLeft = seatsLeft;
        }

        public int getFlightNumber() { return this.flightNumber; }
        public double getDuration() { return this.duration; }
        public double getPrice() { return this.price; }
        public double getDeapartTime() { return this.deapartTime; }
        public string getAirline() { return this.airline; }
        public int getSeatsLeft() { return this.seatsLeft; }

        public void setFlightNumber(int flightNumber) { this.flightNumber = flightNumber; }
        public void setDuration(double duration) { this.duration = duration; }
        public void setPrice(double price) { this.price = price; }
        public void setDeapartTime(double deapartTime) { this.deapartTime = deapartTime; }
        public void setAirline(string airline) { this.airline = airline; }
        public void setSeatsLeft(int seatsLeft) { this.seatsLeft = seatsLeft; }
    }
}