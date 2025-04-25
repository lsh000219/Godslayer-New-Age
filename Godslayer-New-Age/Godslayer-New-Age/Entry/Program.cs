using Godslayer_New_Age.LJM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        //데이터 초기화
        //SaveLoad.Delete("player1.dat");
        //SaveLoad.Delete("player2.dat");
        //SaveLoad.Delete("player3.dat");

        Console.OutputEncoding = Encoding.UTF8;
        Console.SetWindowSize(Constants.CONSOLE_WIDTH, Constants.CONSOLE_HEIGTH);
        Console.SetBufferSize(Constants.CONSOLE_WIDTH, Constants.CONSOLE_HEIGTH);

        SceneManager.Run();
    }
}



