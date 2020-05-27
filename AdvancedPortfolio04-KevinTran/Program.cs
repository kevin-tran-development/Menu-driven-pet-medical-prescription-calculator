/*
 * Purpose: To create a menu driven program that calculates the doses of medicated prescription for the user's pets by 
 * taking in their pets information such as name, age, weight, and either a dog or cat.
 * 
 * Input: Name of the pet, age, weight, and either a dog or cat.
 * 
 * Process: By using the formula for dosage in ml, weight divided by 2.205 multiplied by mg per kg divided by mg per ml, 
 * we can use that to calculate the correct dosage of medication for either pain killer, sedative, or both for the user's pet.
 * 
 * Output: The dosage requirement for either pain killer (carprofen), sedative (acepromazine), or both.
 * 
 * Author: Kevin Tran
 * 
 * Last Modified: December 2, 2019
 */
using System;

namespace AdvancedPortfolio04_KevinTran
{
    class Program
    {
        static void PetClinicWelcome()
        {
            // Welcome message to the pet clinic application
            Console.WriteLine("|----------------------------------|");
            Console.WriteLine("| CPSC1012 Pet Clinic              |");
            Console.WriteLine("|----------------------------------|");
        }

        static void PetDisplayInfo(string petName, int petAge, double petWeight, char petType)
        {
            // Displays the Information of the pet depending on the inputs that the user gave
            Pet PetInfo = new Pet(petName, petAge, petWeight, petType);
            string typeOfPet = String.Empty;
            if(petType == 'd' || petType == 'D')
            {
                typeOfPet = "Dog";
            }
            if(petType == 'c' || petType == 'C')
            {
                typeOfPet = "Cat";
            }
            Console.WriteLine($"Name: {PetInfo.Name}, Age: {PetInfo.Age} years, Weight: {PetInfo.Weight} lbs, Type: {typeOfPet}");
        }

        static void PetServiceOptions()
        {
            // The options for the user in the menu screen
            Console.WriteLine();
            Console.WriteLine("Service Options");
            Console.WriteLine("1.\tPain Killer");
            Console.WriteLine("2.\tSedative");
            Console.WriteLine("3.\tBoth Pain Killer and Sedative");
            Console.Write("Enter the service (1-3) required for your pet: ");
        }

        static int ObtainServiceChoice()
        {
            // Obtaining the user input choice for which service that they would like
            bool validateChoice = false;
            int menuChoice = 0;
            string userInput;

            while (!validateChoice)
            {
                PetServiceOptions();
                userInput = Console.ReadLine();
                Console.WriteLine();
                try
                {
                    menuChoice = int.Parse(userInput);
                    if(menuChoice >= 1 && menuChoice <= 3)
                    {
                        validateChoice = true;
                    }
                    else
                    {
                        Console.WriteLine($"{userInput} is not a valid choice.");
                        Console.WriteLine($"Please enter a value between 1 and 3");
                    }
                }
                catch
                {
                    Console.WriteLine($"{userInput} is not a valid choice.");
                }
            }

            return menuChoice;
        }

        static void ProcessServiceChoice(int menuChoice, string petName, int petAge, double petWeight, char petType)
        {
            // Processing the service choice and launching the appropriate service method
            switch (menuChoice)
            {
                case 1:
                    ServicePainKiller(petWeight, petType);
                    break;
                case 2:
                    ServiceSedative(petWeight, petType);
                    break;
                case 3:
                    ServicePainSedative(petWeight, petType);
                    break;
                default:
                    Console.WriteLine("Please select a valid menu choice");
                    break;
            }
        }

        // The three services (Pain killer, Sedative, or both)
        static void ServicePainKiller(double petWeight, char petType)
        {
            Pet painKiller = new Pet();
            painKiller.Weight = petWeight;
            painKiller.Type = petType;

            double carprofen;
            carprofen = painKiller.Carprofen();
            Console.WriteLine($"Your pet requires {carprofen:F3}ml of carprofen.");
        }

        static void ServiceSedative(double petWeight, char petType)
        {
            Pet sedative = new Pet();
            sedative.Weight = petWeight;
            sedative.Type = petType;

            double acepromazine;
            acepromazine = sedative.Acepromazine();
            Console.WriteLine($"Your pet requires {acepromazine:F3}ml of acepromazine.");
        }

        static void ServicePainSedative(double petWeight, char petType)
        {
            ServicePainKiller(petWeight, petType);
            ServiceSedative(petWeight, petType);
        }
      
