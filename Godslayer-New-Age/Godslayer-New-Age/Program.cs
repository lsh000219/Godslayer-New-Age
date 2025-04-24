using Godslayer_New_Age.Kiahn;
using Godslayer_New_Age.LJM;
using Managers;
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
            BGM_Player.Instance().Play_Stock_Musk_Loop();
            Console.ReadLine();
            BGM_Player.Instance().Music_Exit();
            */



            // UI test
            /*
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(CONSOLE_WIDTH, CONSOLE_HEIGTH);
            Console.SetBufferSize(CONSOLE_WIDTH, CONSOLE_HEIGTH);
            Player.Instance.PlayerJob = Player.Job.CEO;
            Shop.SetItemList();
            Shop.Buy(1);
            Shop.Buy(2);
            Shop.Display();
            PrintUtil.CreateBox();
            Console.ReadLine();
            */


            // UI test2
            /*
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(Constants.CONSOLE_WIDTH, Constants.CONSOLE_HEIGTH);
            Console.SetBufferSize(Constants.CONSOLE_WIDTH, Constants.CONSOLE_HEIGTH);

            SceneManager.Run();
            */





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

 

