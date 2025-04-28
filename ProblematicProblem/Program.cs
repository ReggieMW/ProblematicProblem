using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading;

public class Program
{
    static void Main(string[] args)
    {
        List<string> activities = new List<string>()
        {
            "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting"
        };

        Console.Write("Hello, welcome to the random activity generator! \nTo start, please enter your name: ");
        string userName = Console.ReadLine();

        Console.Write("\nWhat is your age? ");
        int userAge; 
        while (!int.TryParse(Console.ReadLine(), out userAge) || userAge < 0)
        {
            Console.WriteLine("Please enter a valid age!");
        }

        Console.Write("\nWould you like to see the current list of activities? Yes/No: ");
        var seeList = Console.ReadLine().Trim().ToLower();

        if (seeList == "yes" || seeList == "y")
        {
            foreach (string activity in activities)
            {
                Console.Write($"- {activity}\n");
                Thread.Sleep(200);
            }

            Console.Write("Would you like to add any activities before we generate one? Yes/No: ");
            var addActivity = Console.ReadLine().Trim().ToLower();

            while (addActivity == "yes" || addActivity == "y")
            {
                Console.Write("What would you like to add? ");
                string userAddition = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userAddition))
                activities.Add(userAddition.Trim());
                
                Console.Write("Would you like to add another? Yes/No: ");
                addActivity = Console.ReadLine().Trim().ToLower();
            }
        }

        Console.Write("Connecting to the database");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(". ");
            Thread.Sleep(200);
        }

        Console.WriteLine();
        Console.Write("Choosing your random activity");
        for (int i = 0; i < 9; i++)
        {
            Console.Write(". ");
            Thread.Sleep(200);
        }

        Console.WriteLine();
        
        Random rng = new Random();
        string satisfied = "";
        
        do
        {
            if (activities.Count == 0)
            {
                Console.WriteLine("No activities available!");
                return;
            }    
        
            int randomNumber = rng.Next(activities.Count);
            string randomActivity = activities[randomNumber];

            if (userAge < 21 && randomActivity == "Wine Tasting")
            {
                Console.WriteLine(
                    $"Oh no! Looks like you are too young to do {randomActivity}. Choosing another activity...");
                activities.Remove(randomActivity);
                continue;
            }

            Console.WriteLine($"\nAh got it! {userName}, your random activity is: {randomActivity}! Are you satisfied with this activity? Yes/No: ");
            satisfied = Console.ReadLine().Trim().ToLower();

            if (satisfied == "no" || satisfied == "n")
            {
                activities.Remove(randomActivity);
            }
            
        } while (satisfied == "no" || satisfied == "n");

        Console.WriteLine("\nEnjoy your activity!");
    }
}