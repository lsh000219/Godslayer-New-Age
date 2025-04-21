using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using static Utils.Constants;

namespace Godslayer_New_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(CONSOLE_WIDTH, CONSOLE_HEIGTH);
            Console.SetBufferSize(CONSOLE_WIDTH, CONSOLE_HEIGTH);
            PrintUtil.CreateBox();
            Console.ReadLine();
        }
    }
}
