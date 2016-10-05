using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skivsamling
{
    class UserInterface
    {

        public static void MainScreen()
        {
                string input = string.Empty;
                Console.Clear();
                ListCollection();
                Console.WriteLine("Vad vill du göra med din skivsamling?");
                Console.WriteLine("1. Lägg till en skiva 2. Ändra i din samling  3. EXIT ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        bool ifEditAlbum = false;
                        AddRecordUI(ifEditAlbum);
                        break;
                    case "2":
                        EditCollectionUI();
                        break;
                    case "3":
                     Program.ProgramEnding();
                    break ;
                    default:
                        break;
                }
       
            

        }

        private static void AddRecordUI(bool ifEditAlbum) //tar med en bool som styr ifall det ska läggas
        {                                                  // till ny artist eller ändra befintlig
        string inputArtist;
        string inputAlbum;
        string inputYear;
            do
            {
                Console.WriteLine("Ange artist: \t | Q/q: Tillbaka"); //Loopar ifall man använder förbjudet tecken = %
                inputArtist = (Database.CheckForForbiddenChar(Console.ReadLine()));
            } while (Database.IsForbiddenChar == true);
            do
            {
                Console.WriteLine("Ange album");
                inputAlbum = (Database.CheckForForbiddenChar(Console.ReadLine()));
            } while (Database.IsForbiddenChar == true);
            do
            {
                Console.WriteLine("Ange år");
                inputYear = (Database.CheckForForbiddenChar(Console.ReadLine()));
            } while (Database.IsForbiddenChar == true);

            if(!ifEditAlbum)  //Om artisten läggs in helt på nyt så skickas det hit
             Album.AddRecord(inputArtist.ToUpper(), inputAlbum.ToLower(), inputYear);

            if (ifEditAlbum) //Ändrar man befintlig artist så skickas det hit
            Album.EditCollection(inputArtist.ToUpper(), inputAlbum.ToLower(), inputYear);



        }

        private static void EditCollectionUI() //Metod för att välja rad att ändra i samling
        {
            
            int result;
            bool isParseOk;
            do                               //Diverse felhantering på input. 
            {
                Console.Clear();
                UserInterface.ListCollection();
                Console.WriteLine("Vilken rad vill du ändra? | Q/q: Tillbaka");
                string inputRowSelection = Console.ReadLine();
                isParseOk = int.TryParse(inputRowSelection, out result); //Kontrollerar så input är en siffra

                int.TryParse(inputRowSelection, out result);
                if (inputRowSelection == "q")                           //Input Q ger bakåt i meny
                {
                    
                    MainScreen();
                }

            } while (result > Album.Artist.Length - 1 || isParseOk == false); //Kontrollerar så att val inte överstiger längd på array

            EditAlbumUI(result);
        }

        private static void EditAlbumUI(int result) //Metod för att välja åtgärd på markerat album, tar med val från ovan metod.
        {
            Console.Clear();
            Console.WriteLine("Vald skiva:\n" + Album.Artist[result] + " " + Album.AlbumName[result] + " " + Album.Year[result]);
            Console.WriteLine("\n1: Ändra rad 2: Radera rad Q/q: Tillbaka");
            string input = Console.ReadLine().ToUpper();
            switch (input)                      //Välj ändra album, radera album eller gå tillbaka.
            {
                case "1":
                    bool isEditAlbum = true;
                    Album.InputRowSelection = result;
                    AddRecordUI(isEditAlbum);
                    break;
                case "2":
                    Album.DeleteAlbum(result);
                    break;
                case "Q":
                    EditCollectionUI();
                    break;
            }
        }
    

        public static void ListCollection() //Metod för at lista alla tre Arrayer
        {
            for (int i = 0; i < Album.Artist.Length; i++)
            {
                Console.WriteLine(String.Format(i + "\t{0,-25} {1,-30} {2}", Album.Artist[i], Album.AlbumName[i], Album.Year[i]));
            }
            Console.WriteLine("\n\n\n");
        }
    }
}
