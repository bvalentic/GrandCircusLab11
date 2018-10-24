using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab11
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goAhead = true;
            Console.WriteLine("Hello, and welcome to the Dev.Build(2.0) Film Library! \n" +
                "This is a list of 10 films deemed culturally, historically, or \n" +
                "aesthetically significant by me, Bob Valentic.\n");

            ArrayList movieList = new ArrayList();

            Movie casablanca = new Movie("Casablanca", "drama");
            Movie toyStory = new Movie("Toy Story", "animated");
            Movie twoThousand = new Movie("2001: A Space Odyssey", "sci-fi");
            Movie evilDead = new Movie("The Evil Dead", "horror");
            Movie vertigo = new Movie("Vertigo", "drama");
            Movie shrek = new Movie("Shrek", "animated");
            Movie bladeRunner = new Movie("Blade Runner", "sci-fi");
            Movie nosferatu = new Movie("Nosferatu", "horror");
            Movie citizenKane = new Movie("Citizen Kane", "drama");            
            Movie matrix = new Movie("The Matrix", "sci-fi");

            movieList.Add(casablanca);
            movieList.Add(toyStory);
            movieList.Add(twoThousand);
            movieList.Add(evilDead);
            movieList.Add(citizenKane);
            movieList.Add(shrek);
            movieList.Add(bladeRunner);
            movieList.Add(nosferatu);
            movieList.Add(vertigo);
            movieList.Add(matrix);

            while (goAhead)
            {
                PrintCategories();

                Console.Write("\nEnter the number corresponding to the genre you wish to view: ");
                int inputNum = Validator.CheckNum(Console.ReadLine(), "\nPlease enter a number 1-4: ");

                PrintList(inputNum, movieList);

                goAhead = KeepGoing("Would you like to continue? (y/n) ");
            }
        }

        static void PrintCategories()
        {//prints list of available genres to choose from
            for (int i = 0; i < Movie.categories.Length; i++)
            {
                Console.WriteLine($"{i+1} -- {Movie.categories[i]}");
            }
        }

        static void PrintList(int numCategory, ArrayList movieList)
        {//finds movies in the chosen genre, puts their title in a new list, sorts that list, then prints it
            Console.WriteLine($"\nYou chose {numCategory + 1} -- {Movie.categories[numCategory]}.\n");

            ArrayList newList = new ArrayList();

            foreach (Movie m in movieList)
            {
                
                if (m.Category == Movie.categories[numCategory])
                {//takes "The" if movie starts with it and places it on the end
                 //while it would've been easier to just format it this way originally
                 //I wanted to mess around with substring stuff
                    if (m.Title.StartsWith("The "))
                    {                        
                        m.Title = m.Title.Substring(4) + ", The";
                    }
                    newList.Add(m.Title);
                }
            }
            newList.Sort();
            Console.WriteLine($"There are {newList.Count} films in this library considered {Movie.categories[numCategory]}:\n");
            foreach (var n in newList)
            {
                Console.WriteLine(n);
            }
        }

        static bool KeepGoing(string message)
        {//method to check if user wants to continue, returns boolean used as check
            bool correctInput = true; //makes sure user puts in a variation of "yes" or "no"
            bool continuer = true; //eventual returned boolean
            do
            {
                Console.Write("\n" + message);
                string confirm = Console.ReadLine().ToLower();
                if (confirm == "n" || confirm == "no")
                {
                    Console.WriteLine("\nCome back soon!");
                    continuer = false;
                    correctInput = true;
                    Console.ReadKey();
                }
                else if (confirm == "y" || confirm == "yes")
                {
                    Console.WriteLine("\nOkay!\n");
                    continuer = true;
                    correctInput = true;
                }
                else
                {
                    Console.WriteLine("Sorry, I didn't understand.");
                    correctInput = false;
                }
            } while (!correctInput);
            return continuer;
        }
    }
}
