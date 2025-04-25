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
        DrainMP,
        IncreasedCrit,
        IncreasedDodge
    }
    [Serializable]
    public class Effect
    {
        public EffectType _Type { get; set; }
        public float _Value { get; set; }

        public Effect(EffectType type, float value)
        {
            _Type = type;
            _Value = value;
        }


        //    스킬 프리셋
        public Effect trueDamage10 = new Effect(EffectType.DrainHP, 10);

        public static readonly Effect NomalHit = new Effect(EffectType.DamageWithAtkScale, 1f);

        //    스킬 효과들
        public void Apply(Unit target, Unit user = null)
        //    시전자는 필요한 곳에만 적용 가능하게 만들기
        {
            switch (_Type)
            {
                //    단순한 공격
                case EffectType.Damage:
                    target.HP -= _Value;
                    break;

                //    체력 회복시키기
                case EffectType.Heal:
                    target.HP = Math.Min(target.MaxHP, target.HP + _Value);
                    break;

                //    공격력 증가 시키기
                case EffectType.BuffAtk:
                    target.Damage *= _Value;
                    break;

                //    방어력 버프하기
                case EffectType.BuffDef:
                    target.Defence += _Value;
                    break;

                //    공격력에 비례해서 대미지 주기
                case EffectType.DamageWithAtkScale:
                    if (user != null)
                    {
                        float scaledDamage = user.Damage * _Value;
                        target.HP -= scaledDamage;
                    }
                    break;

                //    최대 체력에 비례해 체력을 깎아버리기(정상화 전용으로 0.5f를 넣으면 반타작을 냄)
                case EffectType.CutHP:
                    target.HP = Math.Max(0, target.HP - (target.MaxHP * _Value));
                    break;

                //    방어력 무시 공격
                case EffectType.DrainHP:
                    target.HP = Math.Max(0, target.HP - _Value);
                    break;

                //    마나를 갂아버리기
                case EffectType.DrainMP:
                    target.MP = Math.Max(0, target.MP - _Value);
                    break;

                //    크리티컬 확률 증가
                case EffectType.IncreasedCrit:
                    target.CritRate += _Value;
                    break;

                //    회피율 증가
                case EffectType.IncreasedDodge:
                    target.DodgeRate += _Value;
                    break;
            }
        }



    }

}

