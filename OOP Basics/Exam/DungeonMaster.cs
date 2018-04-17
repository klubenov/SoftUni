using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        private List<Character> Party { get; }

        private Stack<Item> ItemPool { get; }

        private int LastSurvivorRounds { get; set; }

        public DungeonMaster()
        {
            this.Party = new List<Character>();
            this.ItemPool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            var characterFactory = new CharacterFactory();
            var faction = args[0];
            var type = args[1];
            var name = args[2];
            var newCharacter = characterFactory.CreateCharacter(faction,type,name);
            Party.Add(newCharacter);
            LastSurvivorRounds = 0;
            return $"{newCharacter.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemFactory = new ItemFactory();
            var newItem = itemFactory.CreateItem(args[0]);
            this.ItemPool.Push(newItem);
            return $"{args[0]} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            CheckIfCharacterExists(args[0]);
            if (this.ItemPool.Count==0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            var character = Party.Find(c => c.Name == args[0]);
            var item = ItemPool.Pop();
            character.ReceiveItem(item);
            return $"{character.Name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            CheckIfCharacterExists(args[0]);
            var character = Party.Find(c => c.Name == args[0]);
            var item = character.Bag.GetItem(args[1]);
            character.UseItem(item);
            return $"{character.Name} used {item.GetType().Name}.";
        }

        public string UseItemOn(string[] args)
        {
            CheckIfCharacterExists(args[0]);
            CheckIfCharacterExists(args[1]);
            var character = Party.Find(c => c.Name == args[0]);
            var reciever = Party.Find(c => c.Name == args[1]);
            var item = character.Bag.GetItem(args[2]);
            character.UseItemOn(item,reciever);
            return $"{character.Name} used {item.GetType().Name} on {reciever.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            CheckIfCharacterExists(args[0]);
            CheckIfCharacterExists(args[1]);
            var character = Party.Find(c => c.Name == args[0]);
            var reciever = Party.Find(c => c.Name == args[1]);
            var item = character.Bag.GetItem(args[2]);
            reciever.ReceiveItem(item);
            return $"{character.Name} gave {reciever.Name} {item.GetType().Name}.";
        }

        public string GetStats()
        {
            return string.Join(Environment.NewLine, Party.OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health));
        }

        public string Attack(string[] args)
        {
            CheckIfCharacterExists(args[0]);
            CheckIfCharacterExists(args[1]);
            var character = Party.Find(c => c.Name == args[0]);
            var reciever = Party.Find(c => c.Name == args[1]);
            if (character.GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{character.Name} cannot attack!");
            }
            ((Warrior)character).Attack(reciever);
            string reveicerstatus = "";
            if (!reciever.IsAlive)
            {
                reveicerstatus = $"\r\n{reciever.Name} is dead!";
            }
            return $"{character.Name} attacks {reciever.Name} for {character.AbilityPoints} hit points! " +
                   $"{reciever.Name} has {reciever.Health}/{reciever.BaseHealth} HP and " +
                   $"{reciever.Armor}/{reciever.BaseArmor} AP left!" + reveicerstatus;
        }

        public string Heal(string[] args)
        {
            CheckIfCharacterExists(args[0]);
            CheckIfCharacterExists(args[1]);
            var character = Party.Find(c => c.Name == args[0]);
            var reciever = Party.Find(c => c.Name == args[1]);
            if (character.GetType().Name != "Cleric")
            {
                throw new ArgumentException($"{character.Name} cannot heal!");
            }
            ((Cleric)character).Heal(reciever);
            return
                $"{character.Name} heals {reciever.Name} for {character.AbilityPoints}! {reciever.Name} has {reciever.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            var endTurnSb = new StringBuilder();
            foreach (var character in Party.Where(c=>c.IsAlive))
            {
                var healthBeforeRest = character.Health;
                character.Rest();
                var healthAfterRest = character.Health;
                endTurnSb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {healthAfterRest})");
            }
            if (Party.Count(c => c.IsAlive) <=1)
            {
                LastSurvivorRounds++;
            }
            return endTurnSb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if (LastSurvivorRounds>1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CheckIfCharacterExists(string name)
        {
            if (!Party.Any(c => c.Name == name))
            {
                throw new ArgumentException($"Character {name} not found!");
            }
        }
    }
}
