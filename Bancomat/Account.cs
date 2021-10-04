using System;

namespace Bancomat
{
    public class Account
    {
        private int cardNumber { get; set; }
        private int pin { get; set; }
        private double sold { get; set; }

        public Account(int cardNumber, int pin, double sold)
        {
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.sold = sold;
        }

        public bool ValidateCredentials(int cardNumber, int pin)
        {
            return this.cardNumber == cardNumber && this.pin == pin;
        }

        public void ChangePin(int validPin)
        {
            pin = validPin;

        }

        public void PrintBalance()
        {
            Console.WriteLine($"Soldul contului curent este: {sold}");
        }

        public void IncreaseSold(double addedValue)
        {
            sold += addedValue;
        }

        public void DecreaseSold(double value)
        {
            sold -= value;
        }

        public double SoldValue()
        {
            return sold;
        }

        public string[] ConvertToString()
        {
            string[] lines = {
                this.cardNumber.ToString(),
                   this.pin.ToString(),
                    this.sold.ToString()};
            return lines;
        }

    }
}
