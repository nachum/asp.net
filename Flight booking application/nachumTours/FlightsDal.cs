using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlServerCe;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Common;

namespace nachumTours
{
    public class FlightsDal
    {
        //private const string conString = @"Data Source=C:\Users\נחום\Documents\Visual Studio 2012\Projects\nachumTours\nachumTours\App_Data\Deatails.sdf";
        private const string conString = @"Data Source= |DataDirectory|\Deatails.sdf";
        public Flights GetFlight(int flightNumber)
        {
            try
            {
                SqlCeConnection con = new SqlCeConnection(conString);
                con.Open();
                String quary = "SELECT * FROM flights WHERE flightNumber= '" + flightNumber + "'";
                SqlCeCommand com = new SqlCeCommand(quary, con);
                SqlCeDataReader rdr = com.ExecuteReader();
                if (rdr.Read() == false)
                    return null;
                else
                {
                    int fNumber = (int)rdr[0];
                    string from = "" + rdr[1];
                    string to = "" + rdr[2];
                    string date = "" + rdr[3];
                    Flights temp = new Flights(fNumber, from, to,date);
                    con.Close();
                    return temp;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Boolean addFlight(Flights f)
        {
            String quary = "INSERT INTO flights ([flightNumber], [depart], [arrive], [date]) VALUES ('" + f.getFlightNumber() + "','" + f.getFrom() +
                               "','" +f.getTo() +"','"+f.getDate()+ "')";
            //String quary = "INSERT INTO flights (flightNumber, from, to, date) VALUES ('" + f.getFlightNumber() + "','" + f.getFrom() +
              //                 "','" + f.getTo() + "','" + f.getDate() + "')";
            try
            {
                SqlCeConnection con = new SqlCeConnection(conString);
                con.Open();
                SqlCeCommand com = new SqlCeCommand(quary, con);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public Boolean countryExist(string country)
        {
            try
            {
                SqlCeConnection con = new SqlCeConnection(conString);
                con.Open();
                String quary = "SELECT * FROM destinations WHERE country= '" + country + "'";
                SqlCeCommand com = new SqlCeCommand(quary, con);
                SqlCeDataReader rdr = com.ExecuteReader();
                if (rdr.Read() == false)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean addCountry(string country)
        {
            Boolean exist = countryExist(country);
            if (exist)
                return false;
            else
            {
                String quary = "INSERT INTO destinations ([country]) VALUES ('" + country  + "')";
                try
                {
                    SqlCeConnection con = new SqlCeConnection(conString);
                    con.Open();
                    SqlCeCommand com = new SqlCeCommand(quary, con);
                    com.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public LinkedList<string> GetAllCountries()
        {
             LinkedList<string> countries=new LinkedList<string>();
              try
            {
                SqlCeConnection con = new SqlCeConnection(conString);
                con.Open();
                String quary = "SELECT * FROM destinations ORDER BY country";
                SqlCeCommand com = new SqlCeCommand(quary, con);
                SqlCeDataReader rdr = com.ExecuteReader();
                
                if (rdr.Read() == false)
                    return null;
                else
                {
                    do
                    {
                    countries.AddLast(""+rdr[0]);
                   }while(rdr.Read()!=false);
                }
                   con.Close();
                  return countries;
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        public Flight_Deatails GetFlightDeatails(int flightNumber)
        {
            try
            {
                SqlCeConnection con = new SqlCeConnection(conString);
                con.Open();
                String quary = "SELECT * FROM flight_deatails WHERE flightNumber= '" + flightNumber + "'";
                SqlCeCommand com = new SqlCeCommand(quary, con);
                SqlCeDataReader rdr = com.ExecuteReader();
                if (rdr.Read() == false)
                    return null;
                else
                {
                    int fNumber = (int)rdr[0];
                    double duration = (double)rdr[1];
                    double price = (double)rdr[2];
                    double dTime = (double)rdr[3];
                    string airline = "" + rdr[4];
                    int seatsLeft = (int)rdr[5];
                    Flight_Deatails temp = new Flight_Deatails(fNumber, duration,price,dTime,airline,seatsLeft);
                    con.Close();
                    return temp;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Boolean addFlightDeatails(Flight_Deatails f)
        {
            String quary = "INSERT INTO flight_deatails ([flightNumber], [duration], [price],[deapartTime], [airline], [seatsLeft]) VALUES ('"
                + f.getFlightNumber() + "','" + f.getDuration() + "','" + f.getPrice() + "','" + f.getDeapartTime() + "','" + f.getAirline() + "','" +f.getSeatsLeft() + "')";
            try
            {
                SqlCeConnection con = new SqlCeConnection(conString);
                con.Open();
                SqlCeCommand com = new SqlCeCommand(quary, con);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public LinkedList<Flights> GetDirectFlights(string from,string to, string date)
        {
            string Tfrom = from.Trim();
            string Tto = to.Trim();
            string Tdate = date.Trim();
            LinkedList<Flights> directFlights = new LinkedList<Flights>();
            try
            {
                SqlCeConnection con = new SqlCeConnection(conString);
               
                   con.Open();
                   String quary = "SELECT * FROM flights WHERE depart= '" + Tfrom + "' AND arrive= '" + Tto + "' AND date= '" + Tdate + "'";
                //"' AND to='"+to+
                SqlCeCommand com = new SqlCeCommand(quary, con);
                
                    SqlCeDataReader rdr = com.ExecuteReader();
                if (rdr.Read() == false)
                    return null;
                else
                {
                    do
                    {
                        int fn=(int)rdr[0];
                        string fr=""+rdr[1];
                        string t=""+rdr[2];
                        string da = "" + rdr[3];
                        Flights temp=new Flights(fn,fr,t,da);
                    directFlights.AddLast(temp);
                   }while(rdr.Read()!=false);
                }
                   con.Close();
                  return directFlights;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Boolean addChosenFlight(string flightNum, double totalPrice)
        {
            String quary = "INSERT INTO chosenFlights ([flightNumbers], [totalPrice]) VALUES ('" + flightNum  + "','" + totalPrice + "')";
            try
            {
                SqlCeConnection con = new SqlCeConnection(conString);
                con.Open();
                SqlCeCommand com = new SqlCeCommand(quary, con);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public LinkedList<string> GetFlightsByPrice()
        {
            LinkedList<string> flightNum = new LinkedList<string>();
            try
            {
                SqlCeConnection con = new SqlCeConnection(conString);
               
                   con.Open();
                   String quary = "SELECT * FROM chosenFlights ORDER BY totalPrice";
                //"' AND to='"+to+
                SqlCeCommand com = new SqlCeCommand(quary, con);
                
                    SqlCeDataReader rdr = com.ExecuteReader();
                if (rdr.Read() == false)
                    return null;
                else
                {
                    do
                    {
                        
                        string nums=""+rdr[0];
                        
                    flightNum.AddLast(nums);
                   }while(rdr.Read()!=false);
                }
                   con.Close();
                  return flightNum;
            }
            catch (Exception)
            {
                return null;
            }
        }

         public Boolean deleteTable()
         {
             String quary = "DELETE FROM chosenFlights";
            try
            {
                SqlCeConnection con = new SqlCeConnection(conString);
                con.Open();
                SqlCeCommand com = new SqlCeCommand(quary, con);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
         }

         public LinkedList<Flights> GetFirstStop(string from, string date)
         {
             string Tfrom = from.Trim();
             
             string Tdate = date.Trim();
             LinkedList<Flights> directFlights = new LinkedList<Flights>();
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);

                 con.Open();
                 String quary = "SELECT * FROM flights WHERE depart= '" + Tfrom + "' AND date= '" + Tdate + "'";
                 //"' AND to='"+to+
                 SqlCeCommand com = new SqlCeCommand(quary, con);

                 SqlCeDataReader rdr = com.ExecuteReader();
                 if (rdr.Read() == false)
                     return null;
                 else
                 {
                     do
                     {
                         int fn = (int)rdr[0];
                         string fr = "" + rdr[1];
                         string t = "" + rdr[2];
                         string da = "" + rdr[3];
                         Flights temp = new Flights(fn, fr, t, da);
                         directFlights.AddLast(temp);
                     } while (rdr.Read() != false);
                 }
                 con.Close();
                 return directFlights;
             }
             catch (Exception)
             {
                 return null;
             }
         }

         public LinkedList<Flights> GetLastStop(string to, string date)
         {
             string Tto = to.Trim();
             string Tdate = date.Trim();
             

             LinkedList<Flights> lastFlights = new LinkedList<Flights>();
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);

                 con.Open();
                 String quary = "SELECT * FROM flights WHERE arrive= '" + Tto + "' AND date= '" + Tdate + "'";
                 //"' AND to='"+to+
                 SqlCeCommand com = new SqlCeCommand(quary, con);
                 SqlCeDataReader rdr = com.ExecuteReader();
                 if (rdr.Read() == false)
                     return null;
                 else
                 {
                     do
                     {
                         int fn = (int)rdr[0];
                         string fr = "" + rdr[1];
                         string t = "" + rdr[2];
                         string da = "" + rdr[3];
                         Flights temp = new Flights(fn, fr, t, da);
                         lastFlights.AddLast(temp);
                     } while (rdr.Read() != false);
                 }
                 con.Close();
                 return lastFlights;
             }
             catch (Exception)
             {
                 return null;
             }
         }

         public string GetAirlinePic(string name)
         {
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);
                 con.Open();
                 String quary = "SELECT picture FROM Airlines WHERE name= '" + name + "'";
                 SqlCeCommand com = new SqlCeCommand(quary, con);
                 SqlCeDataReader rdr = com.ExecuteReader();
                 if (rdr.Read() == false)
                     return null;
                 else
                 {
                     string from = "" + rdr[0];
                     con.Close();
                     return from;
                 }
             }
             catch (Exception)
             {
                 return null;
             }
         }
         public Passenger_Details getPassenger_Details(string passport)
         {
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);
                 con.Open();
                 String quary = "SELECT * FROM Passengers WHERE passport= '" + passport + "'";
                 SqlCeCommand com = new SqlCeCommand(quary, con);
                 SqlCeDataReader rdr = com.ExecuteReader();
                 if (rdr.Read() == false)
                     return null;
                 else
                 {
                    string firstName=""+rdr[0];
                    string lastName = "" + rdr[1];
                    int age=(int)rdr[2];
                    string birthDate = "" + rdr[3];
                    string passportNum = "" + rdr[4];
                    string email = "" + rdr[5];
                    string cardType = "" + rdr[6];
                    string cardNumber = "" + rdr[7];
                    string securityCode = "" + rdr[8];
                    string expireDate = "" + rdr[9];
                    string nameOnCard = "" + rdr[10];

                    Passenger_Details temp = new Passenger_Details( firstName, lastName, age, birthDate, passportNum, email,
                                                cardType, cardNumber,securityCode, expireDate, nameOnCard);
                     con.Close();
                     return temp;
                 }
             }
             catch (Exception)
             {
                 return null;
             }
         }

         public Boolean addPassenger_Deatails(Passenger_Details p)
         {
             String quary = "INSERT INTO Passengers ([firstName], [lastName], [age],[birthDate], [passport], [email],[cardType]"
                 +", [cardNumber], [securityCode], [expireDate],[nameOnCard]) VALUES ('"+p.getFirstName()+"','"+p.getLastName()
                 +"','"+ p.getAge() + "','" +p.getBirthDate() + "','" + p.getPassport() + "','" + p.getEmail() + "','" 
                 + p.getCardType()+"','"+p.getCardNumber()+"','"+p.getSecurityCode()+"','"+p.getExpireDate() + "','" + p.getNameOnCard() + "')";
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);
                 con.Open();
                 SqlCeCommand com = new SqlCeCommand(quary, con);
                 com.ExecuteNonQuery();
                 con.Close();
                 return true;
             }
             catch (Exception)
             {
                 return false;
             }
         }
         public Boolean updateSeats(int flightNum, int seats)
         {
             String quary = "UPDATE flight_deatails "
             +"SET seatsLeft = '"+seats+"'"
             +" WHERE flightNumber = '"+flightNum+"'" ;
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);
                 con.Open();
                 SqlCeCommand com = new SqlCeCommand(quary, con);
                 com.ExecuteNonQuery();
                 con.Close();
                 return true;
             }
             catch (Exception)
             {
                 return false;
             }
         }

         public LinkedList<string> GetAllAirlines()
         {
             LinkedList<string> airlines = new LinkedList<string>();
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);
                 con.Open();
                 String quary = "SELECT name FROM Airlines ORDER BY name";
                 SqlCeCommand com = new SqlCeCommand(quary, con);
                 SqlCeDataReader rdr = com.ExecuteReader();

                 if (rdr.Read() == false)
                     return null;
                 else
                 {
                     do
                     {
                         airlines.AddLast("" + rdr[0]);
                     } while (rdr.Read() != false);
                 }
                 con.Close();
                 return airlines;
             }
             catch (Exception)
             {
                 return null;
             }

         }
         public Boolean updatePrice(int flightNum, double price)
         {
             String quary = "UPDATE flight_deatails "
             + "SET price = '" + price + "'"
             + " WHERE flightNumber = '" + flightNum + "'";
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);
                 con.Open();
                 SqlCeCommand com = new SqlCeCommand(quary, con);
                 com.ExecuteNonQuery();
                 con.Close();
                 return true;
             }
             catch (Exception)
             {
                 return false;
             }
         }
         public LinkedList<Flight_Deatails> GetFlightsBetweenPrice(double min, double max)
         {
             LinkedList<Flight_Deatails> betweenFlights = new LinkedList<Flight_Deatails>();
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);

                 con.Open();
                 String quary = "SELECT * FROM flight_deatails WHERE price BETWEEN '" + min+ "' AND  '" + max +  "'";
                 SqlCeCommand com = new SqlCeCommand(quary, con);

                 SqlCeDataReader rdr = com.ExecuteReader();
                 if (rdr.Read() == false)
                     return null;
                 else
                 {
                     do
                     {
                         int fNumber = (int)rdr[0];
                         double duration = (double)rdr[1];
                         double price = (double)rdr[2];
                         double dTime = (double)rdr[3];
                         string airline = "" + rdr[4];
                         int seatsLeft = (int)rdr[5];
                         Flight_Deatails temp = new Flight_Deatails(fNumber, duration, price, dTime, airline, seatsLeft);

                         betweenFlights.AddLast(temp);
                     } while (rdr.Read() != false);
                 }
                 con.Close();
                 return betweenFlights;
             }
             catch (Exception)
             {
                 return null;
             }
         }

         public LinkedList<Flights> GetFlightsBetweenDate(DateTime start,DateTime end)
         {
             LinkedList<Flights> betweenFlights = new LinkedList<Flights>();
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);

                 con.Open();
                 String quary = "SELECT * FROM flights";
                 SqlCeCommand com = new SqlCeCommand(quary, con);

                 SqlCeDataReader rdr = com.ExecuteReader();
                 if (rdr.Read() == false)
                     return null;
                 else
                 {
                     do
                     {
                         int fn = (int)rdr[0];
                         string fr = "" + rdr[1];
                         string t = "" + rdr[2];
                         string da = "" + rdr[3];
                         if (checkBetween(da, start, end))
                         {
                             Flights temp = new Flights(fn, fr, t, da);
                             betweenFlights.AddLast(temp);
                         }
                     } while (rdr.Read() != false);
                 }
                 con.Close();
                 return betweenFlights;
             }
             catch (Exception)
             {
                 return null;
             }
         }
         private Boolean checkBetween(string date, DateTime start, DateTime end)
         {
             DateTime check = Convert.ToDateTime(date);
             if (check >= start && check <= end)
                 return true;
             else
                 return false;
         }

         public Boolean addPerson(people p)
         {
             String quary = "INSERT INTO passengersInFlights ([passport], [firstName], [lastName], [Email], [flightNumber]) "
             + "VALUES ('" + p.getPassport() + "','" + p.getFirstName() + "','" + p.getLastName() + "','" + p.getEmail() + "','" + p.getFlightNumber() + "')";
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);
                 con.Open();
                 SqlCeCommand com = new SqlCeCommand(quary, con);
                 com.ExecuteNonQuery();
                 con.Close();
                 return true;
             }
             catch (Exception)
             {
                 return false;
             }
         }
         public LinkedList<people> GetPassengersOnFlight(int flightNum)
         {
             LinkedList<people> passOn = new LinkedList<people>();
             try
             {
                 SqlCeConnection con = new SqlCeConnection(conString);

                 con.Open();
                 String quary = "SELECT * FROM passengersInFlights WHERE flightNumber = '"+flightNum+"'";
                 SqlCeCommand com = new SqlCeCommand(quary, con);

                 SqlCeDataReader rdr = com.ExecuteReader();
                 if (rdr.Read() == false)
                     return null;
                 else
                 {
                     do
                     {
                         string pass = ""+rdr[0];
                         string first = "" + rdr[1];
                         string last = "" + rdr[2];
                         string email = "" + rdr[3];
                         int fn = (int)rdr[4];
                         
                             people temp = new people(pass,first,last,email,fn);
                             passOn.AddLast(temp);
                         
                     } while (rdr.Read() != false);
                 }
                 con.Close();
                 return passOn;
             }
             catch (Exception)
             {
                 return null;
             }
         }
         
    }
     
        
    }

            
           
            



