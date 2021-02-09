namespace MeleeVsMagic.Equipment.Weapons
{
    class Sword : Weapon
    {
        public override int DefaultDamage
        {
            get
            {
                return 4;
            }
        }

        public override string UpgradeWeapon(string name)
        {
            Damage++;
            return $"{name}'s sword is sharpened, and can now deal {Damage} damage.";
        }
    }
}
