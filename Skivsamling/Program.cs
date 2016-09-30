using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skivsamling
{
    class Program
    {
        private static string[] skivsamling;
        public static string[] artist;
        public static string[] album;
        public static string[] year;
        //private static string[] splitString;
        private static string newCollection;
        static void Main(string[] args)
        {
            InititateCollection();
            ListCollection();
            UserInterface.MainScreen();
            
        }

        public static void InititateCollection()
        {
            skivsamling = File.ReadAllLines(@"skivsamling.txt");
            artist = new string[skivsamling.Length];
            album = new string[skivsamling.Length];
            year = new string[skivsamling.Length];
            string[] splitString;
            for (int i = 0; i < skivsamling.Length; i++)
            {
                splitString = skivsamling[i].Split('%');
                artist[i] = splitString[0];
                album[i] = splitString[1];
                year[i] = splitString[2];
            }

            
        }
        public static void ListCollection()
        {
            
             for (int i = 0; i < artist.Length; i++)
            {
                Console.WriteLine(String.Format(i + "\t{0,-25} {1,-30} {2}", artist[i], album[i], year[i]));
               // Console.Write(artist[i]+  album[i]  + year[i] + "\n");

            }
            Console.WriteLine("\n\n\n");
            Console.ReadKey();
            
            

           
        }
        public static string AddRecord(string inputArtist, string inputAlbum, string inputYear)
        {
            string[] tempArtist = new string[artist.Length + 1];
            string[] tempAlbum = new string[album.Length + 1];
            string[] tempYear = new string[year.Length + 1];
            for (int i = 0; i < artist.Length; i++)
            {
                tempArtist[i] = artist[i];
                tempAlbum[i] = album[i];
                tempYear[i] = year[i];
            }


            tempArtist[tempArtist.Length - 1] = inputArtist;
            tempAlbum[tempAlbum.Length - 1] = inputAlbum ;
            tempYear[tempYear.Length - 1] = inputYear;

            artist = new string[tempArtist.Length];
            album = new string[tempAlbum.Length];
            year = new string[tempYear.Length];

            for (int i = 0; i < artist.Length; i++)
            {
                artist[i] = tempArtist[i];
                album[i] = tempAlbum[i];
                year[i] = tempYear[i];
            }
            SaveToDisc();
            return inputArtist + inputAlbum + inputYear;
            
         

        }
        public static void EditCollection()
        {
            for (int i = 0; i < skivsamling.Length; i++)
            {
                Console.WriteLine(i + skivsamling[i]);
            }
            Console.WriteLine("Vilken rad vill du ändra?");
            int inputRowSelection = int.Parse(Console.ReadLine());

            Console.WriteLine("Mata in ändring");
            string inputChange = Console.ReadLine();
            for (int i = 0; i < skivsamling.Length; i++)
            {
                Console.WriteLine(i + skivsamling[i]);
            }
        }
        public static void SaveToDisc()
        {
            
            for (int i = 0; i < artist.Length; i++)
            {
                newCollection += artist[i] + "%" + album[i] +"%" + year[i] + Environment.NewLine;
            }

            File.WriteAllText(@"skivsamling.txt", newCollection);
           // UserInterface.MainScreen();
        }

        public static string CheckForForbiddenChar(string input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i]=='%')
                {
                    input = "Felaktigt tecken %";
                }
                
            }
            return input;
        }
    }
}
