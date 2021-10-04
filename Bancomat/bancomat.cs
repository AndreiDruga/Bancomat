using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bancomat
{
    public class Bancomat
    {
        public static void Initialize()
        {    
           
            Console.WriteLine("alege o optiune:\r\n 1.acceseaza cont \r\n 2.creeaza cont \r\n 3.inchidere bancomat");
            int optiune1 = int.Parse(Console.ReadLine());
            while (optiune1 != 3)
            {
                switch (optiune1)
                {
                    case 1:
                        Banca.start();
                        break;
                    case 2:
                        Banca.NewAccount();
                        Banca.Exit();
                        break;
                    case 3:
                        Banca.Exit();
                        break;
                    default:
                        Banca.PrintUnkownOption();
                        break;
                }
            }
        }

    }
}

