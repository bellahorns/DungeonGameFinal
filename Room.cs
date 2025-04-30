using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonGameFinal
{
    public class Room
    {
        public string Name { get; set; }
        public bool IsLocked { get; set; }
        public string KeyRequired { get; set; }
        public Monster Monster { get; set; }
        public Item Item { get; set; }
        public Dictionary<string, Room> Connections { get; set; } = new Dictionary<string, Room>();

        public void Enter(Player player)
        {
            if (IsLocked && !player.HasKey(Name))
            {
                Console.WriteLine($"The {Name} is locked. You need a key.");
                return;
            }

            Console.WriteLine($"\nYou enter the {Name}.");
            if (Monster != null && Monster.Health > 0)
            {
                Console.WriteLine($"A wild {Monster.Name} appears!");
            }

            if (Item != null)
            {
                Console.WriteLine($"You see a {Item.Name}.");
                player.AddItem(Item);
                Item = null;
            }
        }
    }
}
