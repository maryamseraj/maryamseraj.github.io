using System;

namespace _NETApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo(); 

            GreetUser(); 

            Menu(); 

            // Menu
            static void Menu()
            {
                // menu to select game
                Console.WriteLine("Welcome, please choose a game");
                Console.WriteLine("=============================");
                Console.WriteLine("1: Guessing the number game");
                Console.WriteLine("=============================");
                Console.WriteLine("2: Guessing the number game 2");
                Console.WriteLine("=============================");
                Console.WriteLine("3: Fortune Teller");
                Console.WriteLine("=============================");
                Console.WriteLine("4: Quit Menu");
                Console.WriteLine("=============================");

                // gets user input from menu
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) // starts game based on user input
                {
                    case 1:
                        Console.WriteLine("You have selected Guessing the number game");
                        NumberGuessingGame(); // Starts game 1
                        break;
                    case 2:
                        Console.WriteLine("You have selected Guessing the number game 2");
                        NumberGuessingGameTwo(); // Starts game 2 
                        break;
                    case 3:
                        Console.WriteLine("You have selected Fortune Teller");
                        FortuneTeller(); // Starts game 3
                        break;
                    case 4:
                        System.Environment.Exit(1); // Closes application
                        break;
                } 
            } 

            // Get and display app info
            static void GetAppInfo()
            {
                // Set app vars
                string appName = "Number Guesser";
                string appVersion = "1.0.0";
                string appAuthor = "Mary";

                // Change text colour
                Console.ForegroundColor = ConsoleColor.Green;

                // Write out app info
                Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);
                Console.ResetColor();
            } 

            // Ask users name and greet
            static void GreetUser()
            {
                Console.WriteLine("What is your name?");
                string inputName = Console.ReadLine();
                Console.WriteLine("Hello {0}", inputName);
            } 

            // Print Colour message
            static void PrintColourMessage(ConsoleColor color, string message)
            {
                // Change text colour
                Console.ForegroundColor = color;

                Console.WriteLine(message);
                Console.ResetColor();
            } 

            // Guessing the number game
            static void NumberGuessingGame()
            {
                while (true)
                {
                    // Create a new Random object
                    Random random = new Random();

                    int correctNumber = random.Next(1, 10);
                    int guess = 0;
                    int NumberOfGuesses = 3;

                    Console.WriteLine("Guess a number between 1 and 10");

                    while (guess != correctNumber)
                    {
                        // Get users input
                        string input = Console.ReadLine();

                        if (NumberOfGuesses == 0)
                        {
                            Console.WriteLine("Out of guesses");
                            PlayAgain();
                        } // End of if statement
                        else if (guess <= 0 || guess > 10)
                        {
                            PrintColourMessage(ConsoleColor.Red, "Please enter a number betweenn 1 and 10"); // Prompts user foe valid input
                            continue;
                        }
                        else if (!int.TryParse(input, out guess)) // checks if input is a number
                        {
                            PrintColourMessage(ConsoleColor.Red, "Please enter an actual number"); // Prompts user for valid input
                            continue;
                        }
                        guess = Int32.Parse(input);
                        if (guess != correctNumber)
                            PrintColourMessage(ConsoleColor.Red, "Wrong number, try again");
                        NumberOfGuesses--;
                    } 
                    PrintColourMessage(ConsoleColor.Green, "Correct, you guessed it");  // Output success message
                    Console.WriteLine("Play again? [Y or N]");
                    string answer = Console.ReadLine().ToUpper();
                    answer == "Y" ? NumberGuessingGame(); : Menu();
                }
            } 

            // Guessing the number game 2
            static void NumberGuessingGameTwo()
            {
                while (true)
                {
                    // Create a new Random object
                    Random random = new Random();

                    int correctNumber = random.Next(1, 50);
                    int guess = 0;
                    int NumberOfGuesses = 5;

                    // Ask user for number
                    Console.WriteLine("Guess a number between 1 and 50, I'll give you some clues");

                    while (guess != correctNumber)
                    {
                        // Get users input
                        string input = Console.ReadLine();

                        if (NumberOfGuesses == 0) // When user has no guesses left
                        {
                            Console.WriteLine("Out of guesses");
                            PlayAgain();
                        }
                        if (!int.TryParse(input, out guess)) // Checks input is an actual number
                        {
                            PrintColourMessage(ConsoleColor.Red, "Please enter an actual number"); // Prompts user for valid input
                            continue;
                        }
                        else if (guess <= 0 || guess > 50) // Checks input is between 1 and 50
                        {
                            PrintColourMessage(ConsoleColor.Red, "Please enter a number between1 and 50"); // Prompts user for valid input
                            continue;
                        }
                        guess = Int32.Parse(input); // Converts input to int
                        if (guess <= correctNumber)
                        {
                            PrintColourMessage(ConsoleColor.Blue, "The correct number is higher");
                            NumberOfGuesses--;
                        }
                        else if (guess >= correctNumber)
                        {
                            PrintColourMessage(ConsoleColor.Blue, "The correct number is lower");
                            NumberOfGuesses--;
                        }
                        else
                        {
                            PrintColourMessage(ConsoleColor.Green, "Correct, you guessed it"); // Output success message
                            Console.WriteLine("Play again? [Y or N]");
                            string answer = Console.ReadLine().ToUpper();
                            answer == "Y" ? NumberGuessingGameTwo(); : Menu();            
                        } 
                    } 
                } 
            } 

            // Fortune Teller
            static void FortuneTeller()
            {
                while (true)
                {
                    int num = 0;
                    try // Checks if input number is actually a number
                    {
                        // Gets a number from user
                        Console.Write("Write a number between 1 and 10: ");
                        num = Convert.ToInt32(Console.ReadLine());
                        if (num > 10 || num < 1) ; // Checks if number is between 1 and 10
                        {
                            throw new Exception("Number must be between 1 and 10"));
                        }
                    }
                    catch (FormatException)
                    {
                        PrintColourMessage(ConsoleColor.Red, "Please enter an actual number"); // Prompts user for valid input
                        continue;
                    }

                    // Gets colour from user
                    Console.Write("Write a colour: ");
                    int length = 0;
                    string colour = Console.ReadLine();
                    length = colour.Length; // Gets the length of the colour

                    // Determines output depending on sum of num and length
                    if (num + length <= 5)
                    {
                        Console.WriteLine("1");
                        PlayAgain();
                    }
                    else if (num + length <= 10 && num + length > 5)
                    {
                        Console.WriteLine("2");
                        break;
                    }
                    else if (num + length <= 12 && num + length > 10)
                    {
                        Console.WriteLine("3");
                        break;
                    }
                    else if (num + length <= 15 && num + length > 12)
                    {
                        Console.WriteLine("4");
                        break;
                    }
            Console.WriteLine("Play again? [Y or N]");
            string answer = Console.ReadLine().ToUpper();
            answer == "Y" ? FortuneTeller(); : Menu();
        }
            } 
        } // End of Main
    }    // End of class
} // End of application
