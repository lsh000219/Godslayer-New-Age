using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    internal class Skill
    {
        public string SkillName { get; set; } //    스킬 이름
        public float Cost { get; set; } //    소모량(마나 또는 체력)
        public float Damage { get; set; } //    가하는 데미지 보정
        public float Heal { get; set; } //    만약 치료가 존재한다면 치료 량
        public float EctValue { get; set; } //    만약 다른걸 줄이는것이 존재한다면

        public Skill(string skillName, float cost, float damage, float heal, float cetValue)
        {
            SkillName = skillName;
            Cost = cost;
            Damage = damage;
            Heal = heal;
            EctValue = cetValue;
            //    이 수치의 경우 방어력 증가나 감소, 공격력 증가나 감소를 담당함.
            //    만약 복수 수치가 필요하다면 몇개 더 추가
        }

        //    스킬 목록
        public static Skill justHit = new Skill("평타", 0, 5f, 0f, 0f);

    }
}