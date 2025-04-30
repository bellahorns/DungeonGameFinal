using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DungeonGameFinal
{

    public class GameTests
    {
        public static void RunTests()
        {
            Player p = new Player();
            Debug.Assert(p.Health == 100);
            p.AddItem(new HealthPotion("Small Potion", 10));
            Debug.Assert(p.Inventory.Count == 1);

            var weapon = new Weapon("Sword", 10);
            p.AddItem(weapon);
            p.UseItem("Sword");
            Debug.Assert(p.AttackPower == 15);
            Debug.Assert(p.Inventory.Count == 1);
        }
    }
}
