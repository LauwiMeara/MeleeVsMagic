using System;

namespace MeleeVsMagic.Equipment.Weapons
{
    public abstract class Weapon
    {
        public int Damage { get; set; }
        public abstract int DefaultDamage { get; }

        public Weapon()
        {
            Damage = DefaultDamage;
        }

        public virtual string UpgradeWeapon(string name)
        {
            throw new NotImplementedException();
        }
    }
}
