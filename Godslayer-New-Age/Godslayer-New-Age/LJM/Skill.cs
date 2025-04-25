using Godslayer_New_Age.LJM;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;


[Serializable]
public class Skill
{
    public string SkillName { get; set; }
    public float Cost { get; set; }
    public float Probability { get; set; }
    public List<Effect> Effects { get; set; } = new List<Effect>();
    public List<Buff> Buffs { get; set; } = new List<Buff>();

    public Skill(string name, float cost, float probability, List<Effect> effects = null, List<Buff> buffs = null)
    {
        SkillName = name;
        Cost = cost;
        Probability = probability;
        Effects = effects;
        Buffs = buffs;
    }


    //    ================================ 스킬 만드는 곳! ================================ //
    //    ================================ 여기는 예시로 만든 것들 ================================
    public static Skill justHit = new Skill("때리기", 0, 100, 
        new List<Effect> 
        {
            new Effect(EffectType.Damage, 30)
        });

    public static Skill heavyStrike = new Skill("헤비 스트라이크", 0, 100, 
        new List<Effect> 
        {
            new Effect(EffectType.DamageWithAtkScale, 2.0f)
        });  // 공격력 x 2의 대미지 주기


    public static Skill Poison = new Skill("맹독", 10, 100, null,
        new List<Buff>
        {
            new Buff("독", BuffType.DamageOnTurn,
            new Effect(EffectType.DrainHP, 10), 3)
            //    3턴 동안 10의 방어무시 대미지 가하기
        });

    public static Skill RateUp = new Skill("떡상!", 0, 100, null,
        new List<Buff>
        {
            new Buff("확률 증가", BuffType.StatUp,
            new Effect(EffectType.DrainHP, 10), 3)
            //    3턴 동안 10의 방어무시 대미지 가하기
        });







    //     ================================ 여기서부턴 노션에 올라왔던 내용들 ================================
    //    쌀숭이==================
    public static Skill HuntingInPlace = new Skill("재자리 사냥", 0, 100,
        new List<Effect>
        {
            //    사용 시 대상과 시전자를 입력해야 함(공격력 비례 대미지)
            new Effect(EffectType.DamageWithAtkScale, 1f)
        });

    public static Skill PostInInven = new Skill("인벤에 글쓰기", 10, 100,
        new List<Effect>
        {
            //    사용 시 대상과 시전자를 입력해야 함(공격력 비례 대미지)
            new Effect(EffectType.DamageWithAtkScale, 1.2f)
        });

    public static Skill WWE = new Skill("WWE", 20, 100,
       new List<Effect>
       {
            //    사용 시 대상과 시전자를 입력해야 함(공격력 비례 대미지)
            new Effect(EffectType.DamageWithAtkScale, 0.8f)
           //    그럼 타겟도 List로 받아와야 하나?
           //    일단 이건 단일 타겟
       });

    /*
    public static Skill Origin = new Skill("오리진", 20, 100,
       new List<Effect>
       {
            //    사용 시 대상과 시전자를 입력해야 함(공격력 비례 대미지)
            new Effect(EffectType.DamageWithAtkScale, 3f),
       },
       new List<Buff>
       {
           new Buff("스턴", BuffType.Stun, )
       });
    */
    //    스턴은 따로 되돌리는 로직을 짜야할 듯 싶다..






    //    CEO==================
    public static Skill AllInStock = new Skill("풀매수", 10, 30,
        new List<Effect>
        {
            
            new Effect(EffectType.DamageWithAtkScale, 1.2f)
            //    흠... 확률에 실패한다면 ~가 나오기가 여기서 구현하기는 힘들구나
            //    전투쪽이라면 할 수 있으려나?....
        });

    public static Skill StrongHand = new Skill("존버", 10, 50,
       new List<Effect>
       {
            //   사용자의 공격력에 기반해 증가(시전자 필요)
            new Effect(EffectType.BuffAtk, 1.2f)
           //    이것도 50%로 실패하면의 상태를 만들어야 함
           //    만약 전투쪽에서 구현이 가능하다면 다른 스킬 생성하기
           //    어떻게 보면 여기에서 확률 자체를 계산 안해도 될 것 같은데...?
       });

