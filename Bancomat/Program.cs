using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text;

namespace Bancomat
{
    /// <summary>
    /// Bancomat
    /// - introducere card number: 1-1000
    /// - introducere pin: 6 cifre
    /// - validare combinatie card - pin
    /// - optiuni posibile: verificare sold curent, depunere, retragere, schimbare pin, tranzactionare catre alt card, logout
    /// - extra: la logout, sa faca update in fisier cu noile valori -> introducere credentiale
    /// - extra: toate card-urle sunt tinute intr-un fisier text
    /// 
    /// - bancomatul sa ofere urmatoarele lucruri:
    /// -- acceseaza cont
    /// -- inregistreaza cont nou -> ar trebui sa ma logheze automat (sar peste introducere pin si card)
    /// -- inchidere bancomat -> opreste aplicatia
    /// 
    /// -- management-ul conturilor sunt tinute de banca iar bancomatul decat gestioneaza actiunile userilor si ale bancii
    /// - toate actiunile de mai jos sunt reprezentate de un bancomat, acesta trebuie scos intr-o clasa separata
    /// - contul o sa aiba: card_number, pin, sold
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            //bancomat.initializare
            bancomat.initializare();
            //bancomat.start
            //bancomat.start();
        }
    }
}