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
            HauntedHouse house = new HauntedHouse("The Screaming Oaks");
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
                    ShowRooms(house, investigator);
                    break;
                case 2:
                    house.EndInvestigation(investigator);
                    break;
                default:
                    Console.WriteLine("Invalid number.");
                    break;
            }
        }

        static void ShowRooms(HauntedHouse house, Investigator investigator)
        {
            while (!house.IsGameOver(investigator))
            {
                investigator.ShowStatus();

                bool isValid;
                int choice;

                do
                {
                    Console.WriteLine("Choose an action:");
                    Console.WriteLine("1. Move to Room");
                    Console.WriteLine("2. View Inventory");
                    Console.WriteLine("3. View Evidence");

                    isValid = int.TryParse(Console.ReadLine(), out choice)
                        && choice >= 1
                        && choice <= 3;
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
                        MoveToRoom(house, investigator);
                        break;

                    case 2:
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        investigator.ShowInventory();
                        Console.ResetColor();
                        break;

                    case 3:
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        investigator.ShowEvidence();
                        Console.ResetColor();
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

            house.EndInvestigation(investigator);
        }

        static void MoveToRoom(HauntedHouse house, Investigator investigator)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Rooms in {house.Name}:");
            Console.ResetColor();
            Console.WriteLine();

            for (int i = 0; i < house.Rooms.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {house.Rooms[i].Name}");
            }

            Console.WriteLine();
            Console.WriteLine("Choose a room to continue:");
            bool isCorrectRoom = int.TryParse(Console.ReadLine(), out int roomIndex);
            roomIndex--;

            if (isCorrectRoom && roomIndex >= 0 && roomIndex < house.Rooms.Length)
            {
                if (investigator.CurrentRoom == house.Rooms[roomIndex])
                {
                    Console.WriteLine();
                    Console.WriteLine("You are already in this room. Choose another room.");
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
        }
    }
}
