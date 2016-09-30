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
            
            
            Console.WriteLine("Vad vill du göra med din skivsamling?");
            Console.WriteLine("1. Lägg till en skiva 2. Ändra i din samling  3. EXIT ");
            int input = int.Parse(Console.ReadLine());
            switch(input)
                {
                case 1:
                    AddRecordUI();
                    break;
                case 2:
                    EditCollectionUI();
                    break;
                case 3:
                    //Console.ReadKey();
                    break;
                default:
                    break;
            }
            

        }   

        private static void AddRecordUI()
        {
            Console.Clear();
            Console.WriteLine("Ange artist");
            string inputArtist = (Program.CheckForForbiddenChar(Console.ReadLine()));
            Console.Clear();
            Console.WriteLine("Ange album");
            string inputAlbum = (Program.CheckForForbiddenChar(Console.ReadLine()));
            Console.Clear();
            Console.WriteLine("Ange år");
            string inputYear = (Program.CheckForForbiddenChar(Console.ReadLine()));
            Program.AddRecord(inputArtist.ToUpper(), inputAlbum.ToLower(), inputYear);
            Console.WriteLine(Program.artist[Program.artist.Length - 1] + " är nu tillagd. Vill du lägga till ytterligare skiva");
            Console.ReadKey();

            Program.AddRecord(inputArtist, inputAlbum, inputYear);
            
        }

        private static void EditCollectionUI()
        {
            Console.Clear();
            Program.ListCollection();
            Console.WriteLine("Vilken rad vill du ändra?");
        }
    }

}
