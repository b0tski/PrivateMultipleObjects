using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace PrivateMultipleObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfDates = 0;
            int curDates = 0;
            Console.Write("Enter the amount of dates you want to create: ");
            while (!int.TryParse(Console.ReadLine(), out numOfDates))
            {
                Console.WriteLine("Please enter a valid number!");
            }

            // dates array 
            Dates[] dates = new Dates[numOfDates];

            int numOfSeason = 0;
            int curSeasons = 0;
            Console.Write("Enter the amount of seasons you want to create: ");
            while (!int.TryParse(Console.ReadLine(), out numOfSeason))
            {
                Console.WriteLine("Please enter a valid number!");
            }

            // dates array 
            Seasons[] seasons = new Seasons[numOfDates];


            try
            {
                // Game loop 
                bool run = true;
                while (run)
                {
                    int choice = Menu();

                    // quit 
                    if (choice == 4) { run = false; break; }

                    Console.Write("Enter 1 for date or 2 for season \nEnter: ");
                    int type;
                    while (!int.TryParse(Console.ReadLine(), out type) || type != 1 && type != 2)
                    {
                        Console.WriteLine("Enter a real number");
                    }

                    switch (choice)
                    {
                        // Add
                        case 1:
                            if (type == 1)
                            {
                                if (curDates >= numOfDates)
                                {
                                    Console.WriteLine("You have reached the limit!");
                                }
                                else
                                {
                                    dates[curDates] = new Dates();
                                    dates[curDates].Add();
                                    curDates++;
                                }
                                break;
                            }
                            else
                            {
                                if (curSeasons >= numOfSeason)
                                {
                                    Console.WriteLine("You have reached the limit!");
                                }
                                else
                                {
                                    seasons[curSeasons] = new Seasons();
                                    seasons[curSeasons].Add();
                                    curSeasons++;
                                }
                                break;
                            }
                        // Change
                        case 2:
                            if (type == 1) // Date
                            {
                                Console.Write("Enter the date you want to change: ");
                                int value;
                                while (!int.TryParse(Console.ReadLine(), out value))
                                {
                                    Console.WriteLine("Please enter a valid number!");
                                    Console.Write("Enter the date you want to change: ");
                                }
                                while (value > curDates || value < 0)
                                {
                                    Console.WriteLine("Value was out of range!");
                                    while (!int.TryParse(Console.ReadLine(), out value))
                                    {
                                        Console.WriteLine("Enter a real value");
                                    }
                                }

                                dates[value - 1].Add();
                                break;
                            }
                            else // Seasons
                            {
                                Console.Write("Enter the season you want to change: ");
                                int value;
                                while (!int.TryParse(Console.ReadLine(), out value))
                                {
                                    Console.WriteLine("Please enter a valid number!");
                                    Console.Write("Enter the season you want to change: ");
                                }
                                while (value > curSeasons || value < 0)
                                {
                                    Console.WriteLine("Value was out of range!");
                                    while (!int.TryParse(Console.ReadLine(), out value))
                                    {
                                        Console.WriteLine("Enter a real value");
                                    }
                                }

                                seasons[value - 1].Add();
                                break;
                            }
                        case 3: // Display 
                            if (type == 1) // Dates
                            {
                                for (int i = 0; i < curDates; i++)
                                {
                                    dates[i].Display();
                                }
                                break;
                            }
                            else // Seasons 
                            {
                                for (int i = 0; i < curDates; i++)
                                {
                                    seasons[i].Display();
                                }
                                break;
                            }
                        case 4:
                            run = false;
                            break;

                    }
                    Console.Write("Press ENTER to clear...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }


            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

           

            Console.WriteLine("Thank you for playing!");


            int Menu()
            {

                int action = 0;
                while (action < 1 || action > 4) 
                { 
                    Console.Write("1-Add  2-Change  3-Print  4-Quit \nEnter: ");
                    while (!int.TryParse(Console.ReadLine(), out action)) 
                    {
                    }
                }
                        
                return action;
            }
        }


        // Base Class 
        class Dates
        {
            private int _days;
            private int _months;
            private int _years;

            public Dates()
            {
                _days = 0;
                _months = 0;
                _years = 0;
            }
            
            // Parameterized constructor
            public Dates(int days, int months, int years)
            {
                this._days = days;
                this._months = months;
                this._years = years;
            }

            // Get Methods
            public virtual int GetDays() { return _days; }
            public virtual int GetMonths() { return _months; }
            public virtual int GetYears() { return _years; }

            // Set Methods
            public void SetDays(int days) { _days = days; }
            public virtual void SetMonths(int months) { _months = months; }
            public virtual void SetYears(int years) { _years = years; }


            // display method
            public virtual void Display()
            {
                Console.WriteLine($"Date: {GetMonths()}/{GetDays()}/{GetYears()}");
            }

            // Add method 
            public virtual void Add()
            {
                Console.Write("Enter a month (1-12): ");
                SetMonths(int.Parse(Console.ReadLine()));
                Console.Write("Enter a day (1-31): ");
                SetDays(int.Parse(Console.ReadLine()));
                Console.Write("Enter a year: ");
                SetYears(int.Parse(Console.ReadLine()));
            }

        }

        // Derived Class 
        class Seasons : Dates
        {
            private string _season;
            private string _description;

            public Seasons() : base()
            {
                _season = string.Empty;
                _description = string.Empty;
            }

            public Seasons(string name, string description)
            {
                _season = name;
                _description = description;
            }

            // Get Methods 
            public string GetSeason() {  return _season; }
            public string GetDescription() { return _description; } 

            // Set Method
            public void SetName(string name) { _season = name; }
            public void SetDescription(string description) { _description = description; }

            // display method override 

            public override void Display()
            {
                base.Display();
                Console.WriteLine($"{GetSeason()}: {GetDescription()}");
            }

            public override void Add()
            {
                base.Add();
                Console.Write("Enter the season: ");
                SetName(Console.ReadLine());
                Console.Write($"Enter a description of {GetSeason()}: ");
                SetDescription(Console.ReadLine());
            }
        }
    }
}
