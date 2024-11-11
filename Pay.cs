using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class Pay
    {
        //public float Total { get; set; }

        //private Receipt _receipt;
        //public Pay(Receipt receipt)
        //{
        //    _receipt = receipt;
        //}

        //public Pay(float total)
        //{
        //    Total = total;
        //}

        public void PayCard()
        {
            Console.WriteLine("\nBetalningen genomfördes.\n");
            WriteReceiptToTxt.WriteReceiptToFile(ReceiptListClass.GetReceiptList(), Receipt.Total);
            ReceiptListClass.ClearReceiptList();
        }

        public void PayCash()
        {
            Console.WriteLine($"Hur mycket betalar kunden? Summa att betala: {Receipt.Total}");
            float payment = Convert.ToSingle(Console.ReadLine());

            float money = payment - Receipt.Total;

            float Fivehundred = money / 500;
            float RestFivehundred = money % 500;
            float Hundred = RestFivehundred / 100;
            float RestHundred = RestFivehundred % 100;
            float Fifty = RestHundred / 50;
            float RestFifty = RestHundred % 50;
            float Twenty = RestFifty / 20;
            float RestTwenty = RestFifty % 20;
            float Ten = RestTwenty / 10;
            float RestTen = RestTwenty % 10;
            float one = RestTen / 1;
            Console.WriteLine($"Kunden ska få tillbaka: \n{Fivehundred}" +
                $" femhundringar\n{Hundred} hundralappar\n{Fifty} femtiolappar" +
                $"\n{Twenty} tjugolappar\n{Ten} tiokronor\n{one} enkronor.");

            WriteReceiptToTxt.WriteReceiptToFile(ReceiptListClass.GetReceiptList(), Receipt.Total);
            ReceiptListClass.ClearReceiptList();

        }

    }
}
