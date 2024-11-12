using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class Pay
    {
        public void PayCard()
        {
            Console.WriteLine("\nBetalningen genomfördes.\n");
            WriteReceiptToTxt.WriteReceiptToFile(ReceiptListClass.GetReceiptList());
            ReceiptListClass.ClearReceiptList();
        }

        public void PayCash()
        {
            Console.Clear();
            int payment = InputValidator.GetValidInt($"Hur mycket betalar kunden? Summa att betala: {Receipt.Total:F2}");

            int roundedTotal = (int)Math.Round(Receipt.Total);
            int money = payment - roundedTotal;

            int Fivehundred = money / 500;
            int RestFivehundred = money % 500;
            int Hundred = RestFivehundred / 100;
            int RestHundred = RestFivehundred % 100;
            int Fifty = RestHundred / 50;
            int RestFifty = RestHundred % 50;
            int Twenty = RestFifty / 20;
            int RestTwenty = RestFifty % 20;
            int Ten = RestTwenty / 10;
            int RestTen = RestTwenty % 10;
            int one = RestTen / 1;
            Console.WriteLine($"Kunden ska få tillbaka: \n{Fivehundred}" +
                $" x femhundrasedlar\n{Hundred} x etthundrasedlar\n{Fifty} x femtiosedlar" +
                $"\n{Twenty} x tjugosedlar\n{Ten} x tiokronor\n{one} x enkronor.");

            WriteReceiptToTxt.WriteReceiptToFile(ReceiptListClass.GetReceiptList());
            ReceiptListClass.ClearReceiptList();

        }

    }
}
