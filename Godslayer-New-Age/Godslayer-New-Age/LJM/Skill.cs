using Godslayer_New_Age.LJM;
using System.Collections.Generic;
using System;

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


    //    ===== 스킬 만드는 곳! ===== //
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