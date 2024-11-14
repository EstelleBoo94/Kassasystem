using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystem.ReadingAndWritingFolder;
using Kassasystem.Resources;

namespace Kassasystem.PurchasesFolder
{
    public class Pay
    {
        bool wasPaymentMethodCash = true;
        int payment = 0;
        int moneyBack = 0;
        public void PayCard()
        {
            wasPaymentMethodCash = false;
            Console.WriteLine("\nBetalningen genomfördes.\n");
            WriteReceiptToTxt.WriteReceiptToFile(ReceiptListClass.GetReceiptList(), wasPaymentMethodCash, payment, moneyBack);
            ReceiptListClass.ClearReceiptList();
        }

        public void PayCash()
        {
            wasPaymentMethodCash = true;
            Console.Clear();
            payment = InputValidator.GetValidInt($"Hur mycket betalar kunden? Summa att betala: {Receipt.Total:F2}");

            int roundedTotal = (int)Math.Round(Receipt.Total);
            moneyBack = payment - roundedTotal;

            int Fivehundred = moneyBack / 500;
            int RestFivehundred = moneyBack % 500;
            int Hundred = RestFivehundred / 100;
            int RestHundred = RestFivehundred % 100;
            int Fifty = RestHundred / 50;
            int RestFifty = RestHundred % 50;
            int Twenty = RestFifty / 20;
            int RestTwenty = RestFifty % 20;
            int Ten = RestTwenty / 10;
            int RestTen = RestTwenty % 10;
            int one = RestTen / 1;
            Console.WriteLine($"Kunden ska få tillbaka: {moneyBack} kr \n{Fivehundred}" +
                $" x femhundrasedlar\n{Hundred} x etthundrasedlar\n{Fifty} x femtiosedlar" +
                $"\n{Twenty} x tjugosedlar\n{Ten} x tiokronor\n{one} x enkronor.");

            WriteReceiptToTxt.WriteReceiptToFile(ReceiptListClass.GetReceiptList(), wasPaymentMethodCash, payment, moneyBack);
            ReceiptListClass.ClearReceiptList();

        }

    }
}
