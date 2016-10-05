using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skivsamling
{
    class Database
    {
        private static bool isForbiddenChar;
        private static string[] recordCollection;
        private static string newCollection;

        public static bool IsForbiddenChar //förbjuden char pga split med % char
        {
            get {return isForbiddenChar; }
            set { isForbiddenChar = value; }
        }

        public static void InititateCollection() //läser in rader från textfil och skapar tre arrayer
        {
            recordCollection = File.ReadAllLines(@"skivsamling.txt");
            Album.Artist = new string[recordCollection.Length];
            Album.AlbumName = new string[recordCollection.Length];
            Album.Year = new string[recordCollection.Length];
            string[] splitString;
            for (int i = 0; i < recordCollection.Length; i++)
            {
                splitString = recordCollection[i].Split('%');
                Album.Artist[i] = splitString[0];
                Album.AlbumName[i] = splitString[1];
                Album.Year[i] = splitString[2];
            }
        }

        
     public static void SynchronizeTempWithCollection(string[] tempArtist, string[] tempAlbum, string[] tempYear) //syncar temp med huvudarrayer
        {
            Album.Artist = new string[tempArtist.Length];
            Album.AlbumName = new string[tempAlbum.Length];
            Album.Year = new string[tempYear.Length];

            for (int i = 0; i < Album.Artist.Length; i++)
            {
                Album.Artist[i] = tempArtist[i];
                Album.AlbumName[i] = tempAlbum[i];
                Album.Year[i] = tempYear[i];
            }
        } 

        public static void SaveToDisc()
        {
            newCollection = string.Empty;
            for (int i = 0; i < Album.Artist.Length; i++)
            {
               newCollection += Album.Artist[i] + "%" + Album.AlbumName[i] + "%" + Album.Year[i] + Environment.NewLine;
            }

            File.WriteAllText(@"skivsamling.txt", newCollection);
            UserInterface.MainScreen();
        } //sparar till textfil

        public static string CheckForForbiddenChar(string input)
        {
            if (input == "q" || input == "Q")
            {
                UserInterface.MainScreen();
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '%')
                {
                   Console.WriteLine(input[i]+ " = Felaktigt tecken");
                    isForbiddenChar = true;
                }
                else
                { isForbiddenChar = false; }
            }
            return input;
            
        } //Kontrollerar input
    }
}
