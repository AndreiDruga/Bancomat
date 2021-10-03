using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp3
{
    class bancomat
    {
        public static void initializare()
        {
            Console.WriteLine("alege o optiune:\r\n 1.acceseaza cont \r\n 2.creeaza cont \r\n 3.inchidere bancomat");
            int optiune1 = int.Parse(Console.ReadLine());
            while (optiune1 !=3)
            {
                switch (optiune1)
                {
                    case 1:
                        start();
                        
                        break;
                    case 2:

                      
                        break;
                    case 3:
                        //Withdraw(foundAccount);
                        break;
                    default:
                        PrintUnkownOption();
                        break;
                }
            }
        }
        public static void start()
        {
            string[] lines = File.ReadAllLines("Conturi.txt");
            List<Account> accounts = ReadAccountsFromLines(lines);

            Console.WriteLine("Card Number:");
            int readCardNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Pin:");
            int readPin = int.Parse(Console.ReadLine());

            Account foundAccount = Authenticate(readCardNumber, readPin, accounts);
            if (foundAccount == null)
            {
                Console.WriteLine("Authentication failed!");
            }
            else
            {
                optiune(accounts, foundAccount);
            } 
        }
        public static void NewAccount()
        {
            Console.WriteLine("Introduceti card number: ");
            StreamWriter f = new StreamWriter("c:\\test\\lista.txt");
        }

        private static void optiune(List<Account> accounts, Account foundAccount)
        {
            PrintMenu();
            int optiune = int.Parse(Console.ReadLine());
            while (optiune != 5)
            {
                switch (optiune)
                {
                    case 1:
                        foundAccount.PrintBalance();
                        break;
                    case 2:
                        Deposit(foundAccount);
                        break;
                    case 3:
                        Withdraw(foundAccount);
                        break;
                    case 4:
                        ChangePin(foundAccount);
                        break;
                    case 5:
                       
                        SaveAccounts(accounts);
                        Exit();
                        break;
                    default:
                        PrintUnkownOption();
                        break;
                }
                Console.ReadKey();
                PrintMenu();
                optiune = int.Parse(Console.ReadLine());
            }
        }

        private static void PrintUnkownOption()
        {
            Console.WriteLine("Optiunea introdusa este invalida, te rog sa introduci o optiune valida!");
        }
        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void ChangePin(Account foundAccount)
        {
            Console.WriteLine("introduceti noul pin: ");
            string pinNou = Console.ReadLine();

            if (pinNou.Length < 6)
            {
                Console.WriteLine("Lungimea minima este de 6 caractere");
            }
            else
            {
                Console.WriteLine("Pinul a fost schimbat");
                foundAccount.ChangePin(int.Parse(pinNou));
            }
        }
        private static void Withdraw(Account account)
        {
            Console.WriteLine("introduceti valoarea retrasa: ");
            int valRetrasa = int.Parse(Console.ReadLine());
            if (valRetrasa > account.SoldValue())
            {
                Console.WriteLine("Fonduri insuficiente");
            }
            else
            {
                account.DecreaseSold(valRetrasa);
                account.PrintBalance();
            }
        }
        private static void Deposit(Account account)
        {
            Console.WriteLine("introduceti valoarea depusa: ");
            double valDepusa = double.Parse(Console.ReadLine());
            account.IncreaseSold(valDepusa);
            account.PrintBalance();

        }
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Alege o optiune:\n1: interogare solt \r\n2: depunere \r\n3: retragere \r\n4: schimbare pin \r\n5: logout");
        }
        public static List<Account> ReadAccountsFromLines(string[] lines)
        {
            List<Account> accounts = new List<Account>();
            for (int index = 0; index < lines.Length; index += 3)
            {
                Account account = new Account(
                    int.Parse(lines[index].Substring(lines[index].IndexOf(":") + 1)),
                    int.Parse(lines[index + 1].Substring(lines[index + 1].IndexOf(":") + 1)),
                    double.Parse(lines[index + 2].Substring(lines[index + 2].IndexOf(":") + 1))
                );
                accounts.Add(account);
            }
            return accounts;
        }
        
        public static Account Authenticate(int cardNumber, int pin, List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                if (account.ValidateCredentials(cardNumber, pin))
                {
                    return account;
                }
            }
            return null;
        }
    }
}

