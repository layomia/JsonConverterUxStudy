using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RampUp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Song song = new Song()
            {
                Title = "Hey Jude",
                Artist = "The Beatles",
                Genre = Genre.PopRock,
            };

            string json = Serialize(song);
            Console.WriteLine(json);
            
            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }

        // TODO 1) Use the StringEnumConverter to serialize the "Song" object to a JSON representation
        // where the Genre property is written as a string.
        private static string Serialize(Song song)
        {
            // <Add/modify code here>
            return "";
        }
    }

    public enum Genre { Classical, Rap, Soul, PopRock };

    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public Genre Genre { get; set; }
    }
}
