using System;
using System.IO;
using System.Text;

namespace Airplanes.txt
{
    public class Program
    {
        static double costFC;
        static double costSC;
        static int distance;
        static int NoOfSCSeats;
        static int maxFlightRange;
        static int SCCapacity = 0;
        static int minNoOfFCSeats = 0;
        static int NoOfFCSeats = 0;
        static string selection = "";
        static string airCodeUK = "";
        static string airCodeOverSeas = "";
        static bool notOverSeas = true;
        static String[,] allLinesAndVar = new String[10, 10];
        static int airportIndex = 0;
        static string[,] planeType = { { "8", "2650", "180", "8" }, { "7", "5600", "220", "10" }, { "5", "4050", "406", "14" } };
        static string FlightSelection = "";
        static float flightCostPerSeat;

        static void Main()
        {
            // CSV file
            string[] allLines = new string[50];
            int lineCount = 0;

            //this code loads a text file
            using (StreamWriter sw = new StreamWriter(@"Airplanes.txt"))
            {
                sw.WriteLine("JFK, John F Kennedy International, 5326, 5486");
                sw.WriteLine("ORY, Paris-Orly, 629, 379");
                sw.WriteLine("MAD, Adolfo Suarez Madrid-Barajas, 1428, 1151");
                sw.WriteLine("AMS, Amsterdam Schiphol, 526, 489");
                sw.WriteLine("CAI, Cairo International, 3779, 3584");
            }

            // Open the stream read and read it back
            using (StreamReader sr = File.OpenText("Airplanes.txt"))
            {
                string s = "";
                lineCount = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    allLines[lineCount] = s;
                    lineCount++;
                }
            }

            for (int i = 0; i <= 4; i++)
            {
                String[] tempArray = allLines[i].Split(',');
                for (int j = 0; j < tempArray.Length; j++)
                {
                    allLinesAndVar[i, j] = tempArray[j];
                }
            }
            Menu();
        } // end of Main


        static void Menu() // Menu
        {
            do
            {
                Message(ConsoleColor.Blue, "**********");
                Message(ConsoleColor.Blue, "Main Menu");
                Message(ConsoleColor.Blue, "**********");
                Message(ConsoleColor.Blue, "1: Enter airport details");
                Message(ConsoleColor.Blue, "2: Enter flight details");
                Message(ConsoleColor.Blue, "3: Enter price plan and calculate profit");
                Message(ConsoleColor.Blue, "4: Clear data");
                Message(ConsoleColor.Blue, "5: Quit");
                Message(ConsoleColor.Blue, "Please select an option: ");
                selection = Console.ReadLine();

                if (selection == "1") AirportDetails();
                else if (selection == "2") FlightDetails();
                else if (selection == "3") PricePlanAndCalculateProfit();
                else if (selection == "4") Console.Clear();
                else if (selection == "5")
                {
                    Console.WriteLine("You have quit the program");
                    System.Environment.Exit(1);
                }
                else
                {
                    Message(ConsoleColor.Red, "Invalid selection");
                    Menu();
                    continue;
                }
            } while (selection == "");
        } // end of Menu

        public static void AirportDetails() // Airport details
        {
            Console.WriteLine("Airport Details");
            Console.WriteLine("***************");
            Console.Write("Enter 3 letter airport code for UK airport: ");
            airCodeUK = Console.ReadLine();

            if (airCodeUK != "LPL" && airCodeUK != "BOH")
            {
                Message(ConsoleColor.Red, "Invalid airport");
                Menu();
            }
            else
            {
                Console.Write("Enter 3 letter code for overseas airport: ");
                airCodeOverSeas = Console.ReadLine();
                for (int i = 0; i < 5; i++)
                {
                    if (allLinesAndVar[i, 0] == airCodeOverSeas)
                    {
                        notOverSeas = false;
                        airportIndex = i;
                    }
                }
                if (notOverSeas)
                {
                    Message(ConsoleColor.Red, "Invalid airport");
                }
                else
                {
                    Console.WriteLine(allLinesAndVar[airportIndex, 1]);
                    if (airCodeUK == "LPL")
                    {
                        distance = Convert.ToInt32(allLinesAndVar[airportIndex, 2]);
                    }
                    else
                    {
                        distance = Convert.ToInt32(allLinesAndVar[airportIndex, 3]);
                    }
                }
            }
            Menu();
        } // end of Airport Details

