using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302213089
{
    public class BankTransferConfig
    {
        public BankConfig config;

        public const string filepath = @"bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteConfigFile();
            }
        }

        public void ReadConfigFile()
        {
            string hasilBaca = File.ReadAllText(filepath);
            config = JsonSerializer.Deserialize<BankConfig>(hasilBaca);
        }

        public void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string tulisan = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filepath, tulisan);
        }

        public void SetDefault()
        {
            config = new BankConfig("en", new Transfer(25000000, 6500, 15000),
                new List<string> { "RTO (real-time", "SKN", "RTGS", "BI FAST"},
                new Confirmation("yes", "ya"));
        }
    }

    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }

        public Confirmation() { }
        public Confirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }

    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }

        public Transfer() { }
        public Transfer(int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    public class BankConfig
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public List<string> methods { get; set; }
        public Confirmation confirmation { get; set; }

        public BankConfig() { }
        public BankConfig(string lang, Transfer transfer, List<string> methods, Confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
    }
}
