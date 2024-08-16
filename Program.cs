using System;

class Program
{
    static void Main()
    {
        // Define the ourAnimals array with initial size (number of pets x number of characteristics)
        string[,] ourAnimals = new string[4, 6] 
        {
            { "1", "Dog", "3", "Brown, Medium size", "Friendly", "Buddy" },
            { "2", "Cat", "2", "White, Small size", "Curious", "Whiskers" },
            { "3", "Dog", "5", "Black, Large size", "Calm", "Rex" },
            { "4", "Cat", "1", "Gray, Medium size", "Playful", "Shadow" }
        };

        // Display the main menu
        string userChoice;
        do
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. List all of our current pet information.");
            Console.WriteLine("2. Assign values to the ourAnimals array fields.");
            Console.WriteLine("3. Ensure animal ages and physical descriptions are complete.");
            Console.WriteLine("4. Ensure animal nicknames and personality descriptions are complete.");
            Console.WriteLine("5. Edit an animal’s age.");
            Console.WriteLine("6. Edit an animal’s personality description.");
            Console.WriteLine("7. Display all cats with a specified characteristic.");
            Console.WriteLine("8. Display all dogs with a specified characteristic.");
            Console.WriteLine("Enter menu item selection or type \"Exit\" to exit the program");

            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    DisplayAllPets(ourAnimals);
                    break;
                case "2":
                    AddNewPet(ref ourAnimals);
                    break;
                case "Exit":
                    Console.WriteLine("Exiting the application...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

        } while (userChoice != "Exit");
    }

    static void DisplayAllPets(string[,] animals)
    {
        Console.WriteLine("Pet ID\tSpecies\tAge\tPhysical Characteristics\tPersonality\tNickname");
        for (int i = 0; i < animals.GetLength(0); i++)
        {
            Console.WriteLine($"{animals[i, 0]}\t{animals[i, 1]}\t{animals[i, 2]}\t{animals[i, 3]}\t{animals[i, 4]}\t{animals[i, 5]}");
        }
    }

    static void AddNewPet(ref string[,] animals)
    {
        int newLength = animals.GetLength(0) + 1;
        string[,] newAnimals = new string[newLength, 6];

        // Copy existing data to new array
        for (int i = 0; i < animals.GetLength(0); i++)
        {
            for (int j = 0; j < animals.GetLength(1); j++)
            {
                newAnimals[i, j] = animals[i, j];
            }
        }

        // Add new pet data
        Console.WriteLine("Enter pet species (dog or cat):");
        string species = Console.ReadLine();

        int newPetID = newLength; // simple incremental ID
        Console.WriteLine("Enter pet age:");
        string age = Console.ReadLine();
        Console.WriteLine("Enter pet physical characteristics:");
        string physicalCharacteristics = Console.ReadLine();
        Console.WriteLine("Enter pet personality:");
        string personality = Console.ReadLine();
        Console.WriteLine("Enter pet nickname:");
        string nickname = Console.ReadLine();

        newAnimals[newLength - 1, 0] = newPetID.ToString();
        newAnimals[newLength - 1, 1] = species;
        newAnimals[newLength - 1, 2] = age;
        newAnimals[newLength - 1, 3] = physicalCharacteristics;
        newAnimals[newLength - 1, 4] = personality;
        newAnimals[newLength - 1, 5] = nickname;

        animals = newAnimals; // Update the original array reference
    }
}
