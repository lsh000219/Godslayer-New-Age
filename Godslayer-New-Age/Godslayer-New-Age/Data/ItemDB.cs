using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class ItemDB
{
    public static Item[] riceMonkeyItems = new Item[]
    {
            new Item("고성능확성기", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 10 }}, "쌀을 팔 때 사용하는 고성능 확성기", "", 1000),
            new Item("포도무기", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 30 }}, "포도색 무기", "", 2500),
            new Item("피케인", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 50 }}, "피씨방에 가서 200시간 메이플을 했다는 증거", "", 4500),

            new Item("드랍된 갑옷", ItemType.Armor, new Dictionary<StatType, float>{{ StatType.DEF, 10 }}, "언젠가 어떤 몬스터가 드랍했던 갑옷이다", "", 1500),
            new Item("포도갑옷", ItemType.Armor, new Dictionary<StatType, float>{{ StatType.DEF, 30 }}, "포도색 갑옷", "", 3000),
            new Item("흙케인", ItemType.Armor, new Dictionary<StatType, float>{{ StatType.DEF, 50 }}, "싼 값으로 만든 가성비 갑옷", "", 6000),

            new Item("드랍된 장신구", ItemType.Accessory, new Dictionary<StatType, float>{{ StatType.ATK, 5 }, { StatType.DEF, 3 }}, "언젠가 어떤 몬스터가 드랍했던 장신구다", "", 1500),
            new Item("포도장신구", ItemType.Accessory, new Dictionary<StatType, float>{{ StatType.ATK, 10 }, { StatType.DEF, 5 }}, "포도색 장신구", "", 2500),
            new Item("솜크빈", ItemType.Accessory, new Dictionary<StatType, float>{}, "신창섭의 대표 사료", "(골드 추가보상 100%)", 5000),
            new Item("자석펫", ItemType.Accessory, new Dictionary<StatType, float>{{ StatType.ATK, 40 }}, "프펫공을 전부 5를 띄운 전설의 자석펫", "(골드 추가보상 100%)", 6000),
    };

    public static Item[] jugallerItems = new Item[]
    {
            new Item("푸른색 막대기", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 20 }}, "계속 떨어지는 당신의 주식 차트 색깔", "", 1500),
            new Item("빨간색 막대기", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 35 }}, "이런 일은 일어나지 않아요", "", 2500),
            new Item("코모도어 컴퓨터", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 65 }}, "일론이 어렸을 적, 이 컴퓨터로 개발을 시작했다", "", 5500),

            new Item("공대생 바지", ItemType.Armor, new Dictionary<StatType, float>{{ StatType.DEF, 10 }}, "아무도 나랑 안 놀아줄 것 같은 바지", "", 1500),
            new Item("일론의 정장", ItemType.Armor, new Dictionary<StatType, float>{{ StatType.DEF, 25 }}, "일론의 성공이 묻은 정장", "", 3000),
            new Item("최첨단 우주복", ItemType.Armor, new Dictionary<StatType, float>{{ StatType.DEF, 50 }}, "입고 화상갈끄니까앗", "", 6000),

            new Item("빛바랜 도지코인", ItemType.Accessory, new Dictionary<StatType, float>{{ StatType.ATK, 5 }, { StatType.DEF, 3 }}, "결국, 곤두박질친 도지코인", "", 1500),
            new Item("스페이스X의 잔해", ItemType.Accessory, new Dictionary<StatType, float>{{ StatType.ATK, 10 }, { StatType.DEF, 5 }}, "실패한 발사체의 잔해다", "", 2500),
            new Item("테슬라 기어봉", ItemType.Accessory, new Dictionary<StatType, float>{}, "맨들맨들한 기어봉", "(골드 추가보상 100%)", 5000),
            new Item("화성인 가면", ItemType.Accessory, new Dictionary<StatType, float>{{ StatType.ATK, 40 }}, "이거 쓰고 화성갈꺼니까앗", "(골드 추가보상 100%)", 6000),
    };

    public static Item[] proGamerItems = new Item[]
    {
            new Item("게이밍 마우스", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 20 }}, "어디선가 주워온 싸구려 마우스", "", 1500),
            new Item("RGB 키보드", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 35 }}, "컬러풀한 보급형 키보드", "", 2500),
            new Item("1000Hz 모니터", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 65 }}, "신들만이 쓸 수 있다는 전설의 모니터", "", 5500),

            new Item("게이밍 안경", ItemType.Armor, new Dictionary<StatType, float>{{ StatType.DEF, 10 }}, "평범한 게이밍 안경", "", 1500),
            new Item("게이밍 유니폼", ItemType.Armor, new Dictionary<StatType, float>{{ StatType.DEF, 25 }}, "저렴한 게이밍 유니폼", "", 3000),
            new Item("협찬받은 유니폼", ItemType.Armor, new Dictionary<StatType, float>{{ StatType.DEF, 50 }}, "대상혁의 피땀눈물이 묻은 유니폼", "", 6000),

            new Item("다이아 딱지", ItemType.Accessory, new Dictionary<StatType, float>{{ StatType.ATK, 5 }, { StatType.DEF, 3 }}, "다이아몬드가 박힌 딱지다", "", 1500),
            new Item("마스터 딱지", ItemType.Accessory, new Dictionary<StatType, float>{{ StatType.ATK, 10 }, { StatType.DEF, 5 }}, "가지면 마스터를 갈 것만 같지만 너의 착각이다", "", 2500),
            new Item("그랜드 마스터 딱지", ItemType.Accessory, new Dictionary<StatType, float>{}, "아무나 범접할 수 없는 딱지", "(골드 추가보상 100%)", 5000),
            new Item("챌린저 딱지", ItemType.Accessory, new Dictionary<StatType, float>{{ StatType.ATK, 40 }}, "이룰 수 있다는 챌린저", "(골드 추가보상 100%)", 6000),
    };
}