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

            Console.WriteLine("Start Game?");
            Console.WriteLine("1. Start Exploring");
            Console.WriteLine("2. Exit");

            bool isCorrect = int.TryParse(Console.ReadLine(), out int startIndex);
            Console.WriteLine();

            do
            {
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
            } while (!isCorrect && startIndex < 1 && startIndex > 2);
        }
        static void ShowRooms(HauntedHouse house, Investigator investigator)
        {
            bool gameRunning = house.IsGameOver(investigator);
            while (gameRunning)
            {
                investigator.ShowStatus();

                Console.WriteLine($"Rooms in {house.Name}:");
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
                        Console.WriteLine("You are already in this room. Choose another room.");
                        Console.WriteLine();
                    }
                    else
                    {
                        investigator.MoveToRoom(house.Rooms[roomIndex]);
                        house.Rooms[roomIndex].SearchRoom(investigator);
                    }
                }
            }
        }
    }
}
