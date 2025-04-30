using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameFinal
{
    internal class Story
    {
        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Dungeon Game!");
            Console.WriteLine("You find yourself in a dark and eerie dungeon.");
            Console.WriteLine("Your goal is to escape by defeating monsters and collecting items.");
            Console.WriteLine("\nHow this game works:");
            Console.WriteLine("- At any point enter 'quit' to exit the game.");
            Console.WriteLine("- Use 'inventory' to view the contence of your inventory. You have five inventory slots.");
            Console.WriteLine("- Throughout the gameplay you will be prompted to make desitions, enter the letter or number specified.");
            Console.WriteLine("\nGood luck!");
        }

        public void ShowCurrentRoom(string roomName)
        {
            Console.WriteLine($"\nYou are in the {roomName}.");
            switch (roomName)
            {
                case "Entrence":
                    Console.WriteLine("You wake up in a dark room feeling groggy.");
                    //get players name and validate
                    break;
                case "hall":
                    Console.WriteLine("You are in a long hallway with doors on either side.");
                    break;
            }

            Console.WriteLine("What would you like to do?");
        }   
        public void GameOver()
        {
            Console.WriteLine("Game Over! You have been defeated and have died in the dungeon.");
            Console.WriteLine("Better luck next time!");
        }
        public void Victory()
        {
            Console.WriteLine("Congratulations! You have escaped the dungeon!");
            Console.WriteLine("You are victorious!");
        }

    }
}
