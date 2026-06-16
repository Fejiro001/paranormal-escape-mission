namespace ParanormalEscapeMission
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            bool running = true;

            while (running)
            {
                HauntedHouse house = new HauntedHouse("The Screaming Oaks Manor");
                Investigator investigator = new Investigator("Stephanie Jones", house.Rooms[0], 100);

                house.StartInvestigation(investigator);
                Console.WriteLine("The entrance feels strangely calm...");
                Console.WriteLine();

                bool isCorrect;
                int startIndex;
                do
                {
                    Console.WriteLine("Start Game?");
                    Console.WriteLine("1. Start Exploring");
                    Console.WriteLine("2. Exit");

                    isCorrect = int.TryParse(Console.ReadLine(), out startIndex)
                        && startIndex >= 1
                        && startIndex <= 2;
                    Console.WriteLine();

                    if (!isCorrect)
                    {
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine();
                    }
                }
                while (!isCorrect);

                switch (startIndex)
                {
                    case 1:
                        MainMenu(house, investigator);
                        break;
                    case 2:
                        running = EndGame();
                        break;
                    default:
                        Console.WriteLine("Invalid number.");
                        break;
                }

                // Don't show menu if game is over
                if (house.IsGameOver(investigator)) { running = false; }
            }
        }

        static void MainMenu(HauntedHouse house, Investigator investigator)
        {
            while (!house.IsGameOver(investigator))
            {
                bool isValid;
                int choice;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose an action:");
                    Console.WriteLine("1. Move to Room");
                    Console.WriteLine("2. View Inventory");
                    Console.WriteLine("3. View Evidence");

                    isValid = int.TryParse(Console.ReadLine(), out choice)
                        && choice >= 1
                        && choice <= 4;
                    Console.WriteLine();

                    if (!isValid)
                    {
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine();
                    }
                }
                while (!isValid);

                switch (choice)
                {
                    case 1:
                        ShowRooms(house, investigator);
                        break;
                    case 2:
                        investigator.ShowInventory();
                        break;
                    case 3:
                        investigator.ShowEvidence();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void ShowRooms(HauntedHouse house, Investigator investigator)
        {
            bool showRoomsList = true;
            while (showRoomsList)
            {
                investigator.ShowStatus();

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Rooms in {house.Name}:");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("0. Return to Main Menu");
                for (int i = 0; i < house.Rooms.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {house.Rooms[i].Name}");
                }
                Console.WriteLine();

                Console.WriteLine("Choose a room to continue:");

                bool isCorrectRoom = int.TryParse(Console.ReadLine(), out int roomIndex);

                if (roomIndex == 0)
                {
                    // Go back to the main menu
                    showRoomsList = false;
                    break;
                }

                // Make 0-based index
                roomIndex--;

                if (isCorrectRoom && roomIndex >= 0 && roomIndex < house.Rooms.Length)
                {
                    // Check if the Investigator is already in the room
                    if (investigator.CurrentRoom == house.Rooms[roomIndex])
                    {
                        Console.WriteLine();
                        Console.WriteLine("You are already here. Choose another room.");
                        Console.WriteLine();
                    }
                    else
                    {
                        investigator.MoveToRoom(house.Rooms[roomIndex]);
                        house.Rooms[roomIndex].SearchRoom(investigator);
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter a valid number.");
                }

                // Stop showing rooms list if game is over
                if (house.IsGameOver(investigator))
                {
                    showRoomsList = false;
                    house.EndInvestigation(investigator);
                }
            }
        }

        // Prompt to confirm game exit
        static bool EndGame()
        {
            bool choiceCorrect;
            int choice;
            do
            {
                Console.WriteLine("Are you sure you want to leave?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                choiceCorrect = int.TryParse(Console.ReadLine(), out choice)
                    && choice >= 1
                    && choice <= 2;
            }
            while (!choiceCorrect);

            if (choice == 1) return false;

            return true;
        }
    }
}
