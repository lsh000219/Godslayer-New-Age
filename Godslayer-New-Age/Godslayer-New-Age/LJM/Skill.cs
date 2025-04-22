using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    internal class Skill
    {
        public string SkillName { get; set; }       //    스킬 이름
        public float Cost { get; set; }             //    마나 or 체력 소모
        public float Damage { get; set; }           //    증폭되는 데미지 수치
        public float Heal { get; set; }             //    회복량 (0이면 회복 없음)
        public float ActivationChance { get; set; } //    확률로 발동 (확률 지정 후 RandomManager를 통해 확률 계산)
        public int DelayTurns { get; set; }         //    딜레이 턴 (기본 0 = 즉시발동)


    }
}
