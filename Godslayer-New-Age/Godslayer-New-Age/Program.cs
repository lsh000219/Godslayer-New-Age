using Godslayer_New_Age.Kiahn;
using Godslayer_New_Age.LJM;
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

            //bgm test
            /*
            bgm_player bgm_Player = new bgm_player();
            bgm_Player.Music_Start("Battle_Musk1.wav", false);
            bgm_Player.Music_Start("Battle_Musk2.wav", true);
            Console.ReadLine();
            bgm_Player.Music_Exit();
            */


            // UI test
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(CONSOLE_WIDTH, CONSOLE_HEIGTH);
            Console.SetBufferSize(CONSOLE_WIDTH, CONSOLE_HEIGTH);

            PrintUtil.CreateBox();
            Console.ReadLine();




            //    dodge test
            /*
            if (Player.Instance.TryDodge())
            {
                Console.WriteLine("회피에 성공함!");
            }
            else
            {
                Console.WriteLine("회피에 실패!!");
                Console.WriteLine($"{Player.Instance.GetRandomDamage()} 만큼의 데미지를 받음!");
            }
            */




        }
    }
}

 

