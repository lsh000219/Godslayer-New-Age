using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.Kiahn
{
    //아이템 타입 열거형
    enum eItemType
    {
        Weapon, //0 : 무기
        Armor,  //1 : 방어구
        accessory //2 : 장신구
    }

    //아이템 데이터 클래스
    internal class ItemData
    {
        public Dictionary<eItemType, string> itemType = new Dictionary<eItemType, string>()
        {
            { eItemType.Weapon, "무기" },
            { eItemType.Armor, "방어구" },
            { eItemType.accessory, "장신구" }
        };

        private static string name;

        //아이템 이름은 3~8자 사이로 설정
        public string Name { get; set; }

        //아이템 타입
        private eItemType Type { get; set; }

        //아이템 타입 -> 문자열 변환
        public string TypeName
        {
            get
            {
                return itemType[Type];  //itemType[eItemType.Weapon] == "무기"
            }
            set
            {
                itemType[Type] = value;
            }
        }

        private int atk;
        //공격력은 0 이상으로 설정
        public int Atk
        {
            get { return atk; }
            set
            {
                if (value < 0)
                {
                    this.atk = 0;
                }
                else
                {
                    this.atk = value;
                }
            }
        }

        private int def;
        //방어력은 0 이상으로 설정
        public int Def
        {
            get { return def; }
            set
            {
                if (value < 0)
                {
                    this.def = 0;
                }
                else
                {
                    this.def = value;
                }
            }
        }

        //아이템 설명
        public string Desc { get; set; }

        public string PassiveDesc { get; set; }


        private int price;
        //가격은 0 이상으로 설정
        public int Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    this.price = 0;
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public ItemData(string _name, eItemType _type, int _atk, int _def, string _desc, string _passiveDesc, int _price)
        {
            Name = _name;
            Type = _type;
            Atk = _atk;
            Def = _def;
            Desc = _desc;
            PassiveDesc = _passiveDesc;
            Price = _price;

        }
    }
}