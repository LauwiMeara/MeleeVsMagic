namespace MeleeVsMagic.Equipment.Armors
{
    class Chainlink : Armor
    {
        public override int DefaultArmorPoints
        {
            get
            {
                return 3;
            }
        }
        public override string UpgradeArmor(string name)
        {
            ArmorPoints++;
            return $"{name}'s chainlink is polished, and now has {ArmorPoints} armor points.";
        }
    }
}
