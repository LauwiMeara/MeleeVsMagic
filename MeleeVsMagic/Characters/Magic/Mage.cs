using MeleeVsMagic.Equipment.Armors;
using MeleeVsMagic.Equipment.Weapons;
using MeleeVsMagic.Characters.Interfaces;

namespace MeleeVsMagic.Characters.Magic
{
    class Mage : MagicCharacter, IDefend
    {
        private readonly Robe defaultArmor = new Robe();
        private readonly Staff defaultWeapon = new Staff();

        public override int[] HealthPointsRange
        {
            get
            {
                return new int[] { 10, 15, 20, 30, 40 };
            }
        }

        public Mage(string name, int level = DefaultLevel)
            : base(name, level)
        {
            Armor = defaultArmor;
            Weapon = defaultWeapon;
        }
   
        public override string Defend()
        {
            return Weapon.UpgradeWeapon(Name);
        }
    }
}
