using MeleeVsMagic.Characters.Enums;

namespace MeleeVsMagic.Characters
{
    public abstract class MeleeCharacter : Character
    {
        public override Faction Faction 
        { 
            get
            {
                return Faction.Melee;
            }
        }

        public override int[] AbilityPointsRange
        {
            get
            {
                return new int[] { 1, 2, 3, 4, 5 };
            }
        }

        public MeleeCharacter(string name, int level = DefaultLevel)
            : base(name, level)
        {
        }

        public override string TakeSpecialDamage(int damage)
        {
            if (damage == 0)
            {
                return $"There was no special attack executed.";
            }
            else if (Armor.ArmorPoints == 0)
            {
                return $"It was a special attack, but {Name}'s armor points are already 0!";
            }
            else
            {
                Armor.ArmorPoints -= damage;

                if (Armor.ArmorPoints < 0)
                {
                    Armor.ArmorPoints = 0;
                }

                return $"It was a special attack! {Name}'s armor points are now {Armor.ArmorPoints}.";
            }
        }
    }
}
