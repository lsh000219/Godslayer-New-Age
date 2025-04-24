using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    public enum EffectType { 
        Damage, 
        Heal, 
        BuffAtk, 
        BuffDef,
        DamageWithAtkScale,
        CutHP,
        DrainHP,
        DrainMP
    }

    public class Effect
    {
        public EffectType Type { get; set; }
        public float Value { get; set; }

        public Effect(EffectType type, float value)
        {
            Type = type;
            Value = value;
        }

        //    스킬 효과들
        public void Apply(Unit target, Unit user = null)
        //    시전자는 필요한 곳에만 적용 가능하게 만들기
        {
            switch (Type)
            {
                //    단순한 공격
                case EffectType.Damage:
                    target.HP -= Value;
                    break;

                //    체력 회복시키기
                case EffectType.Heal:
                    target.HP = Math.Min(target.MaxHP, target.HP + Value);
                    break;

                //    공격력 증가 시키기(미완성)
                case EffectType.BuffAtk:
                    target.Damage += Value;
                    break;

                //    방어력 버프하기
                case EffectType.BuffDef:
                    target.Defence += Value;
                    break;

                //    공격력에 비례해서 대미지 주기
                case EffectType.DamageWithAtkScale:
                    if(user != null)
                    {
                        float scaledDamage = user.Damage * Value;
                        target.HP -= scaledDamage;
                    }
                    break;

                //    최대 체력에 비례해 체력을 깎아버리기(정상화 전용으로 0.5f를 넣으면 반타작을 냄)
                case EffectType.CutHP:
                    target.HP = Math.Max(0, target.HP - (target.MaxHP * Value));
                    break;

                //    방어력 무시 공격
                case EffectType.DrainHP:
                    target.HP = Math.Max(0, target.HP - Value);
                    break;

                //    마나를 갂아버리기
                case EffectType.DrainMP:
                    target.MP = Math.Max(0, target.MP - Value);
                    break;
            }
        }



    }

}

