using MeleeVsMagic.Equipment.Armors;
using MeleeVsMagic.Equipment.Weapons;
using MeleeVsMagic.Characters.Interfaces;

namespace MeleeVsMagic.Characters.Magic
{
    public class Druid : MagicCharacter, IDefend
    {
        private readonly LeatherVest defaultArmor = new LeatherVest();
        private readonly Axe defaultWeapon = new Axe();

        public override int[] HealthPointsRange
        {
            get
            {
                return new int[] { 10, 20, 30, 40, 50 };
            }
        }

        public Druid(string name, int level = DefaultLevel)
            : base(name, level)
        {
            Armor = defaultArmor;
            Weapon = defaultWeapon;
        }
   
        public override string Defend()
        {
            return Heal();
        }
    }
}
