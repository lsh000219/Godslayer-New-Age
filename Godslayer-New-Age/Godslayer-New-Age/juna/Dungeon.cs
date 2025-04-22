using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.juna
{
    class Dungeon
    {
        public int dungeontype { get; set; }
        private bool[] dungeonclear = { false,false, false, false,false };
        Battle battle = new Battle();
        public int CheckInput(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input >= min && input <= max)
                    {
                        return input;
                    }
                }
                Console.WriteLine("�߸��� �Է��Դϴ�");
            }
        }
        public void SelectDungeon(int min,int max)
        {
            Console.WriteLine("������� ��Ҹ� ������ �ּ���");
            Console.WriteLine("1. ��ǳ���� �Ǿ�� ��   2. �������� ���ּ��� ������������ϴ� ��  3. ����  0. ������");
            dungeontype = CheckInput(0, 4);
            switch (dungeontype)
            {
                case 1:
                    Maple();
                    break;
                case 2:
                    Coin();
                    break;
                case 3:
                    Lol();
                    break;
                case 4:
                    Console.WriteLine("�߸��� �Է��Դϴ�");
                    break;
                case 0:
                    break;
            }
        }
        
        public void Maple()
        {
            Console.WriteLine("������ ������ ��� ���� �Ǳ�� ������ ��â��");
            Console.WriteLine("������ 10������ ô���ϰ� ���� �� �״� �̹����� �Ҽ��̵� ����ȭ��Ű���� �Ѵ�");
            Console.WriteLine("��Ű� �� �ȳ��� ������� ���踦 ���� �׸� �׿��߸� �Ѵ�... ");
            Dungeon_Select();
        }

        public void Coin()
        {
            Console.WriteLine("ȭ���� ���ο� ���� ���� ������ ���� ���̵� �� �Ϸ� �ӽ�ũ");
            Console.WriteLine("�������� �ֽ��� ���ִ� ���̵��� ������ �Ϸ� ������ ���� ���� ���� �׸� �׿��߸� �Ѵ�");
            Dungeon_Select();
        }
        public void Lol()
        {
            Console.WriteLine("���׿��� ������ ���ӿ��� �����Ĺ��� ������ ����� '���� ��'�̶�� Ī�۹޴� �� ����Ŀ");
            Console.WriteLine("���� ���� �Ѿ� E-sports�� ���� �Ǿ� ����� Ŀ��� �����Ѵ�");
            Console.WriteLine("����� ���� Ŀ��� ������ �������� �׸� �׿����Ѵ�");
            Dungeon_Select();
        }
        public void Dungeon_Select()
        {
            while (true)
            {
                Console.WriteLine("���Ͻô� �ൿ�� ������ �ּ���");
                Console.WriteLine("1. ������ ���ư���   0. ������ ���ư���");
                int playerselect = CheckInput(0, 1);
                switch (playerselect)
                {
                    case 1:
                        showEnemy();
                        break;
                    case 0:
                        break;
                }
            }
        }
        public void showEnemy()
        {

        }
    }
}