    public static Skill PanicSell = new Skill("패닉셀", 0, 100,
      new List<Effect>
      {
            //   평범히 공격하기
            new Effect(EffectType.DamageWithAtkScale, 1f)
            //    체력 감소시키는건 따로 만들기
      });
    public static Skill Panic = new Skill("지금 팔아야해!!...", 0, 100,
        new List<Effect>
        {
            //    패닉셀용 플레이어 체력 깎기
            new Effect(EffectType.DrainHP, 5)
        });
    public static Skill CEONomalAtk = new Skill("영웅호걸의 시간이다!!", 0, 40,
      new List<Effect>
      {
            
            new Effect(EffectType.DamageWithAtkScale, 1f),
      });






    //    프로게이머==================
    public static Skill Click = new Skill("딸깍", 0, 100,
      new List<Effect>
      {
            //    사용 시 대상과 시전자를 입력해야 함(공격력 비례 대미지)
            new Effect(EffectType.DamageWithAtkScale, 1.1f),
      });

    public static Skill ChatMute = new Skill("채팅 금지", 10, 100,
     new List<Effect>
     {
            //    사용 시 대상과 시전자를 입력해야 함(공격력 비례 대미지)
            new Effect(EffectType.DamageWithAtkScale, 0.8f),
     });

    public static Skill POTG = new Skill("MVP각 ㅇㅈ?", 20, 100,
     new List<Effect>
     {
            //    사용 시 대상과 시전자를 입력해야 함(공격력 비례 대미지)
            new Effect(EffectType.DamageWithAtkScale, 1f)
     },
     new List<Buff>
     {
         new Buff("치명타 확률 증가", BuffType.StatUp, 
             new Effect(EffectType.IncreasedDodge, 30), 2)
         //    3턴 동안 치명타 확률 10 증가
     });

    public static Skill Multikill = new Skill("멀티킬", 50, 100,
     new List<Effect>
     {
            //    사용 시 대상과 시전자를 입력해야 함(공격력 비례 대미지)
            new Effect(EffectType.DamageWithAtkScale, 4f)
     },
     new List<Buff>
     {
         new Buff("치명타 확률 증가", BuffType.StatUp,
             new Effect(EffectType.IncreasedCrit, 10), 3)
         //    3턴 동안 치명타 확률 10 증가
     });






    //     몬스터들의 스킬
    //    슬라임
    public static Skill jumpAtk = new Skill("띄어오르기", 0, 100,
        new List<Effect>
        {
            new Effect(EffectType.DamageWithAtkScale, 1f)
        });



    //    주황버섯
    public static Skill Headbut = new Skill("박치기", 0, 100,
        new List<Effect>
        {
            new Effect(EffectType.DamageWithAtkScale, 1f)
        });



    //    강웡키
    public static Skill LuckHack = new Skill("확률 조작", 0, 100,
        new List<Effect>
        {
            new Effect(EffectType.DamageWithAtkScale, 1f)
        });

    public static Skill Mukbang = new Skill("먹방찍기", 0, 100,
        new List<Effect>
        {
            new Effect(EffectType.Heal, 1f)
        });

    //    신창섭
    public static Skill Normalize = new Skill("정상화", 0, 100,
        new List<Effect>
        {
            new Effect(EffectType.CutHP, 0.5f)
            //    체력 반타작 내기
        });

    public static Skill ChangFu = new Skill("기가창섭의 무술", 0, 100,
       new List<Effect>
       {
            new Effect(EffectType.DamageWithAtkScale, 1f)
       });
    public static Skill EradicateRiceMonkey = new Skill("쌀숭이 척결", 0, 100,
       new List<Effect>
       {
            new Effect(EffectType.DamageWithAtkScale, 1f)
       });

    ///////////////////////////////////////////////////////////////////////////



    //    justHit.Use(target);
    public void Use(Unit target, Unit user = null)
    {
        if (RandomManager.Instance.Next(0, 100) > Probability)
        {
            Console.WriteLine($"{SkillName}은(는) 발동하지 않았다!");
            return;
        }

        Console.WriteLine($"{SkillName} 발동!");


        if(Effects != null)
        {
            foreach (var effect in Effects)
            {
                effect.Apply(target, user);
            }

        }

        //    해당 스킬에 버프가 없을수 도 있으니
        if (Buffs != null)
        {
            //    해당 스킬에 할당되어있던 모든 버프 적용
            foreach (var buff in Buffs)
            {
                target.Buffs.Add(new Buff(buff._Name, buff._Type, buff._Effect, buff._RemainingTurn));
            }
        }
    }
}