        // Obtaining information about the user's pet
        static string GetPetName(string prompt, Pet currentPetName)
        {
            // Obtaining the pet name from user
            string petName = String.Empty;
            bool validInput = false;
            while (!validInput)
            {
                try
                {
                    Console.Write(prompt);
                    currentPetName.Name = Console.ReadLine();
                    petName = currentPetName.Name;
                    validInput = true;
                }
                catch(Exception)
                {
                    Console.WriteLine("Name must have at least one non-whitespace character.");                   
                }
            }

            return petName;
        }

        static int GetPetAge(string prompt, Pet currentPetAge)
        {
            // Obtaining the pet age from the user
            int petAge = 0;
            bool validInput = false;
            while (!validInput)
            {
                try
                {
                    Console.Write(prompt);
                    currentPetAge.Age = int.Parse(Console.ReadLine());
                    petAge = currentPetAge.Age;
                    validInput = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Age must be atleast 1 year old.");
                }
            }

            return petAge;
        }

        static double GetPetWeight(string prompt, Pet currentPetWeight)
        {
            // Obtaining the pet weight from the user
            double petWeight = 0;
            bool validInput = false;
            while (!validInput)
            {
                try
                {
                    Console.Write(prompt);
                    currentPetWeight.Weight = double.Parse(Console.ReadLine());
                    petWeight = currentPetWeight.Weight;
                    validInput = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Weight must be at least 5 pounds.");
                }
            }

            return petWeight;
        }

        static char GetPetType(string prompt, Pet currentPetType)
        {
            // Obtaining the pet type from the user
            char petType = '\0';
            bool validInput = false;
            while (!validInput)
            {
                try
                {
                    Console.Write(prompt);
                    currentPetType.Type = char.Parse(Console.ReadLine());
                    petType = currentPetType.Type;
                    validInput = true;                   
                }
                catch (Exception)
                {
                    Console.WriteLine("Pet type must be D or C");
                }
            }

            return petType;
        }

        static char PetInfoValidation(string petName, int petAge, double petWeight, char petType)
        {
            // Validating and displaying to the user if they information that they inputted is correct
            char correctPetInfo;
            string userInput;

            PetDisplayInfo(petName, petAge, petWeight, petType);
            Console.Write("Is the information above about your pet correct? Enter y or n: ");
            userInput = Console.ReadLine();
            correctPetInfo = char.Parse(userInput);

            while (correctPetInfo != 'y' && correctPetInfo != 'Y' && correctPetInfo != 'n' && correctPetInfo != 'N')
            {
                Console.Write("Invalid input. Enter y or n only: ");
                userInput = Console.ReadLine();
                correctPetInfo = char.Parse(userInput);
            }

            if (correctPetInfo == 'y' || correctPetInfo == 'Y')
            {
                int menuChoice;
                menuChoice = ObtainServiceChoice();
                ProcessServiceChoice(menuChoice, petName, petAge, petWeight, petType);
            }

            return correctPetInfo;
        }

        static void PetQuestionnaire()
        {
            // Prompting the user for the pet information
            char correctPetInfo,
                 petType;
            int petAge;
            double petWeight;
            string petName;

            do
            {
                Pet name = new Pet();
                petName = GetPetName("Enter the name of your pet: ", name);

                Pet age = new Pet();
                petAge = GetPetAge("Enter the age in years of your pet: ", age);

                Pet weight = new Pet();
                petWeight = GetPetWeight("Enter the weight in pounds of your pet: ", weight);

                Pet type = new Pet();
                petType = GetPetType("Enter D for Dog, C for Cat: ", type);

                correctPetInfo = PetInfoValidation(petName, petAge, petWeight, petType);
               
            } while (correctPetInfo == 'n' || correctPetInfo == 'N');

            //return correctPetInfo;
        }
      
        static void Main(string[] args)
        {
            char continueServices;
            string userInput;
            do
            {
                Console.WriteLine();
                PetClinicWelcome();
                PetQuestionnaire();
                Console.Write("\nDo you have another pet that requires service? Enter y or n: ");
                userInput = Console.ReadLine();
                continueServices = char.Parse(userInput);

                while(continueServices != 'y' && continueServices != 'Y' && continueServices != 'n' && continueServices != 'N')
                {
                    Console.WriteLine("Invalid input. Enter y or n only.");
                    Console.Write("Do you have another pet that requires service? Enter y or n: ");
                    userInput = Console.ReadLine();
                    continueServices = char.Parse(userInput);                   
                }

                if (continueServices == 'n' || continueServices == 'N')
                {
                    Console.WriteLine("Good-bye and thanks for using the Pet Clinic application!");
                }

            } while (continueServices == 'y' || continueServices == 'Y');
        }
    }
}
