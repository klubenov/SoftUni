using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string characterName)
        {
            if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException($"Ivalid faction \"{faction}\"!");
            }
            switch (characterType)
            {
                case "Warrior":
                    return new Warrior(characterName, parsedFaction);
                case "Cleric":
                    return new Cleric(characterName, parsedFaction);
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }
        }
    }
}
