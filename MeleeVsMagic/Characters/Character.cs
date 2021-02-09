using MeleeVsMagic.Characters.Enums;
using MeleeVsMagic.Characters.Interfaces;
using MeleeVsMagic.Equipment.Armors;
using MeleeVsMagic.Equipment.Weapons;
using System;

namespace MeleeVsMagic.Characters
{
    public abstract class Character : IAttack, IDefend
    {
        protected const int DefaultLevel = 1;
        private int level;

        public abstract Faction Faction { get; }

        public string Name { get; private set; }

        public int Level
        {
            get
            {
                return level;
            }
            private set
            {
                if (value < 1 || value > 5)
                {
                    level = DefaultLevel;
                }
                else
                {
                    level = value;
                }
            }
        }
        public int HealthPoints { get; set; }
        public int AbilityPoints { get; protected set; }
        public int ExperiencePoints { get; set; }

        public abstract int[] HealthPointsRange { get; }
        public abstract int[] AbilityPointsRange { get; }

        public Armor Armor { get; protected set; }
        public Weapon Weapon { get; protected set; }

        public Character(string name, int level = DefaultLevel)
        {
            Name = name;
            Level = level;
            InitializeHealthPoints();
            InitializeAbilityPoints();
            ExperiencePoints = 0;
        }

        private void InitializeHealthPoints()
        {
            HealthPoints = HealthPointsRange[Level - 1];
        }

        private void InitializeAbilityPoints()
        {
            AbilityPoints = AbilityPointsRange[Level - 1];
        }

        public int Attack()
        {
            return Weapon.Damage;
        }

        public int SpecialAttack()
        {
            if (AbilityPoints == 0)
            {
                return 0;
            }
            else
            {
                int[] damageRange = { 0, 0, 0, 0, 0, 0, 0, 1, 1, 2 };

                Random rng = new Random();
                int damage = damageRange[rng.Next(damageRange.Length)];

                if (damage > 0)
                {
                    AbilityPoints--;
                }

                return damage;
            }
        }

        public virtual string Defend()
        {
            throw new NotImplementedException();
        }

        public string Heal()
        {
            HealthPoints += 5;
            return $"{Name} healed, and now has {HealthPoints} health points.";
        }

        public string TakeDamage(string attackerName, int damage)
        {
            int damageAfterArmorProtection = damage - Armor.ArmorPoints;

            if (damageAfterArmorProtection > 0)
            {
                HealthPoints -= damageAfterArmorProtection;

                if (HealthPoints <= 0)
                {
                    return $"{Name} was attacked by {attackerName} and killed.";
                }
                else
                {
                    return $"{Name} was attacked by {attackerName}, and now has {HealthPoints} health points left.";
                }
            }
            else
            {
                return $"{Name} was attacked by {attackerName}, but was protected by armor.";
            }
        }

        public virtual string TakeSpecialDamage(int damage)
        {
            throw new NotImplementedException();
        }

        public void LevelUp()
        {
            ExperiencePoints++;

            if (ExperiencePoints %2 == 0 && Level < 5)
            {
                Level++;
            }
        }
    }
}
