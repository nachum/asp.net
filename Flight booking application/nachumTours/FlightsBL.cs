using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nachumTours
{
    public class FlightsBL
    {
        public Flights GetFlight(int flightNumber)
        {
            FlightsDal temp = new FlightsDal();
            Flights t = temp.GetFlight(flightNumber);
            if (t == null)
                return null;
            else
                return t;
        }

        public Boolean flightExist(int flightNumber)
        {
            Flights temp = GetFlight(flightNumber);
            if (temp == null)
                return false;
            else
                return true;
        }

        public Boolean addFlight(Flights f)
        {
            Boolean exist = flightExist(f.getFlightNumber());
            if (exist)
                return false;
            else
            {
                FlightsDal fd = new FlightsDal();
                return fd.addFlight(f);
            }
        }
        public LinkedList<string> GetAllCountries()
        {
            FlightsDal fd = new FlightsDal();
            return fd.GetAllCountries();
        }
        public Boolean addCountry(string country)
        {
            FlightsDal fd = new FlightsDal();
            return fd.addCountry(country);
        }

        public Flight_Deatails GetFlightDeatails(int flightNumber)
        {
            FlightsDal temp = new FlightsDal();
            Flight_Deatails t = temp.GetFlightDeatails(flightNumber);
            if (t == null)
                return null;
            else
                return t;
        }
        

        public Boolean flightDeatailsExist(int flightNumber)
        {
            Flight_Deatails temp = GetFlightDeatails(flightNumber);
            if (temp == null)
                return false;
            else
                return true;
        }

        public Boolean addFlightDeatails(Flight_Deatails f)
        {
            Boolean exist = flightDeatailsExist(f.getFlightNumber());
            if (exist)
                return false;
            else
            {
                FlightsDal fd = new FlightsDal();
                return fd.addFlightDeatails(f);
            }
        }

        public LinkedList<Flights> GetDirectFlights(string from, string to,string date)
        {
            FlightsDal temp = new FlightsDal();
            return temp.GetDirectFlights(from, to,date);
        }
        public Boolean addChosenFlight(string flightNum, double totalPrice)
        {
            FlightsDal temp = new FlightsDal();
            return temp.addChosenFlight(flightNum,totalPrice);
        }
        public LinkedList<string> GetFlightsByPrice()
        {
            FlightsDal temp = new FlightsDal();
            return temp.GetFlightsByPrice();
        }
        public Boolean deleteTable()
        {
            FlightsDal temp = new FlightsDal();
            return temp.deleteTable();
        }
        public LinkedList<Flights> GetFirstStop(string from, string date)
        {
            FlightsDal temp = new FlightsDal();
            return temp.GetFirstStop(from,date);
        }
        public LinkedList<Flights> GetLastStop(string to, string date)
        {
            FlightsDal temp = new FlightsDal();
            return temp.GetLastStop(to, date);
        }
        public string GetAirlinePic(string name)
        {
            FlightsDal temp = new FlightsDal();
            return temp.GetAirlinePic(name);
        }

        public Passenger_Details GetPassenger_Details(string passport)
        {
            FlightsDal temp = new FlightsDal();
            Passenger_Details p = temp.getPassenger_Details(passport);
            if (p == null)
                return null;
            else
                return p;
        }

        public Boolean PassengerExist(string passport)
        {
            Passenger_Details temp = GetPassenger_Details(passport);
            if (temp == null)
                return false;
            else
                return true;
        }

        public Boolean addPassenger(Passenger_Details p)
        {
            Boolean exist = PassengerExist(p.getPassport());
            if (exist)
                return false;
            else
            {
                FlightsDal fd = new FlightsDal();
                return fd.addPassenger_Deatails(p);
            }
        }

        public Boolean updateSeats(int flightNum, int seatsBought)
        {
            Flight_Deatails fd = GetFlightDeatails(flightNum);
            int seatsLeft = fd.getSeatsLeft();
            int seatsRemain = seatsLeft - seatsBought;
            FlightsDal f = new FlightsDal();
            return f.updateSeats(flightNum, seatsRemain);
        }
        public Boolean updatePrice(int flightNum, double price)
        {
            FlightsDal fd = new FlightsDal();
            return fd.updatePrice(flightNum, price);
        }

        public LinkedList<string> GetAllAirlines()
        {
            FlightsDal fd = new FlightsDal();
            return fd.GetAllAirlines();
        }
        public LinkedList<Flight_Deatails> GetFlightsBetweenPrice(double min, double max)
        {
            FlightsDal fd = new FlightsDal();
            return fd.GetFlightsBetweenPrice(min, max);
        }
        public LinkedList<Flights> GetFlightsBetweenDate(DateTime start, DateTime end)
        {
            FlightsDal fd = new FlightsDal();
            return fd.GetFlightsBetweenDate(start, end);
        }
        public Boolean addPerson(people p)
        {
            FlightsDal fd = new FlightsDal();
            return fd.addPerson(p);
        }
        public LinkedList<people> GetPassengersOnFlight(int flightNum)
        {
            FlightsDal fd = new FlightsDal();
            return fd.GetPassengersOnFlight(flightNum);
        }
    }

    
}