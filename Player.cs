using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameFinal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Player : IDamageable
    {
        public int Health { get; set; } = 100;
        public int AttackPower { get; set; } = 5;
        public List<Item> Inventory { get; private set; } = new List<Item>();

        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"You take {amount} damage. Remaining HP: {Health}");
        }

        public void AddItem(Item item)
        {
            if (Inventory.Count >= 5)
            {
                Console.WriteLine("Inventory full. Discard something first.");
            }
            else
            {
                Inventory.Add(item);
                Console.WriteLine($"{item.Name} added to inventory.");
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("\nInventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }

        public void UseItem(string itemName)
        {
            var item = Inventory.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
            if (item != null)
            {
                item.Use(this);
                Inventory.Remove(item);
            }
            else
            {
                Console.WriteLine("Item not found in inventory.");
            }
        }

        public bool HasKey(string roomName)
        {
            return Inventory.OfType<Key>().Any(k => k.TargetRoom == roomName);
        }


    }

}
