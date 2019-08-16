using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UxStudy
{
    class Program
    {
        // Do not modify this method.
        static void Main(string[] args)
        {
            // Task 1
            Account johnAccount = GetAccount();
            Console.WriteLine(SerializeWithCompanyFormats(johnAccount));

            // Task 2
            string compliantJson = GetCompliantAccountJson();
            Account jetAccount = DeserializeFromCompliantJson(compliantJson);
            Console.WriteLine(jetAccount?.Email);
            Console.WriteLine(jetAccount?.CreatedDate);
            Console.WriteLine(jetAccount?.ID);

            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }

        // The Example Company uses the following formats in their Account models:
        // CreatedDate (DateTime): dd/MM/yy
        // ID (Guid): nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn (the "N" standard format specifier)
        // TODO: 1) Serialize the "account" object to a company-compliant JSON string and return it.
        private static string SerializeWithCompanyFormats(Account account)
        {
            // <Add/modify code here>
            return "";
        }

        // The Example Company uses the following formats in their Account models:
        // CreatedDate (DateTime): dd/MM/yy
        // ID (Guid): nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn (the "N" standard format specifier)
        // TODO: 2) Deserialize the compliant json string as an "account" object and return it.
        private static Account DeserializeFromCompliantJson(string json)
        {
            // <Add/modify code here>
            return null;
        }

        private static Account GetAccount()
        {
            // Note: Do NOT modify the Account object creation.
            Account account = new Account
            {
                Email = "john@example.com",
                CreatedDate = DateTime.Parse("08/16/2019"),
                ID = new Guid("20d8b3b11ffe47c7bc3c26769b8eccd9")
            };

            return account;
        }

        private static string GetCompliantAccountJson()
        {
            // Note: Do NOT modify the Account JSON representation.
            string json = @"{
                ""Email"": ""jet@example.com"",
                ""CreatedDate"": ""08/18/2019"",
                ""ID"": ""d1ca7cd0d69c4b5cbade17d00b74d8e5""
            }";
            return json;
        }
    }

    public class Account
    {
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ID { get; set; }
    }
}
