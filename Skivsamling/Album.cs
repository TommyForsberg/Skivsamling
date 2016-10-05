using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skivsamling
{

    class Album
    {
        private static string[] artist;  //Lista från fil delas i tre stycken arrayer
        private static string[] album;
        private static string[] year;
        private static int inputRowSelection; //Måste kunna anropas från två metoder, gäller val av rad för editering.


        public static string[] Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        public static string[] AlbumName
        {
            get { return album; }
            set { album = value; }
        }


        public static string[] Year
        {
            get { return year; }
            set { year = value; }
        }

        public static int InputRowSelection
        {
            get { return inputRowSelection; }
            set { inputRowSelection = value; }

        }

        public static void AddRecord(string inputArtist, string inputAlbum, string inputYear) //Lägger till skiva
        {
            string[] tempArtist = new string[artist.Length + 1];  //Skapar ny Array med artist[] som mall + 1 fält.
            string[] tempAlbum = new string[album.Length + 1];
            string[] tempYear = new string[year.Length + 1];

            for (int i = 0; i < artist.Length; i++) //Kopierar information från huvudarrayer 
            {                                       //till temp, lämnar ett fält tomt i slutet.
                tempArtist[i] = artist[i];
                tempAlbum[i] = album[i];
                tempYear[i] = year[i];
            }


            tempArtist[tempArtist.Length - 1] = inputArtist; //Lägger inskickade strängar i sista fältet
            tempAlbum[tempAlbum.Length - 1] = inputAlbum;
            tempYear[tempYear.Length - 1] = inputYear;

            Database.SynchronizeTempWithCollection(tempArtist, tempAlbum, tempYear); //Skickar allt för sync.
            Database.SaveToDisc(); //Skickar för att spara i textfil.
        }

        public static void EditCollection(string inputArtist, string inputAlbum, string inputYear) //Ändrar befintlig rad i samling
        {
            artist[inputRowSelection] = inputArtist; 
            album[inputRowSelection] = inputAlbum;
            year[inputRowSelection] = inputYear;
            Database.SaveToDisc();
        }

        public static void DeleteAlbum(int rowSelection) //raderar album. 
        {
            string[] tempArtist = new string[artist.Length - 1]; //definierar TempArray med -1 fält
            string[] tempAlbum = new string[album.Length - 1];
            string[] tempYear = new string[year.Length - 1];
            
            for(int i = 0; i < rowSelection; i++) //kopierar information från rader "ovanför" 0++ den rad som ska raderas
            {
                tempArtist[i] = artist[i];
                tempAlbum[i] = album[i];
                tempYear[i] = year[i];
            }

            for(int j = rowSelection; j < tempArtist.Length; j++) //kopierar övriga rader under raderad rad "upp" ett steg
            {
                tempArtist[j] = artist[j+1];
                tempAlbum[j] = album[j+1];
                tempYear[j] = year[j+1];
            }

            Database.SynchronizeTempWithCollection(tempArtist, tempAlbum, tempYear); // anropar sync
            Database.SaveToDisc(); //anropar skriv till disk
   
        }

    }
}
