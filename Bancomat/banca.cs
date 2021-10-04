using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bancomat
{
    class Banca
    {

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
            Console.WriteLine("Introduceti card number/pin/sold: ");
            string[] text = { "card_number:" + Console.ReadLine(), "pin:" + Console.ReadLine(), "sold:" + Console.ReadLine()};
           
            bool appendExistingFile = true;
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"Conturi.txt",
            appendExistingFile))
            { foreach (var ceva in text) {
                    sw.WriteLine($"{ceva}");
                    
            }
                sw.Close();
            }
            Banca.start();
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

        public static void PrintUnkownOption()
        {
            Console.WriteLine("Optiunea introdusa este invalida, te rog sa introduci o optiune valida!");
        }

        public static void Exit()
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

        private static void SaveAccounts(List<Account> accounts)
        {

            foreach (var account in accounts)
            {
                File.WriteAllLines("Conturi.txt", account.ConvertToString());

            }
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

