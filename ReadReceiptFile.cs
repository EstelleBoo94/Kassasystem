using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class ReadReceiptFile
    {
        public int GetReceiptNumber()
        {
            int receiptNumber = 1;
            string filePath = $"../../../ReceiptFolder/receipt_{DateTime.Now:yyyy-MM-dd}.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = lines.Length - 1; i >= 0; i--)
                {
                    if (lines[i].StartsWith("Kvittonummer: "))
                    {
                        string lastReceiptLine = lines[i];
                        string numberStr = lastReceiptLine.Replace("Kvittonummer: ", "");

                        if (int.TryParse(numberStr, out int lastReceiptNumber))
                        {
                            receiptNumber = lastReceiptNumber + 1;
                        }
                        break;
                    }
                }
            }
            return receiptNumber;
        }

    }
}
