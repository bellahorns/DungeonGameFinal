using System;
using System.Media;

namespace DungeonGameFinal
{
    class Program
    {
        static void Main()
        {
            GameTests.RunTests();

            Player player = new Player();

            // Create Rooms
            Room entrance = new Room { Name = "Entrance" };
            Room hall = new Room { Name = "Hall", Monster = new Goblin() };
            Room library = new Room { Name = "Library", Item = new HealthPotion("Large Potion", 25) };
            Room armory = new Room { Name = "Armory", Item = new Weapon("Battle Axe", 15), Monster = new Vampire() };
            Room throne = new Room { Name = "Throne Room", Monster = new Witch(), IsLocked = true, KeyRequired = "Throne Room" };

            // Link Rooms
            entrance.Connections["north"] = hall;
            hall.Connections["south"] = entrance;
            hall.Connections["east"] = library;
            library.Connections["west"] = hall;
            hall.Connections["west"] = armory;
            armory.Connections["east"] = hall;
            hall.Connections["north"] = throne;
            throne.Connections["south"] = hall;

            // Place key
            armory.Item = new Key("Golden Key", "Throne Room");

            Room currentRoom = entrance;
            currentRoom.Enter(player);

            while (true)
            {
                Story.WelcomeMessage();
                Story.ShowCurrentRoom(currentRoom.Name);

                Console.WriteLine("\nCommands: move [direction], attack, use [item], inventory, quit");
                var input = Console.ReadLine().ToLower().Split();
                var cmd = input[0];

                switch (cmd)
                {
                    case "move":
                        if (input.Length < 2 || !currentRoom.Connections.ContainsKey(input[1]))
                        {
                            Console.WriteLine("Invalid direction.");
                            break;
                        }
                        currentRoom = currentRoom.Connections[input[1]];
                        currentRoom.Enter(player);
                        break;

                    case "attack":
                        if (currentRoom.Monster == null || currentRoom.Monster.Health <= 0)
                        {
                            Console.WriteLine("You can’t attack; there’s no monster here.");
                            break;
                        }

                        currentRoom.Monster.TakeDamage(player.AttackPower);
                        if (currentRoom.Monster.Health > 0)
                            currentRoom.Monster.Attack(player);
                        else
                            Console.WriteLine($"You defeated the {currentRoom.Monster.Name}!");
                        break;

                    case "use":
                        if (input.Length < 2) { Console.WriteLine("Use what?"); break; }
                        string itemName = string.Join(" ", input.Skip(1));
                        player.UseItem(itemName);
                        break;

                    case "inventory":
                        player.ShowInventory();
                        break;

                    case "quit":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }

                if (currentRoom.Name == "Throne Room" && (currentRoom.Monster?.Health ?? 0) <= 0)
                {
                    Console.WriteLine("You escaped the dungeon! Victory!");
                    break;
                }

                if (player.Health <= 0)
                {
                    Console.WriteLine("You have perished in the dungeon...");
                    break;
                }
            }
        }
    }
}