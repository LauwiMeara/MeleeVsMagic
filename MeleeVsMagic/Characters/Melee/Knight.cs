using MeleeVsMagic.Equipment.Armors;
using MeleeVsMagic.Equipment.Weapons;
using MeleeVsMagic.Characters.Interfaces;

namespace MeleeVsMagic.Characters.Melee
{
    class Knight : MeleeCharacter, IDefend
    {
        private readonly Chainlink defaultArmor = new Chainlink();
        private readonly Sword defaultWeapon = new Sword();

        public override int[] HealthPointsRange
        {
            get
            {
                return new int[] { 10, 15, 20, 25, 30 };
            }
        }

        public Knight(string name, int level = DefaultLevel)
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
