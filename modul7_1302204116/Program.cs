using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul7_1302204116
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankTransferConfig ConfigBankTransfer = new BankTransferConfig();
            dynamic conf = ConfigBankTransfer.ReadJson();

            if (conf.lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer : ");
            }
            else if (conf.lang == "id")
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer : ");
            }

            string TransferUangStr = Console.ReadLine();
            int TransferUangInt = int.Parse(TransferUangStr);

            int FeeTransfer;
            if (TransferUangInt <= (int)conf.transfer.threshold)
            {
                FeeTransfer = conf.transfer.low_fee;
            }
            else
            {
                FeeTransfer = conf.transfer.high_fee;
            }

            if (conf.lang == "en")
            {
                Console.WriteLine("Transfer fee = " + FeeTransfer);
                Console.WriteLine("Total amount = " + (FeeTransfer + TransferUangInt) );
                Console.WriteLine("Select transfer method");
            }
            else if (conf.lang == "id")
            {
                Console.WriteLine("Biaya transfer = " + FeeTransfer);
                Console.WriteLine("Total biaya = " + (FeeTransfer + TransferUangInt) );
                Console.WriteLine("Pilih metode transfer");
            }

            int index = 0;
            foreach (var metode in conf.methods)
            {
                index++;
                Console.WriteLine(index + ". " + metode);
            }

            Console.WriteLine();

            string confirm;
            if (conf.lang == "en")
            {
                Console.WriteLine("Please type '" + conf.confirmation.en + "' to confirm the transaction:");
                confirm = Console.ReadLine();
                if (confirm == (string)conf.confirmation.en)
                {
                    Console.WriteLine("The transfer is completed");
                }
                else
                {
                    Console.WriteLine("Transfer is cancelled");
                }
            }
            else if (conf.lang == "id")
            {
                Console.WriteLine("Tolong ketik '" + conf.confirmation.id + "' untuk mengkonfirmasi transaksi:");
                confirm = Console.ReadLine();
                if (confirm == (string)conf.confirmation.id)
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }


        }
    }
}