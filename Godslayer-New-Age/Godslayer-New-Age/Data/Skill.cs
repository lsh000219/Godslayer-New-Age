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
    public static Skill AllInStock = new Skill("풀매수", 10, 100,
        new List<Effect>
        {
            
            new Effect(EffectType.DamageWithAtkScale, 1.2f)
            //    흠... 확률에 실패한다면 ~가 나오기가 여기서 구현하기는 힘들구나
            //    전투쪽이라면 할 수 있으려나?....
        });

    public static Skill StrongHand = new Skill("존버", 10, 100,
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

    public static Skill CEONomalAtk0 = new Skill("영웅호걸의 시간이다!!", 0, 100,
      new List<Effect>
      {     
            new Effect(EffectType.DamageWithAtkScale, 1f),
      });
    public static Skill CEONomalAtk1 = new Skill("영웅아~ 호걸아~", 0, 100,
      new List<Effect>
      {
            new Effect(EffectType.DamageWithAtkScale, 0.7f),
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
            //    임시 수치로 적 데이터가 완성된다면 수정
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

    public static Skill EradicateRiceMonkey0 = new Skill("쌀숭이 척결", 0, 100,
       new List<Effect>
       {
           //    만약 쌀숭이가 아니라면
            new Effect(EffectType.DamageWithAtkScale, 0.5f)
       });
    public static Skill EradicateRiceMonkey1 = new Skill("쌀숭이 척결", 0, 100,
       new List<Effect>
       {
           //    만약 쌀숭이라면
            new Effect(EffectType.DamageWithAtkScale, 3f)
       });

    public static Skill ChangPOP = new Skill("창팝", 0, 100,
       new List<Effect>
       {
            new Effect(EffectType.DamageWithAtkScale, 1.4f)
       });



    //    코인충
    public static Skill AllIn0 = new Skill("올인", 0, 100,
      new List<Effect>
      {
           //    올인에 성공했다면
            new Effect(EffectType.DamageWithAtkScale, 1.3f)
      });
    public static Skill AllIn1 = new Skill("응~ 더 떨어져봐~", 0, 100,
      new List<Effect>
      {
           //    올인에 실패했다면
            new Effect(EffectType.DamageWithAtkScale, 0.5f)
      });

    //    이룽마
    public static Skill LOVE = new Skill("I Love you!", 0, 100,
     new List<Effect>
     {
            new Effect(EffectType.DamageWithAtkScale, 1f)
     });

    //    도지
    public static Skill VeryHeal0 = new Skill("매우 회복", 0, 100,
     new List<Effect>
     {
            new Effect(EffectType.Heal, 1f)
            //    임시 수치로 데이터가 완성 된다면 수정
     });
    public static Skill VeryHeal1 = new Skill("매우 회복?", 0, 100,
     new List<Effect>
     {
            new Effect(EffectType.Heal, 1f)
            //    임시 수치로 데이터가 완성 된다면 수정
     });

    public static Skill MuchDamage0 = new Skill("많이 대미지", 0, 100,
     new List<Effect>
     {
            new Effect(EffectType.DamageWithAtkScale, 1.2f)
     });
    public static Skill MuchDamage1 = new Skill("많이 대미지?", 0, 100,
     new List<Effect>
     {
            new Effect(EffectType.DamageWithAtkScale, 0.5f)
     });
    public static Skill Wow = new Skill("우왕", 0, 100);



    //    일론 머스크
    public static Skill SpaceXLaunchFail = new Skill("스페이스X 프로젝트 실패!", 0, 100,
        new List<Effect>
        {
            //    특정 턴 뒤에 발동하게 만들어야 함
            new Effect(EffectType.CutHP, 500)
        });

    public static Skill CybertruckCrash = new Skill("사이버 트럭 충돌", 0, 100,
        new List<Effect>
        {
            new Effect(EffectType.DamageWithAtkScale, 1f)
        });

    public static Skill PumpIt = new Skill("코인 떡상!", 0, 100, null,
        new List<Buff>
        {
            new Buff("공격력 증가", BuffType.StatUp,
             new Effect(EffectType.BuffAtk, 1.5f), 1)
        });
    public static Skill DumpIt = new Skill("코인 떡락!", 0, 100, null,
        new List<Buff>
        {
            new Buff("공격력 감소", BuffType.StatUp,
             new Effect(EffectType.BuffAtk, 0.5f), 1)
        });

    public static Skill Tweeting = new Skill("트윗질", 0, 100, null,
        new List<Buff>
        {
            new Buff("방어력 감소", BuffType.StatUp,
             new Effect(EffectType.BuffDef, 0.8f), 1)
        });


    //   T1팬
    //    농담으로 조금 만들어 놓음
    public static Skill Worship0 = new Skill("젠장 또 대상혁이야!", 0, 100, 
        new List<Effect>
        {
            new Effect(EffectType.DamageWithAtkScale, 1f)
        });
    public static Skill Worship1 = new Skill("숭배할 수 밖에 없어!", 0, 100, 
        new List<Effect>
        {
            new Effect(EffectType.DamageWithAtkScale, 1f)
        });
    public static Skill Worship2 = new Skill("새삼 대단하다 느껴지네", 0, 100, 
        new List<Effect>
        {
            new Effect(EffectType.DamageWithAtkScale, 1f)
        });

    //    미니언
    public static Skill WeaknessAtk = new Skill("나약한 공격", 0, 100, new 
        List<Effect>
        {
            new Effect(EffectType.DamageWithAtkScale, 0.8f)
        });

    //    꼬마감독
    public static Skill AngryFeedback = new Skill("분노의 피드백", 0, 100, null,
        new List<Buff>
        {
             new Buff("공격력 감소", BuffType.StatUp,
             new Effect(EffectType.BuffAtk, 0.8f), 3)
        });
    public static Skill Warding = new Skill("꼬마 와드 꽃기", 0, 100, 
        new List<Effect>
        {
            new Effect(EffectType.DamageWithAtkScale, 0.9f)
        },
        new List<Buff>
        {
             new Buff("회피율 감소", BuffType.StatUp,
             new Effect(EffectType.IncreasedDodge, -20f), 3)
        });


    //    대상혁
    //    스킬 설계 먼저 해야함
    public static Skill Gotya = new Skill("잡았죠", 0, 100, 
        new List<Effect>
        {
            new Effect(EffectType.DamageWithAtkScale, 1.2f)
        });

    public static Skill IDodgeThat0 = new Skill("피했죠.", 0, 100, 
        new List<Effect>
        {
            //    피했죠 대미지 주기
            new Effect(EffectType.DamageWithAtkScale, 0.5f)
        });
    public static Skill IDodgeThat1 = new Skill("피했죠?", 0, 100, null,
        new List<Buff>
        { 
            new Buff("회피율 증가", BuffType.StatUp,
                new Effect(EffectType.IncreasedDodge, 30f), 2)
        });

    public static Skill God = new Skill("신이죠.", 0, 100,
        new List<Effect>
        {
            //    신이죠 체력 깎기
            new Effect(EffectType.CutHP, 0.2f)
        },
        new List<Buff>
        { 
            new Buff("회피율 감소", BuffType.StatUp,
                new Effect(EffectType.IncreasedDodge, -20), 2)
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