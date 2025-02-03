using System;
using System.Globalization;


internal class Program
{
    static void Main(string[] args)
    {

        // Nastavení kultury na en-us
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        // Vytvoření instance a volání metody na zobrazení menu
        Menu menu = new Menu();
        menu.ZobrazMenu();

    }
}
internal static class Settings
{
    private static int maxPets = 8;
    private static int pocetVlastnostiZvirete = 7;

    public static int MaxPets
    {
        get { return maxPets; }
        set { maxPets = value > 0 ? value : maxPets; } // Změna jen pokud je hodnota > 0
    }

    public static int PocetVlastnostiZvirete
    {
        get { return pocetVlastnostiZvirete; }
        set { pocetVlastnostiZvirete = value > 0 ? value : pocetVlastnostiZvirete; }
    }
}
internal class AnimalsArray
{
    public static string[,] OurAnimals = new string[Settings.MaxPets, Settings.PocetVlastnostiZvirete];

    // Konstruktor třídy ve kterém voláme metodu pro naplnění pole existujícími daty
    public AnimalsArray()
    {
        FillTheArray();
    }


    // deklarace proměnných
    string animalSpecies = "";
    string animalID = "";
    string animalAge = "";
    string animalPhysicalDescription = "";
    string animalPersonalityDescription = "";
    string animalNickname = "";
    string suggestedDonation = "";
    decimal decimalDonation = 0.00m;

    // Tahle metoda slouží k naplnění seznamu mazlíčků existujícími daty
    public void FillTheArray()
    {
        for (int i = 0; i < Settings.MaxPets; i++)
        {
            switch (i)
            {
                case 0:
                    animalSpecies = "dog";
                    animalID = "d1";
                    animalAge = "2";
                    animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    animalNickname = "lola";
                    suggestedDonation = "85.00";
                    break;

                case 1:
                    animalSpecies = "dog";
                    animalID = "d2";
                    animalAge = "9";
                    animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    animalNickname = "gus";
                    suggestedDonation = "49.99";
                    break;

                case 2:
                    animalSpecies = "cat";
                    animalID = "c3";
                    animalAge = "1";
                    animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                    animalPersonalityDescription = "friendly";
                    animalNickname = "snow";
                    suggestedDonation = "40.00";
                    break;

                case 3:
                    animalSpecies = "cat";
                    animalID = "c4";
                    animalAge = "3";
                    animalPhysicalDescription = "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
                    animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
                    animalNickname = "Lion";
                    break;

                default:
                    animalSpecies = "";
                    animalID = "";
                    animalAge = "";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    break;

            }


            // Tady nastavuju sloupce v array
            OurAnimals[i, 0] = "ID #: " + animalID;
            OurAnimals[i, 1] = "Species: " + animalSpecies;
            OurAnimals[i, 2] = "Age: " + animalAge;
            OurAnimals[i, 3] = "Nickname: " + animalNickname;
            OurAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            OurAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
            OurAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";


            if (!decimal.TryParse(suggestedDonation, out decimalDonation))
            {
                decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
            }
        }
    }
}
internal class Menu
{
    AnimalsArray animalsArray = new AnimalsArray();
    Search search = new Search();

    string menuSelection = "";
    string? readResult;

    public void ZobrazMenu()
    {
        do
        {
            // NOTE: the Console.Clear method is throwing an exception in debug sessions
            Console.Clear();

            Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Filter by species - cats/dogs");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();
            }

            // use switch-case to process the selected menu option
            switch (menuSelection)
            {
                case "1":
                    // list all pet info
                    for (int i = 0; i < Settings.MaxPets; i++)
                    {
                        if (AnimalsArray.OurAnimals[i, 0] != "ID #: ")
                        {
                            Console.WriteLine();
                            for (int j = 0; j < Settings.PocetVlastnostiZvirete; j++)
                            {
                                Console.WriteLine(AnimalsArray.OurAnimals[i, j]);
                            }
                        }
                    }
                    Console.WriteLine("\n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();

                    break;

                case "2":
                    // Display all dogs with a specified characteristic
                    Console.WriteLine("\nUNDER CONSTRUCTION - please check back next month to see progress.");
                    Console.WriteLine("Type the number to choose from cats(1) or dogs(2)");
                    Console.WriteLine("1. Cats");
                    Console.WriteLine("2. Dogs");
                    string filterWho = Console.ReadLine();
                    switch (filterWho)
                    {
                        case "1":
                            search.FindSpecies("cat");
                            break;
                        case "2":
                            search.FindSpecies("dog");
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                default:
                    break;
            }

        } while (menuSelection != "exit");
    }
}
internal class Search
{
    

    public void FindSpecies(string animal)
    {
        for (int i = 0; i < Settings.MaxPets; i++)
        {
            if (!string.IsNullOrEmpty(AnimalsArray.OurAnimals[i, 1]) && AnimalsArray.OurAnimals[i, 1].Contains(animal))
            {

                Console.WriteLine("\n*** Animal Found ***");
                for (int j = 0; j < Settings.PocetVlastnostiZvirete; j++)
                {
                    Console.WriteLine(AnimalsArray.OurAnimals[i, j]);
                }
            }
        }
    }


}