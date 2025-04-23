using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    /*
    public interface IStatusEffect
    {
        string Name { get; }
        int Duration { get; set; }
        void ApplyEffect(Unit target);      // 턴마다 효과 적용
        void OnApply(Unit target);          // 처음 적용될 때
        void OnExpire(Unit target);         // 지속시간 끝났을 때
    }

    public class AtkBuff : IStatusEffect
    {
        public string Name => "공격력 증가";
        public int Duration { get; set; }
        private float buffAmount;

        public AtkBuff(int duration, float amount)
        {
            Duration = duration;
            buffAmount = amount;
        }

        public void OnApply(Unit target)
        {
            target.Damage += buffAmount;
            Console.WriteLine($"{target.Name}의 공격력이 {buffAmount} 만큼 증가했어!");
        }

        public void ApplyEffect(Unit target)
        {
            // 턴마다 별도 행동이 없다면 비워도 됨
        }

        public void OnExpire(Unit target)
        {
            target.Damage -= buffAmount;
            Console.WriteLine($"{target.Name}의 공격력 증가 효과가 끝났어.");
        }
    */
}
}