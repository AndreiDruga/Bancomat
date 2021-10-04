using System;
using System.Collections.Generic;
using System.IO;

namespace Bancomat
{
    public class Banca
    {
        private List<Account> Accounts { get; }

        public Banca()
        {
            string[] lines = File.ReadAllLines("Conturi.txt");
            Accounts = ReadAccountsFromLines(lines);
        }

        public void RegisterNewAccount(int cardNumber, int pin)
        {
            Accounts.Add(new Account(cardNumber, pin, 0));
        }

        private static List<Account> ReadAccountsFromLines(string[] lines)
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

        public void SaveAccounts()
        {
            foreach (var account in Accounts)
            {
                File.WriteAllLines("Conturi.txt", account.ConvertToString());
            }
        }

        public Account Authenticate(int cardNumber, int pin)
        {
            foreach (var account in Accounts)
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

