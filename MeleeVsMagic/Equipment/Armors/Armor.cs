using System;

namespace MeleeVsMagic.Equipment.Armors
{
    public abstract class Armor
    {
        public int ArmorPoints { get; set; }
        public abstract int DefaultArmorPoints { get; }

        public Armor()
        {
            ArmorPoints = DefaultArmorPoints;
        }
        public virtual string UpgradeArmor(string name)
        {
            throw new NotImplementedException();
        }
    }
}
