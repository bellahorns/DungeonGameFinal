using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameFinal
{
    public abstract class Item : ICollectible
    {
        public string Name { get; set; }
        public abstract void Use(Player player);
    }

    public class HealthPotion : Item
    {
        public int HealAmount { get; set; }

        public HealthPotion(string name, int healAmount)
        {
            Name = name;
            HealAmount = healAmount;
        }

        public override void Use(Player player)
        {
            player.Health += HealAmount;
            Console.WriteLine($"You used {Name} and gained {HealAmount} HP!");
        }
    }

    public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public override void Use(Player player)
        {
            player.AttackPower += Damage;
            Console.WriteLine($"You equipped {Name}. Attack +{Damage}.");
        }
    }

    public class Key : Item
    {
        public string TargetRoom { get; set; }

        public Key(string name, string targetRoom)
        {
            Name = name;
            TargetRoom = targetRoom;
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"You hold the {Name}, it might unlock {TargetRoom}.");
        }
    }

}
