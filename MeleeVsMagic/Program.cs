using MeleeVsMagic.Characters;
using MeleeVsMagic.Characters.Enums;
using MeleeVsMagic.Characters.Magic;
using MeleeVsMagic.Characters.Melee;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeleeVsMagic
{
    class Program
    {
        static void Main()
        {
            const string Banner = @"
  __  __      _                             __  __              _        
 |  \/  |    | |                           |  \/  |_           (_)       
 | \  / | ___| | ___  ___    __   _____    | \  / (_)__ _  __ _ _  ___   
 | |\/| |/ _ \ |/ _ \/ _ \   \ \ / / __|   | |\/| | / _` |/ _` | |/ __|  
 | |  | |  __/ |  __/  __/    \ V /\__ \   | |  | || (_| | (_| | | (__ _ 
 |_|  |_|\___| |\___|\___|     \_/ |___/   |_|  |_(_)__,_|\__, |_|\___(_)
             | |                                           __/ |         
             |_|                                          |___/
";


            List<Character> characters = new List<Character>
            {
                new Druid("Ficus the Druid"),
                new Mage("Ellazora the Mage"),
                new Necromancer("Agnor the Necromancer"),
                new Assassin("Rick the Assassin"),
                new Knight("Goubert the Knight"),
                new Warrior("Doomblow the Warrior")
            };

            List<MagicCharacter> magicTeam = new List<MagicCharacter>();
            List<MeleeCharacter> meleeTeam = new List<MeleeCharacter>();

            GetTeamLists(characters, magicTeam, meleeTeam);

            Random rng = new Random();

            bool isGameOver = false;

            int counter = 0;

            while (!isGameOver)
            {
                Console.Clear();
                Console.WriteLine($"{Banner}");
                Console.WriteLine();

                PrintParticipants(meleeTeam, magicTeam);
                Tools.PrintDashes();

                counter++;

                Character magicCharacter = magicTeam[rng.Next(magicTeam.Count)];
                Character meleeCharacter = meleeTeam[rng.Next(meleeTeam.Count)];

                Console.WriteLine($"Round {counter}: {meleeCharacter.Name} vs {magicCharacter.Name}");
                Console.WriteLine();

                if (KillDefender(meleeCharacter, magicCharacter))
                {
                    magicTeam.Remove((MagicCharacter)magicCharacter);

                    if (magicTeam.Count == 0)
                    {
                        Tools.PrintDashes();
                        PrintGameOverMessage(meleeTeam.Cast<Character>());
                        break;
                    }
                    else
                    {
                        magicCharacter = magicTeam[rng.Next(magicTeam.Count)];
                    }
                }

                Console.WriteLine();

                if (KillDefender(magicCharacter, meleeCharacter))
                {
                    meleeTeam.Remove((MeleeCharacter)meleeCharacter);

                    if (meleeTeam.Count == 0)
                    {
                        Tools.PrintDashes();
                        PrintGameOverMessage(magicTeam.Cast<Character>());
                        break;
                    }
                }

                Tools.PrintDashes();
                Console.WriteLine();
                Console.Write("Press enter to continue... ");
                Console.ReadLine();
            }
        }

        private static void GetTeamLists(List<Character> characters, List<MagicCharacter> magicTeam, List<MeleeCharacter> meleeTeam)
        {
            foreach (Character character in characters)
            {
                if (character.Faction == Faction.Magic)
                {
                    magicTeam.Add((MagicCharacter)character);
                }
                else
                {
                    meleeTeam.Add((MeleeCharacter)character);
                }
            }
        }

        private static void PrintParticipants (List<MeleeCharacter> meleeTeam, List<MagicCharacter> magicTeam)
        {
            Console.WriteLine("The following characters are able to fight:");
            Console.WriteLine();

            Tools.WriteWhiteText("Melee:", 1);
            PrintCharacters(meleeTeam.Cast<Character>());

            Console.WriteLine();

            Tools.WriteWhiteText("Magic:", 1);
            PrintCharacters(magicTeam.Cast<Character>());

            Console.WriteLine();
        }

        private static void PrintCharacters (IEnumerable<Character> team)
        {
            foreach (Character character in team)
            {
                Console.WriteLine($"- {character.Name}");
            }
        }

        private static bool KillDefender (Character attacker, Character defender)
        {
            bool killedDefender = false;

            Tools.WriteWhiteText($"{attacker.Name}, do you want to attack (A) or defend (D)? ");
            string input = Console.ReadLine().ToUpper();

            if (input == "D")
            {
                Console.WriteLine(attacker.Defend());
            }
            else
            {
                if (input != "A")
                {
                    Console.WriteLine($"You have given the wrong input. {attacker.Name} is impatient and will attack now!");
                }

                Console.WriteLine(defender.TakeDamage(attacker.Name, attacker.Attack()));
                Console.WriteLine(defender.TakeSpecialDamage(attacker.SpecialAttack()));

                if (defender.HealthPoints <= 0)
                {
                    killedDefender = true;
                    attacker.LevelUp();
                }
            }

            return killedDefender;
        }

        private static void PrintGameOverMessage(IEnumerable<Character> team)
        {
            Console.WriteLine();
            Console.WriteLine("There are no enemies left. Game over!");
            Console.WriteLine();
            Tools.WriteWhiteText("Congratulations to:", 1);

            foreach (Character character in team)
            {
                Console.WriteLine($"- {character.Name}, level {character.Level}");
            }
        }
    }
}
