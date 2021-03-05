/**********************************************************************
   Project           : MadLibs
   File name         : Program.cs
   Author            : Rilegis
   Date created      : 17/6/2019
   Purpose           : Main entry point for the program.
                       Program.Main runs an infinite loop that runs MadLibs.Run
                       and then asks you if you would like to run it again.

   Revision History  :
   Date        Author      Ref     Revision 
   22/12/2019  Rilegis     1       Changed file header.
**********************************************************************/

using System;

namespace MadLibs
{
    public class Program
    {
        private static string _reply;

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                MadLibs.Run();

                Console.Write("\n\nWould you like to run MadLibs again? [Y/N]: ");
                _reply = Console.ReadLine();
                if (_reply.ToUpper() == "Y") continue;
                else if (_reply.ToUpper() == "N") break;
                else break;
            }
        }
    }
}
