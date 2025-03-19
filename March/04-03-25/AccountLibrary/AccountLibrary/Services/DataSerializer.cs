using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AccountLibrary.Model;

namespace AccountLibrary.Services
{
    public class DataSerializer
    {
        public void Serializer(List<BankDetails> bankSerialize)
        {
            string fileName = "Bank.json";
            string jsonString = JsonSerializer.Serialize(bankSerialize);
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine("Serializer Completed");
        }
        public List<BankDetails> DeSerializer()
        {
            string fileName = "Bank.json";
            List<BankDetails> bankDeSerialize = new List<BankDetails>();
            string jsonString;
            if (File.Exists(fileName))
            {
                jsonString = File.ReadAllText(fileName);
                bankDeSerialize = JsonSerializer.Deserialize<List<BankDetails>>(jsonString);
            }
            
            return bankDeSerialize;

        }
    }
}
