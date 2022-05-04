using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCountries
{
    public class CountryController
    {
        List<Country> CountryDB = new List<Country>();

        public CountryController()
        {
            CountryDB.Add(new Country() { Name = "United States", Continent = Country.Region.North_America, Colors = new List<string>{ "Red", "White", "Blue" } });
            CountryDB.Add(new Country() { Name = "Canada", Continent = Country.Region.North_America, Colors = new List<string> { "Red", "White" } });
            CountryDB.Add(new Country() { Name = "Germany", Continent = Country.Region.Europe, Colors = new List<string> { "Black", "Red", "Yellow" } });
            CountryDB.Add(new Country() { Name = "Portugal", Continent = Country.Region.Europe, Colors = new List<string> { "Green", "Red", "Yellow" } });
            CountryDB.Add(new Country() { Name = "China", Continent = Country.Region.Asia, Colors = new List<string> { "Red", "Yellow" } });
            CountryDB.Add(new Country() { Name = "Indonesia", Continent = Country.Region.Asia, Colors = new List<string> { "Red", "White" } });
            CountryDB.Add(new Country() { Name = "Brazil", Continent = Country.Region.South_America, Colors = new List<string> { "Green", "Yellow", "Blue" } });
            CountryDB.Add(new Country() { Name = "Chile", Continent = Country.Region.South_America, Colors = new List<string> { "Red", "White", "Blue" } });
            CountryDB.Add(new Country() { Name = "Australia", Continent = Country.Region.Ocenia, Colors = new List<string> { "Red", "White", "Blue" } });
            CountryDB.Add(new Country() { Name = "New Zealand", Continent = Country.Region.Ocenia, Colors = new List<string> { "Red", "White", "Blue" } });
            CountryDB.Add(new Country() { Name = "Ethiopia", Continent = Country.Region.Africa, Colors = new List<string> { "Yellow", "Red", "Blue", "Green" } });
            CountryDB.Add(new Country() { Name = "Egypt", Continent = Country.Region.Africa, Colors = new List<string> { "Yellow", "Black", "Red", "White" } });
            CountryDB.Add(new Country() { Name = "Penguins", Continent = Country.Region.Antarctica, Colors = new List<string> { "Black", "White" } });
            CountryDB.Add(new Country() { Name = "New Sealand", Continent = Country.Region.Antarctica, Colors = new List<string> { "Gray" } });
        }
        
        public void CountryAction(Country country)
        {
            CountryView countryView = new CountryView(country);
            countryView.Display();
        }

        public void WelcomeAction()
        {
            int index = -1;
            CountryListView countryList = new CountryListView(CountryDB);

            Console.WriteLine("Hello, welcome to the country app. Please select a country form the following list: ");
            countryList.Display();

            do
            {
                Console.WriteLine("Please put in an index to select a country.");
                string input = Console.ReadLine();

                if (int.TryParse(input, out index) && index >= 1 && index <= countryList.Countries.Count)
                {
                    break;
                }

                Console.WriteLine("Hello, welcome to the country app. Please select a country form the following list: ");
                countryList.Display();

                Console.WriteLine("That was not a correct index value. Let's try again.");

            } while (true);

            CountryAction(countryList.Countries[index - 1]); // We display the list starting at 1, so we have to subtract 1 here.

            do
            {
                Console.WriteLine("Do you want to learn about another country? y/n");

                string input = Console.ReadLine();

                if (input == "y")
                {
                    WelcomeAction();
                    break; // For when a user that repeats finally hits "n" and kicks them out of the loop.
                }
                else if (input == "n")
                {
                    Console.WriteLine("Goodbye.");
                    break;
                }
                else 
                { 
                    Console.WriteLine("I didn't understand that. Let's try again.");
                }
            } while (true);
        }
    }
}
