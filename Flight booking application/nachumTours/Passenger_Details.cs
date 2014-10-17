using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nachumTours
{
    public class Passenger_Details
    {
        private string firstName;
        private string lastName;
        private int age;
        private string birthDate;
        private string passport;
        private string email;
        private string cardType;
        private string cardNumber;
        private string securityCode;
        private string expireDate;
        private string nameOnCard;

        public Passenger_Details(string firstName, string lastName, int age, string birthDate, string passport, string email,
            string cardType,string cardNumber, string securityCode, string expireDate, string nameOnCard)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.birthDate = birthDate;
            this.passport = passport;
            this.email = email;
            this.cardType = cardType;
            this.cardNumber = cardNumber;
            this.securityCode = securityCode;
            this.expireDate = expireDate;
            this.nameOnCard = nameOnCard;
        }

        public string getFirstName(){return this.firstName;}
        public string getLastName() { return this.lastName; }
        public int getAge() { return this.age; }
        public string getBirthDate() { return this.birthDate; }
        public string getPassport() { return this.passport; }
        public string getEmail() { return this.email; }
        public string getCardType() { return this.cardType; }
        public string getCardNumber() { return this.cardNumber; }
        public string getSecurityCode() { return this.securityCode; }
        public string getExpireDate() { return this.expireDate; }
        public string getNameOnCard() { return this.nameOnCard; }

        public void setFirstName(string firstName) { this.firstName = firstName; }
        public void setLastName(string lastName) { this.lastName = lastName; }
        public void setAge(int age) { this.age = age; }
        public void setBirthDate(string birthDate) { this.birthDate = birthDate; }
        public void setPassport(string passport) { this.passport = passport; }
        public void setEmail(string email) { this.email = email; }
        public void setCardType(string cardType) { this.cardType = cardType; }
        public void setCardNumber(string cardNumber) { this.cardNumber = cardNumber; }
        public void setSecurityCode(string securityCode) { this.securityCode = securityCode; }
        public void setExpireDate(string expireDate) { this.expireDate = expireDate; }
        public void setNameOnCard(string nameOnCard) { this.nameOnCard = nameOnCard; }
        
        
    }
}