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
        

        static void Main(string[] args)
        {
            Database.InititateCollection(); //Läser in Arrayer från fil
            UserInterface.MainScreen();        //startar interface
           
        }

        public static void ProgramEnding() //Avslutar program
        {
            Environment.Exit(0);
        }
    }
}