        public static void FlightDetails() // Flight Details
        {
            Console.WriteLine("\nFlight Details"); // Flight details
            Console.WriteLine("**************");
            Console.WriteLine("1: Medium narrow body \n2: Large narrow body " + "\n3: Medium wide body");
            Console.Write("Enter type of aircraft: ");
            FlightSelection = Console.ReadLine();

            switch (FlightSelection)
            {
                case "1":
                    Console.WriteLine("\nMedium narrow body: \nRunning cost per 100km: £" + planeType[0, 0] + "\nMaximum flight range: " + planeType[0, 1] + "km\nCapacity if all seats are standard class: " + planeType[0, 2] + "\nMinimum number of first-class seats (if there are any): " + planeType[0, 3]);
                    // capacity
                    minNoOfFCSeats = Convert.ToInt32(planeType[0, 3]);
                    SCCapacity = Convert.ToInt32(planeType[0, 2]);
                    maxFlightRange = Convert.ToInt32(planeType[0, 1]);
                    flightCostPerSeat = (float.Parse(planeType[0, 0]) * distance) / 100;
                    chooseNumberOfFCSeats();
                    break;
                case "2":
                    Console.WriteLine("\nLarge narrow body: \nRunning cost per 100km: £" + planeType[1, 0] + "\nMaximum flight range: " + planeType[1, 1] + "km\nCapacity if all seats are standard class: " + planeType[1, 2] + "\nMinimum number of first-class seats (if there are any): " + planeType[1, 3]);
                    // capacity
                    minNoOfFCSeats = Convert.ToInt32(planeType[1, 3]);
                    SCCapacity = Convert.ToInt32(planeType[1, 2]);
                    maxFlightRange = Convert.ToInt32(planeType[1, 1]);
                    flightCostPerSeat = (float.Parse(planeType[1, 0]) * distance) / 100;
                    chooseNumberOfFCSeats();
                    break;
                case "3":
                    Console.WriteLine("\nMedium wide body: \nRunning cost per 100km: £" + planeType[2, 0] + "\nMaximum flight range: " + planeType[2, 1] + "km\nCapacity if all seats are standard class: " + planeType[2, 2] + "\nMinimum number of first-class seats (if there are any): " + planeType[2, 3]);
                    // capacity
                    minNoOfFCSeats = Convert.ToInt32(planeType[2, 3]);
                    SCCapacity = Convert.ToInt32(planeType[2, 2]);
                    maxFlightRange = Convert.ToInt32(planeType[2, 1]);
                    flightCostPerSeat = (float.Parse(planeType[2, 0]) * distance) / 100;
                    chooseNumberOfFCSeats();
                    break;
                default:
                    Message(ConsoleColor.Red, "Invalid selection");
                    Menu();
                    break;
            }
        } // end of flight details

        public static void chooseNumberOfFCSeats()
        {
            Console.Write("Enter number of first class seats: ");
            NoOfFCSeats = int.Parse(Console.ReadLine());
            if (NoOfFCSeats != 0)
            {
                if (NoOfFCSeats < minNoOfFCSeats)
                {
                    Message(ConsoleColor.Red, "Sorry, you must have a minimum of " + minNoOfFCSeats + " first call seats"); ;
                    Menu();
                }
                if (NoOfFCSeats > (SCCapacity / 2))
                {
                    Message(ConsoleColor.Red, "Sorry, you have selected too many first class seats");
                    Menu();
                }
                NoOfSCSeats = SCCapacity - NoOfFCSeats * 2;
                Menu();
            }
        } // end of choose number of seats

        public static void PricePlanAndCalculateProfit() // Price Plan
        {
            Console.WriteLine("Price plan and Profit");
            Console.WriteLine("**********");
            if (airCodeUK == "" || airCodeOverSeas == "")
            {
                Message(ConsoleColor.Red, "Please add airports");
                Menu();
            }
            else if (FlightSelection == "")
            {
                Message(ConsoleColor.Red, "Please choose an aircraft");
                Menu();
            }
            else if (NoOfSCSeats <= 0)
            {
                Message(ConsoleColor.Red, "Please choose number of seats");
                Menu();
            }
            else if (maxFlightRange < distance)
            {
                Message(ConsoleColor.Red, "The plane cannot fly that far");
                Menu();
            }
            else
            {
                Console.WriteLine("Enter the cost of a First Class Seat");
                int priceOfFCSeat = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the cost of a Standard Class Seat");
                int priceOfScSeat = int.Parse(Console.ReadLine());
                float flightCost = flightCostPerSeat * (NoOfFCSeats + NoOfSCSeats);
                float flightIncome = (NoOfFCSeats * priceOfFCSeat) + (NoOfSCSeats * priceOfScSeat);
                float flightProfit = flightIncome - flightCost;
                Message(ConsoleColor.Green, "Flight cost per seat: £" + flightCostPerSeat + "\nFlight cost: £" + flightCost + "\nFlight income: £" + flightIncome + "\nFlight Profit: £" + flightProfit);
                Menu();
            }
        } // end of PricePlanAndCalculateProfit
        static void Message(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        } // end of Message 
    } // end of class
 } // end file