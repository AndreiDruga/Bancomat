using System;

namespace Bancomat
{
    public static class Bancomat
    {
        public static void Initialize()
        {
            Banca banca = new Banca();
            PrintMainMenu();
            int optiune;
            do
            {
                optiune = int.Parse(Console.ReadLine());
                switch (optiune)
                {
                    case 1:
                        AccessAccount(banca);
                        break;
                    case 2:
                        CreateNewAccount(banca);
                        break;
                    case 3:
                        banca.SaveAccounts();
                        break;
                    default:
                        PrintUnkownOption();
                        break;
                }
                PrintMainMenu();
            } while (optiune != 3);
        }

        private static void AccessAccount(Banca banca)
        {
            Console.WriteLine("Card Number:");
            int readCardNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Pin:");
            int readPin = int.Parse(Console.ReadLine());

            Account account = banca.Authenticate(readCardNumber, readPin);
            if (account == null)
            {
                Console.WriteLine("Authentication failed!");
                Console.ReadKey();
            }
            else
            {
                ShowAccountOptions(account);
            }
        }

        private static void CreateNewAccount(Banca banca)
        {
            Console.WriteLine("Introduceti card number/pin: ");

            Console.WriteLine("Card Number:");
            int readCardNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Pin:");
            int readPin = int.Parse(Console.ReadLine());

            banca.RegisterNewAccount(readCardNumber, readPin);
        }

        private static void ShowAccountOptions(Account foundAccount)
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
                    default:
                        PrintUnkownOption();
                        break;
                }
                Console.ReadKey();
                PrintMenu();
                optiune = int.Parse(Console.ReadLine());
            }
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

        public static void PrintUnkownOption()
        {
            Console.WriteLine("Optiunea introdusa este invalida, te rog sa introduci o optiune valida!");
        }

        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Alege o optiune:\n1: interogare solt \r\n2: depunere \r\n3: retragere \r\n4: schimbare pin \r\n5: logout");
        }

        private static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("alege o optiune:\r\n 1.acceseaza cont \r\n 2.creeaza cont \r\n 3.inchidere bancomat");
        }
    }
}

