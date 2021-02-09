using MeleeVsMagic.Characters.Enums;

namespace MeleeVsMagic.Characters
{
    public abstract class MagicCharacter : Character
    {
        public override Faction Faction 
        { 
            get
            {
                return Faction.Magic;
            }
        }

        public override int[] AbilityPointsRange
        {
            get
            {
                return new int[] { 2, 4, 6, 8, 10 };
            }
        }

        public MagicCharacter(string name, int level = DefaultLevel)
            : base(name, level)
        {
        }

        public override string TakeSpecialDamage(int damage)
        {
            if (damage == 0)
            {
                return $"There was no special attack executed.";
            }
            else if (AbilityPoints == 0)
            {
                return $"It was a special attack, but {Name}'s ability points are already 0!";
            }
            else
            {
                AbilityPoints -= damage;

                if (AbilityPoints < 0)
                {
                    AbilityPoints = 0;
                }

                return $"It was a special attack! {Name}'s ability points are now {AbilityPoints}.";
            }
        }
    }
}
