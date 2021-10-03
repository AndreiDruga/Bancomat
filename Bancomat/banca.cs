using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bancomat
{
    class banca
    {

        public  void SaveAccounts(List<Account> accounts)
        {

            foreach (var account in accounts)
            {
                File.WriteAllLines("Conturi.txt", account.ConvertToString());

            }
        }




    }

    }

