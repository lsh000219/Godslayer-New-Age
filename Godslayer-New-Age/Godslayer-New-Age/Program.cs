using Godslayer_New_Age.LJM;
using Managers;
using Scenes;
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
            //bgm_player bgm_Player = new bgm_player();
            //bgm_Player.Battle_Musk();

            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(Constants.CONSOLE_WIDTH, Constants.CONSOLE_HEIGTH);
            Console.SetBufferSize(Constants.CONSOLE_WIDTH, Constants.CONSOLE_HEIGTH);

            SceneManager.Run();
        }
    }
}
