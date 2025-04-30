using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameFinal
{
    public abstract class Monster : IDamageable
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }

        public virtual void Attack(Player player)
        {
            Console.WriteLine($"{Name} attacks for {Strength} damage!");
            player.TakeDamage(Strength);
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} takes {amount} damage. Remaining HP: {Health}");
        }
    }

    public class Vampire : Monster
    {
        public Vampire()
        {
            Name = "Vampire";
            Health = 40;
            Strength = 10;
        }

        public override void Attack(Player player)
        {
            base.Attack(player);
            Health += 5;
            Console.WriteLine($"{Name} drains life and heals 5 HP!");
        }
    }

    public class Goblin : Monster
    {
        public Goblin()
        {
            Name = "Goblin";
            Health = 20;
            Strength = 5;
        }
    }

    public class Witch : Monster
    {
        public Witch()
        {
            Name = "Witch";
            Health = 30;
            Strength = 8;
        }

        public override void Attack(Player player)
        {
            Console.WriteLine($"{Name} casts a spell and deals {Strength} magical damage!");
            player.TakeDamage(Strength);
        }
    }

}
