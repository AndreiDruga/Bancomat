using System;
using System.Collections.Generic;
using System.IO;

namespace Bancomat
{
    /// <summary>
    /// Bancomat
    /// - introducere card number: 1-1000
    /// - introducere pin: 6 cifre
    /// - validare combinatie card - pin
    /// - optiuni posibile: verificare sold curent, depunere, retragere, schimbare pin, tranzactionare catre alt card, logout
    /// - extra: la logout, sa faca update in fisier cu noile valori
    /// - extra: toate card-urle sunt tinute intr-un fisier text
    /// - contul o sa aiba: card_number, pin, sold
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("conturi.txt");

            List<Account> accounts = new List<Account>();
            for (int index = 0; index < lines.Length; index += 3)
            {
                Account account = new Account()
                {
                    CardNumer = int.Parse(lines[index].Substring(lines[index].IndexOf(":") + 1)),
                    Pin = int.Parse(lines[index + 1].Substring(lines[index + 1].IndexOf(":") + 1)),
                    Sold = double.Parse(lines[index + 2].Substring(lines[index + 2].IndexOf(":") + 1))
                };
                accounts.Add(account);
            }

            Console.WriteLine("Card Number:");
            int readCardNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Pin:");
            int readPin = int.Parse(Console.ReadLine());

            Account foundAccount = null;
            foreach (var account in accounts)
            {
                if (account.CardNumer == readCardNumber && account.Pin == readPin)
                {
                    foundAccount = account;
                    break;
                }
            }

            if (foundAccount != null)
            {
                Console.WriteLine("You are logged!");
                //afisam meniul
                 Console.WriteLine("Alege o optiune:");
            }
            else
            {
                Console.WriteLine("Authentication failed!");
            }

            Console.ReadKey();
        }
    }

    public class Account
    {
        public int CardNumer { get; set; }
        public int Pin { get; set; }
        public double Sold { get; set; }
    }
}
