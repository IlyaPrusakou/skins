using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class ColorSkin: Skin //A.L2.Player1/1
    {
        ConsoleColor CnsClr { get; set; } //A.L2.Player1/1
        public ColorSkin() : this (0) //A.L2.Player1/1
        {
            CnsClr = ConsoleColor.Magenta; //A.L2.Player1/1
        }
        public ColorSkin(ConsoleColor clr) : base() //A.L2.Player1/1
        {
            CnsClr = clr; //A.L2.Player1/1
        }
        public override void Clear() //A.L2.Player1/1
        {
            Console.Clear(); //A.L2.Player1/1
            Console.WriteLine("All has been cleared"); //A.L2.Player1/1
        }

        public override void Render(string str) //A.L2.Player1/1
        {
            string s = str; //A.L2.Player1/1
            Console.BackgroundColor = CnsClr; //A.L2.Player1/1
            Console.ForegroundColor = ConsoleColor.DarkRed; //A.L2.Player1/1
            Console.WriteLine(s); //A.L2.Player1/1
        }
    }
}
