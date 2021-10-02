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
            string[] lines = File.ReadAllLines("Conturi.txt");



            Console.WriteLine("Card Number:");
            int readCardNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Pin:");
            int readPin = int.Parse(Console.ReadLine());

            Account foundAccount = null;
            

            if (foundAccount != null)
            {
                //afisam meniul

            }
            else
            {
                Console.WriteLine("Authentication failed!");

            }

            int optiune = int.Parse(Console.ReadLine());
            while (optiune != 5)
            {
                switch (optiune)
                {
                    case 1:
                        foundAccount.PrintBalance();
                        break;

                    case 2:
                        Console.WriteLine("introduceti valoarea depusa: ");
                        int valDepusa = int.Parse(Console.ReadLine());
                        foundAccount.Sold += valDepusa;
                        Console.WriteLine($"Noul sold este: {foundAccount.Sold}");
                        break;


                    case 3:
                        Console.WriteLine("introduceti valoarea retrasa: ");
                        int valRetrasa = int.Parse(Console.ReadLine());
                        if (valRetrasa > foundAccount.Sold)
                        {
                            Console.WriteLine("Fonduri insuficiente");
                        }
                        else
                        {
                            Console.WriteLine($"Sold curent: {foundAccount.Sold -= foundAccount.Sold - valRetrasa}");
                        }
                        break;

                    case 4:
                        Console.WriteLine("introduceti noul pin: ");
                        int pinNou = int.Parse(Console.ReadLine());
                        string lungimePin = Console.ReadLine();

                        if (lungimePin.Length < 6)
                        {
                            Console.WriteLine("Lungimea minima este de 6 caractere");
                        }
                        else
                        {
                            Console.WriteLine("Pinul a fost schimbat");
                            foundAccount.Pin = pinNou;
                        }
                        break;

                    case 5:
                        break;

                    default:
                        Console.WriteLine("Alege o alta optiune valabila");
                        break;
                }
                Console.ReadKey();
                printMenu();
                optiune = int.Parse(Console.ReadLine());
            }

        }
        public static void printMenu()
        {
            Console.Clear();
            Console.WriteLine("Alege o optiune:1 interogare solt \r\n  2: depunere \r\n  3: retragere \r\n  4: schimbare pin \r\n   5: logout");
        }


        public static List<Account> ReadAccountFromLines (string[] lines) {

            List<Account> accounts = new List<Account>();
            for (int index = 0; index < lines.Length; index += 3)
            {
                Account account = new Account(
                
                    CardNumer = int.Parse(lines[index].Substring(lines[index].IndexOf(":") + 1)),
                    Pin = int.Parse(lines[index + 1].Substring(lines[index + 1].IndexOf(":") + 1)),
                    Sold = double.Parse(lines[index + 2].Substring(lines[index + 2].IndexOf(":") + 1))
                );
                accounts.Add(account);
            }
            return accounts;
        }
       

            public static void Autentificate(int cardNumber, int Pin,List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                if (account.CardNumer == readCardNumber && account.Pin == readPin)
                {
                    foundAccount = account;
                    break;
                }
            }
        }
    }
}
