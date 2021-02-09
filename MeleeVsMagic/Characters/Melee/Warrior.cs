using MeleeVsMagic.Equipment.Armors;
using MeleeVsMagic.Equipment.Weapons;
using MeleeVsMagic.Characters.Interfaces;

namespace MeleeVsMagic.Characters.Melee
{
    class Warrior : MeleeCharacter, IDefend
    {
        private readonly Chainlink defaultArmor = new Chainlink();
        private readonly Axe defaultWeapon = new Axe();

        public override int[] HealthPointsRange
        {
            get
            {
                return new int[] { 10, 11, 12, 13, 14 };
            }
        }

        public Warrior(string name, int level = DefaultLevel)
            : base(name, level)
        {
            Armor = defaultArmor;
            Weapon = defaultWeapon;
        }

        public override string Defend()
        {
            return Armor.UpgradeArmor(Name);
        }
    }
}
