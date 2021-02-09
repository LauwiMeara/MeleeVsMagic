namespace MeleeVsMagic.Equipment.Weapons
{
    class Staff : Weapon
    {
        public override int DefaultDamage
        {
            get
            {
                return 3;
            }
        }

        public override string UpgradeWeapon(string name)
        {
            Damage *= 2;
            return $"{name}'s staff is upgraded, and can now deal {Damage} damage.";
        }
    }
}
