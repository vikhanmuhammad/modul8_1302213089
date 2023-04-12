using modul8_1302213089;
internal class Program
{
    private static void Main(string[] args)
    {
        BankTransferConfig config = new BankTransferConfig();

        if (config.config.lang.Equals("en"))
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        } else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer");
        }

        string transfer = Console.ReadLine();
        int jumlahTransfer = (int)Convert.ToInt32(transfer);

        int biayaTransfer = 0;
        if(jumlahTransfer <= config.config.transfer.threshold)
        {
            biayaTransfer = config.config.transfer.low_fee;
        } else if (jumlahTransfer > config.config.transfer.threshold)
        {
            biayaTransfer = config.config.transfer.high_fee;
        }

        if (config.config.lang.Equals("en"))
        {
            Console.WriteLine("Transfer fee = " + biayaTransfer + "\nTotal amount = " + (jumlahTransfer + biayaTransfer));
        }
        else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Biaya Transfer = " + biayaTransfer + "\nTotal biaya = " + (jumlahTransfer + biayaTransfer));
        }

        if (config.config.lang.Equals("en"))
        {
            Console.WriteLine("Select transfer method : ");
        }
        else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Pilih metode transfer : ");
        }

        for(int i = 0; i < config.config.methods.Count; i++)
        {
            Console.WriteLine((i+1)+". " + config.config.methods[i]);
        }

        Console.WriteLine("Pilih = ");
        string metode = Console.ReadLine();
        int metodeTransfer = (int)Convert.ToInt32(transfer);

        if(config.config.lang.Equals("en"))
        {
            Console.WriteLine("Please type "+config.config.confirmation.en+" to confirm the transaction:");
        }
        else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Ketik " + config.config.confirmation.id + " untuk mengkonfirmasi transaksi:");
        }

        string inputKonfirmasi = Console.ReadLine();

        if (config.config.lang.Equals("en"))
        {
            if (inputKonfirmasi.Equals(config.config.confirmation.en))
            {
                Console.WriteLine("The transfer is completed");
            } else
            {
                Console.WriteLine("Transfer is cancelled");
            }
        }
        else if (config.config.lang.Equals("id"))
        {
            if (inputKonfirmasi.Equals(config.config.confirmation.id))
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