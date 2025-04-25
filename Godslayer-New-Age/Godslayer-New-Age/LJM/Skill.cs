using Godslayer_New_Age.LJM;
using System.Collections.Generic;
using System;

[Serializable]
public class Skill
{
    public string SkillName { get; set; }
    public float Cost { get; set; }
    public float Probability { get; set; }
    public List<Effect> Effects { get; set; } = new List<Effect>();
    public List<Buff> Buffs { get; set; } = new List<Buff>();

    public Skill(string name, float cost, float probability, List<Effect> effects, List<Buff> buffs = null)
    {
        SkillName = name;
        Cost = cost;
        Probability = probability;
        Effects = effects;
        Buffs = buffs;
    }


    public static Skill justHit = new Skill("때리기", 0, 100,
        new List<Effect> {
            new Effect(EffectType.Damage, 30)
        });


    public static Skill heavyStrike = new Skill("헤비 스트라이크", 0, 100,
        new List<Effect> {
    new Effect(EffectType.DamageWithAtkScale, 2.0f)
        });  // 공격력 x 2의 대미지 주기



    //    justHit.Use(target);
    public void Use(Unit target, Unit user = null)
    {
        if (RandomManager.Instance.Next(0, 100) > Probability)
        {
            Console.WriteLine($"{SkillName}은(는) 발동하지 않았다!");
            return;
        }

        Console.WriteLine($"{SkillName} 발동!");

        foreach (var effect in Effects)
        {
            effect.Apply(target, user);
        }

        //    해당 스킬에 버프가 없을수 도 있으니
        if (Buffs != null)
        {
            foreach (var buff in Buffs)
            {
                //target.Buffs.Add(new Buff(buff._Name, buff._Effect, buff.RemainingTurn));
            }
        }
    }
}