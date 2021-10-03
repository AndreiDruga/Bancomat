using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bancomat
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
                        banca.start();  //acceseaza accouunt si af toate optiunile
                        break;
                    case 2:
                        banca.NewAccount();
                        banca.Exit();
                        break;
                    case 3:
                        //banca.logOut();
                        break;
                    default:
                    
                        break;
                }
            }
        }
        
    }
}

