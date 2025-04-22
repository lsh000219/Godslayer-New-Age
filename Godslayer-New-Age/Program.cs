using Godslayer_New_Age.LJM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bgm_player bgm_Player = new bgm_player();
            bgm_Player.Music_Start("Battle_Musk1.wav", false);
            bgm_Player.Music_Start("Battle_Musk2.wav", true);
            bgm_Player.WaitForExit("Battle_Musk2.wav 루프 재생 중입니다.");
        }
    }
}
