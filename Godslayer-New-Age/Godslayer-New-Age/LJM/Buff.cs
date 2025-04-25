using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    public enum BuffType
    {
        StatUp,         // 공격력/방어력 증가 등
        DamageOnTurn, // 지속 피해
        HealOnTurn,   // 지속 회복
        Stun,           // 행동 불가
        Shield,         // 피해 흡수
    }

    //    버프는 스킬의 이팩트의 효과를 가져와서 Unit 즉, 전체적인 캐릭터와 적군에게 사용이 가능하게 만듦.
    //    이팩트와 따로 분리한 이유는 이팩트는 그 즉시, 버프는 턴 마다 또는 일정 턴 동안 작동해야 하기 때문에
    //    이러한 차별점을 둘 필요가 있었음
    public class Buff
    {
        public string _Name { get; set; } //    버프의 이름
        public BuffType _Type { get; set; } //    버프의 타임
        //    이 부분에 따라 효과가 다르게 나타남
        public Effect _Effect { get; set; } //    버프의 효과
        //    해당 버프가 주는 효과로 이팩트에 관한건 Effect에서 다룸
        public int _RemainingTurn { get; set; }

        private bool IsApplied = false;

        private float? OriginalValue = null;

        public Buff(string name, BuffType type, Effect effect, int duration)
        {
            _Name = name;
            _Type = type;
            _Effect = effect;
            _RemainingTurn = duration;
        }

        public Buff Poison = new Buff("독", BuffType.DamageOnTurn,
            new Effect(EffectType.DrainHP, 10), 5);


        //    실질적인 버프의 효과를 주는 곳
        public void Apply(Unit target)
        {
            switch (_Type)
            {
                case BuffType.StatUp:
                    if (!IsApplied)
                    {
                        switch (_Effect._Type)
                        {
                            case EffectType.BuffAtk:
                                OriginalValue = target.Damage;
                                target.Damage += _Effect._Value;
                                break;

                            case EffectType.BuffDef:
                                OriginalValue = target.Defence;
                                target.Defence += _Effect._Value;
                                break;
                        }
                        IsApplied = true;
                    }
                    break;

                case BuffType.DamageOnTurn:
                case BuffType.HealOnTurn:
                    _Effect.Apply(target);
                    break;
            }

            _RemainingTurn--;
        }

        //    만약 타입이 스탯 증가고 만료가 됬다면
        public void Remove(Unit target)
        {
            if (_Type == BuffType.StatUp && IsApplied)
            {
                //    다시 원래 스탯으로 되돌리기
                Revert(target);
            }
        }

        //    다시 원상태로 돌리기
        public void Revert(Unit target)
        {
            if (!IsApplied || OriginalValue == null) return;

            switch (_Effect._Type)
            {
                case EffectType.BuffAtk:
                    target.Damage = OriginalValue.Value;
                    break;

                case EffectType.BuffDef:
                    target.Defence = OriginalValue.Value;
                    break;
            }

            IsApplied = false;
            OriginalValue = null;
        }

        public bool IsExpired => _RemainingTurn <= 0;
    }
}
