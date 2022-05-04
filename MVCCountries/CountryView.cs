using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCountries
{
    public class CountryView
    {
        public Country DisplayCountry { get; set; }

        public CountryView(Country Country)
        {
            this.DisplayCountry = Country;
        }

        public void Display()
        {
            Console.WriteLine("Country Details");
            Console.WriteLine("Name: " + DisplayCountry.Name);
            Console.WriteLine("Continent: " + DisplayCountry.Continent.ToString().Replace("_", " "));
            Console.Write("Flag colors: ");
            
            for (int i = 0; i < DisplayCountry.Colors.Count; i++)
            {
                ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), DisplayCountry.Colors[i]);

                // Countries occasionally think it's a good idea to have a 1 color flag https://en.wikipedia.org/wiki/List_of_flags_by_number_of_colors
                if (DisplayCountry.Colors.Count == 1) 
                {
                    Console.ForegroundColor = color;
                    Console.Write(DisplayCountry.Colors[0] + ".");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
                if (DisplayCountry.Colors.Count == 2) // For when a flag as 2 colors.
                {
                    ConsoleColor color0 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), DisplayCountry.Colors[0]);
                    ConsoleColor color1 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), DisplayCountry.Colors[1]);

                    Console.ForegroundColor = color0;
                    Console.Write(DisplayCountry.Colors[0]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" and ");
                    Console.ForegroundColor = color1;
                    Console.Write(DisplayCountry.Colors[1]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(".");
                    break;
                }

                if (i + 1 == DisplayCountry.Colors.Count) // For when a country has 3 or more colors.
                {
                    Console.Write("and ");
                    Console.ForegroundColor = color;
                    Console.Write(DisplayCountry.Colors[i]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(".");
                    break;
                }
                else
                {
                    Console.ForegroundColor = color;
                    Console.Write(DisplayCountry.Colors[i]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }
    }
}
