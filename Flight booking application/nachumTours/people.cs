using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nachumTours
{
    public class people
    {
        private string passport;
        private string firstName;
        private string lastName;
        private string Email;
        private int flightNumber;

        public people(string passport, string firstName, string lastName, string Email, int flightNumber)
        {
            this.passport = passport;
            this.firstName = firstName;
            this.lastName = lastName;
            this.Email = Email;
            this.flightNumber = flightNumber;
        }

        public string getPassport() { return this.passport; }
        public string getFirstName() { return this.firstName; }
        public string getLastName() { return this.lastName; }
        public string getEmail() { return this.Email; }
        public int getFlightNumber() { return this.flightNumber; }

        public void setPassport(string passport) { this.passport = passport; }
        public void setFirstName(string firstName) { this.firstName = firstName; }
        public void setLastName(string lastName) { this.lastName = lastName; }
        public void setEmail(string Email) { this.Email = Email; }
        public void setFlightNumber(int flightNumber) { this.flightNumber = flightNumber; }
    }
}