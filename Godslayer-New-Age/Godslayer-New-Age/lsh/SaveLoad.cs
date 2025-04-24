using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Godslayer_New_Age.Kiahn;
using Godslayer_New_Age.LJM;



/*
 
Console.Write("세이브 파일 고르기 : ");        //세이브 파일 고르기(예시)
select = int.Parse(Console.ReadLine());
if(select == 1) { saveName1 = "player1.dat"; saveName2 = "shop1.dat"; }
else if(select == 2) { saveName1 = "player2.dat"; saveName2 = "shop2.dat"; }
else if(select == 3) { saveName1 = "player3.dat"; saveName2 = "shop3.dat"; }


Character player = SaveLoad.Instance().LoadPlayer(saveName1);  //로드
Shop shop = SaveLoad.Instance().LoadShop(saveName2);
 
SaveLoad.Instance().SavePlayer(player, saveName1);      //세이브

 */


namespace Godslayer_New_Age.lsh
{
    internal class SaveLoad
    {
        private static SaveLoad SaveManager;
        public static SaveLoad Instance()
        {
            if (SaveManager == null)
            {
                SaveManager = new SaveLoad();
            }
            return SaveManager;
        }

        public static void SavePlayer(Player player, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, player);
            }
        }

        public static Player LoadPlayer(string fileName)
        {
            if (!File.Exists(fileName)) return Player.Instance;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Player)formatter.Deserialize(fs);
            }
        }

        public static void SaveShop(Shop shop, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, shop);
            }
        }

        public static Shop LoadShop(string fileName)
        {
            if (!File.Exists(fileName)) return new Shop();

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Shop)formatter.Deserialize(fs);
            }
        }
    }
}

