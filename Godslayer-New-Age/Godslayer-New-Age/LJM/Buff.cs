using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    public enum BuffType
    {
        StatUp,         // 공격력/방어력 증가 등
        DamageOverTime, // 지속 피해
        HealOverTime,   // 지속 회복
        Stun,           // 행동 불가
        Shield,         // 피해 흡수
    }

    [Serializable]
    public class Buff
    {
        public string _Name { get; set; }
        public BuffType Type { get; set; }
        public Effect _Effect { get; set; }
        public int RemainingTurn { get; set; }

        private bool IsApplied = false;
        private float OriginalValue;

        public Buff(string name, BuffType type, Effect effect, int duration)
        {
            _Name = name;
            Type = type;
            _Effect = effect;
            RemainingTurn = duration;
        }

        public void Apply(Unit target)
        {
            switch (Type)
            {
                //    만약 스탯 증가라면?
                case BuffType.StatUp:
                    //    만약 아직 버프가 만료가 안됬다면
                    if (!IsApplied)
                    {
                        //    해당 버프 적용시키고
                        //    값을 받았다는 bool값 조정
                        ApplyStatBuff(target);
                        IsApplied = true;
                    }
                    break;

                //    턴 마다 회복/대미지라면
                case BuffType.DamageOverTime:
                case BuffType.HealOverTime:
                    _Effect.Apply(target);
                    break;
            }

            RemainingTurn--;
        }

        //    만약 타입이 스탯 증가고 만료가 됬다면
        public void Remove(Unit target)
        {
            if (Type == BuffType.StatUp && IsApplied)
            {
                //    다시 원래 스탯으로 되돌리기
                RestoreStat(target);
            }
        }



        //    버프 적용시키기
        private void ApplyStatBuff(Unit target)
        {
            switch (_Effect.Type)
            {
                //    공격력 증가
                case EffectType.BuffAtk:
                    //    우선 원래의 값을 저장하고 공격력 증가 시키기
                    OriginalValue = target.Damage;
                    target.Damage += (int)_Effect.Value;
                    break;

                //    방어력 증가
                case EffectType.BuffDef:
                    OriginalValue = target.Defence;
                    target.Defence += (int)_Effect.Value;
                    break;
            }
        }

        //    다시 원상태로 돌리기
        private void RestoreStat(Unit target)
        {
            switch (_Effect.Type)
            {
                case EffectType.BuffAtk:
                    //    저장해놨었던 원래 값으로 다시 되돌리기
                    target.Damage = OriginalValue;
                    break;
                case EffectType.BuffDef:
                    target.Defence = OriginalValue;
                    break;
            }
        }

        public bool IsExpired => RemainingTurn <= 0;
    }
}