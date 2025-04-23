using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    public class Skill
    {
        public enum SkillTarget
        {
            Player,
            Enemy,
        }

        public string SkillName { get; set; }             // 스킬 이름
        public float Cost { get; set; }                   // 자원 소모 (MP or HP)
        public float Damage { get; set; }                 // 데미지 보정 (ex. 기본 공격력 * 계수)
        public float Heal { get; set; }                   // 회복량
        public float Probability { get; set; }            // 확률 기반 스킬일 경우 발동 확률
        public int Cooldown { get; set; }                 // 재사용 대기시간 (턴 수)
        public int MaxUseCount { get; set; }              // 사용 횟수 제한 (-1은 무제한)
        //public float HealthPercentDamage { get; set; }    // 체력 % 기반 데미지
        public SkillTarget Target { get; set; }           // 대상 (적, 아군, 전체 등)
        //public List<IStatusEffect> Effects { get; set; }  // 버프/디버프 같은 추가 효과 리스트


        Skill(SkillTarget target, string skillName, float cost, float damage, float heal,
            float probability, int cooldown, int maxUseCount)
        {
            Target = target;
            SkillName = skillName;
            Cost = cost;
            Damage = damage;
            Heal = heal;
            Probability = probability;
            Cooldown = cooldown;
            MaxUseCount = maxUseCount;
        }

        //    대미지가 1f인 이유는 (대미지 * 1f)
        public static Skill jumpAtk = new Skill(SkillTarget.Player, "띄어오르기", 0f, 1f, 0f, 100f, 0, -1);

    }
}
