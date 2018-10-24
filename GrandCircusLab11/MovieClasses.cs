using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab11
{
    class Movie
    {
        private string title;
        private string category;
        
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        public Movie (string title, string category)
        {
            Title = title;
            Category = category;
        }        

        public static string[] categories = new string[] { "animated", "drama", "horror", "sci-fi" };
        //I wasn't sure to put this array here or in the main method, but since this class is the only thing 
        //that uses it I thought it was fair to place it in the class
    }

    class Validator
    {
        public static int CheckNum(string inputString, string errorMessage)
        {//checks input string is of required type (in this case, non-zero positive doubles)
            int input;
            while (!(int.TryParse(inputString, out input)) || int.Parse(inputString) <= 0 || int.Parse(inputString) > 4)
            {//only positive non-zero numbers allowed
                Console.Write($"I'm sorry, that's not a valid input. {errorMessage}");
                inputString = Console.ReadLine();
            }
            return input - 1; //to account for difference of 1 between input and index
        }
    }
}
