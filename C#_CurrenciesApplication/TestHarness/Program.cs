using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrenciesDAL;
using CurrenciesDAL.Models;
using Type = CurrenciesDAL.Models.Type;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            #region "GET ALL"

            #region "GET ALL Currencies TEST"

            List<Currency> currenciesList = CurrencyManager.GetCurrencyList();
            Console.WriteLine("List of currencies: " + "\n");

            foreach (Currency currency in currenciesList)
            {
                Console.WriteLine(currency.Name);
            }

            #endregion
            #region "GET ALL Colours TEST"

            List<Colour> coloursList = ColoursManager.GetColourList();
            Console.WriteLine("\nList of colours: ");

            foreach (Colour colour in coloursList)
            {
                Console.WriteLine(colour.Name);
            }

            #endregion
            #region "GET ALL Country TEST"
            List<Country> countriesList = CountryManager.GetCountryList();
            Console.WriteLine("\nList of countries: ");

            foreach (Country country in countriesList)
            {
                Console.WriteLine(country.Name);
            }
            #endregion
            #region "GET ALL Types TEST"
            List<Type> typesList = TypesManager.GetTypeList();
            Console.WriteLine("\nList of types: ");

            foreach (Type type in typesList)
            {
                Console.WriteLine(type.Name);
            }

            #endregion
            #endregion
            #region "GET ONE"
            #region "GET ONE Currency by ID TEST"
            Console.Write("\nEnter a currency ID: ");
            string getCurrencyId = Console.ReadLine();

            Currency getCurrencyById = CurrencyManager.GetCurrency(int.Parse(getCurrencyId));

            if (getCurrencyById != null)
            {
                Console.WriteLine(getCurrencyById.Name);
            }
            else
            {
                Console.WriteLine("Sorry, currency ID cannot be found.");
            }
            #endregion
            #region "GET ONE Colours by ID TEST"

            Console.Write("\nEnter a Colour ID: ");
            string getColourId = Console.ReadLine();

            Colour getColourById = ColoursManager.GetColour(int.Parse((getColourId)));

            if (getColourById != null)
            {
                Console.WriteLine(getColourById.Name);
            }
            else
            {
                Console.WriteLine("Sorry, the colour ID cannot be found.");
            }
            #endregion
            #region "GET ONE Country by ID TEST"

            Console.Write("\nEnter a country Code: ");
            string getCountryCode = Console.ReadLine();

            Country getCountryByCode = CountryManager.GetCountry(getCountryCode);

            if (getCountryByCode != null)
            {
                Console.WriteLine(getCountryByCode.Name);
            }
            else
            {
                Console.WriteLine("Sorry, the country code cannot be found.");
            }
            #endregion
            #region "GET ONE Type by ID TEST"

            Console.Write("\nEnter a type ID: ");
            string getTypeId = Console.ReadLine();

            Type getTypeById = TypesManager.GetTypes(int.Parse((getTypeId)));

            if (getTypeById != null)
            {
                Console.WriteLine(getTypeById.Name);
            }
            else
            {
                Console.WriteLine("Sorry, the type ID cannot be found.");
            }

            #endregion
            #endregion

            #region "ADD"
            /*
            #region "ADD Currency TEST"
            Currency addCurrency = new Currency();
            addCurrency.Name = "Japanese Yen";

            Currency addCurrencyTwo = CurrencyManager.AddCurrency(addCurrency);
            Console.WriteLine(string.Format("The new Currency ID is {0}", addCurrency.Id));
            */
            #region "ADD Colour TEST"
            Colour addColour = new Colour();
            addColour.Id = 20;
            addColour.Name = "Blue";

            Colour addColourTwo = ColoursManager.AddColour(addColour);
            Console.WriteLine(string.Format("The new Colour Id is {0}", addColourTwo.Id));
            #endregion

            #region "ADD Country TEST"
            #endregion

            #region "ADD Type TEST"
            #endregion

            #endregion

            #region "UPDATE"
            /*
            #region "UPDATE Currency TEST"
            Currency updateCurrency = new Currency();
            updateCurrency.Id = 3;
            updateCurrency.Name = "Japanese Yen";
            updateCurrency.ColourId = 4;
            updateCurrency.CountryCode = "JPN";

            int rowsAffected = CurrencyManager.UpdateCurrency(updateCurrency);
            Console.WriteLine("Update successful! {0} rows affected", rowsAffected);
   
            #endregion
            */

            #region "UPDATE Colours TEST"
            Colour updateColours = new Colour();
            updateColours.Id = 2;
            updateColours.Name = "Blue";

            //int colourRowsAffected = ColoursManager.UpdateColour(updateColours);
            //Console.WriteLine("Update successful! {0} rows affected", colourRowsAffected);

            #endregion
            
            #region "UPDATE Countries TEST"
            Country updateCountries = new Country();
            updateCountries.CountryCode = "GRE";
            updateCountries.Name = "Greece Updated";

            //string countryRowsAffected = CountryManager.UpdateCountry(updateCountries);
            //Console.WriteLine("Update successful! {0} rows affected", countryRowsAffected);
            #endregion

            #region "UPDATE Types TEST"
            Type updateTypes = new Type();
            updateTypes.Id = 2;
            updateTypes.Name = "Crypto";

            //int typeRowsAffected = TypesManager.UpdateType(updateTypes);
            //Console.WriteLine("Update successful! {0} rows affected", typeRowsAffected);

            #endregion
            #endregion
            
            #region "DELETE"

            #region "DELETE Currency TEST"
            Console.Write("\nPlease enter the Currency Id you wish to delete: ");
            string deleteCurrencyId = Console.ReadLine();
            CurrencyManager.DeleteCurrency(Int32.Parse(deleteCurrencyId));

            if (deleteCurrencyId != null)
            {
                Console.WriteLine(string.Format("\nCurrency Id {0} has been deleted.", deleteCurrencyId));
            }
            else
            {
                Console.WriteLine("Sorry, the currency ID cannot be deleted.");
            }
            #endregion

            #region "DELETE Colours TEST"
            Console.Write("\nPlease enter the Colour Id you wish to delete: ");
            string deleteColourId = Console.ReadLine();
            ColoursManager.DeleteColour(Int32.Parse(deleteColourId));

            if (deleteColourId != null)
            {
                Console.WriteLine(string.Format("\nColour Id {0} has been deleted.", deleteColourId));
            }
            else
            {
                Console.WriteLine("Sorry, the colour ID cannot be deleted.");
            }

            #endregion

            #region "DELETE Countries TEST"
            Console.Write("\nPlease enter the Country Code you wish to delete: ");
            string deleteCountryCode = Console.ReadLine();
            CountryManager.DeleteCountry(deleteCountryCode);

            if (deleteCountryCode != null)
            {
                Console.WriteLine("\nCountry Code {0} has been deleted.", deleteCountryCode);
            }
            else
            {
                Console.WriteLine("Sorry, the country code cannot be deleted.");
            }
            #endregion

            #region "DELETE Types TEST"
            Console.Write("\nPlease enter the Type Id you wish to delete: ");
            string deleteTypeId = Console.ReadLine();
            TypesManager.DeleteType(Int32.Parse(deleteTypeId));

            if (deleteTypeId != null)
            {
                Console.WriteLine(string.Format("\n Type Id {0} has been deleted.", deleteTypeId));
            }
            else
            {
                Console.WriteLine("Sorry, the type ID cannot be deleted.");
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to close...");
            Console.Read(); //keep console window open
            #endregion

            #endregion
        }
    }
}