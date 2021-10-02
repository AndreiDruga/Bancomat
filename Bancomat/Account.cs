using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bancomat
{
    class Account
    {
        private int CardNumer { get; set; }
        private int Pin { get; set; }
        private double Sold { get; set; }

        public Account(int cardNumber, int pin, double sold)
        {
            cardNumber = CardNumer;
            pin = Pin;
            sold = Sold;
        }

        public void PrintBalance()
        {
            Console.WriteLine($"Soldul curent este: {Sold}");
        }
    }
}
    
