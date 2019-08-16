using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UxStudyAnswer
{
    class Program
    {
        // Do not modify this method.
        static void Main(string[] args)
        {
            // Task 1
            Account johnAccount = GetAccount();
            Console.WriteLine(SerializeToCompliantJson(johnAccount));
            // {"Email":"john@example.com","CreatedDate":"08/16/2019","ID":"20d8b3b11ffe47c7bc3c26769b8eccd9"}

            // Task 2
            string compliantJson = GetCompliantAccountJson();
            Account jetAccount = DeserializeFromCompliantJson(compliantJson);
            Console.WriteLine(jetAccount?.Email);
            // jet@example.com
            Console.WriteLine(jetAccount?.CreatedDate);
            // 8/18/2019 12:00:00 AM
            Console.WriteLine(jetAccount?.ID);
            // d1ca7cd0-d69c-4b5c-bade-17d00b74d8e5

            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }

        // The Example Company uses the following formats in their Account models:
        // CreatedDate (DateTime): dd/MM/yy
        // ID (Guid): nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn (the "N" standard format specifier)
        // TODO: 1) Serialize the "account" object to a company-compliant JSON string and return it.
        private static string SerializeToCompliantJson(Account account)
        {
            // 1a) Observe that default serialization formats differently.

            // 1b) Find the serializer option to add converters.

            // 1c) Write and add converters to serializer options, then serialize with options.
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ExampleDateTimeConverter());
            options.Converters.Add(new ExampleGuidConverter());

            string jsonString = JsonSerializer.Serialize(account, options);
            return jsonString;
        }

        // The Example Company uses the following formats in their Account models:
        // CreatedDate (DateTime): dd/MM/yy
        // ID (Guid): nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn (the "N" standard format specifier)
        // TODO: 2) Deserialize the compliant json string as an "account" object and return it.
        private static Account DeserializeFromCompliantJson(string json)
        {
            // 2a) Observe the exception thrown when trying to deserialize formats that are not natively supported by the serializer.

            // 2b) Find the serializer option to add converters.

            // 2c) Write and add converters to serializer options, then deserialize with options.
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ExampleDateTimeConverter());
            options.Converters.Add(new ExampleGuidConverter());

            Account account = JsonSerializer.Deserialize<Account>(json, options);
            return account;
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

    // Alternate solution is to create a single custom converter for the Account object.

    public class ExampleDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("MM/dd/yyyy"));
        }
    }

    public class ExampleGuidConverter : JsonConverter<Guid>
    {
        public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(Guid));

            // Alternately, we can use UTF-8 bases Utf8Parser.
            return new Guid(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("N"));
        }
    }
}
