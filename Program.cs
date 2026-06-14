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

            bool gameRunning = house.IsGameOver(investigator);

            while (gameRunning)
            {
                investigator.ShowStatus();

                bool correct;
                int userInput;

                Console.WriteLine($"Rooms in {house.Name}:");
                for (int i = 0; i < house.Rooms.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {house.Rooms[i].Name}");
                }

                Console.WriteLine();
                Console.WriteLine("Choose a room to continue:");
                correct = int.TryParse(Console.ReadLine(), out userInput);
                userInput--;

                if (correct && userInput >= 0 && userInput < house.Rooms.Length)
                {
                    if (investigator.CurrentRoom == house.Rooms[userInput])
                    {
                        Console.WriteLine("You are already in this room. cHoose another room.");
                    }
                    else
                    {
                        investigator.MoveToRoom(house.Rooms[userInput]);
                    }
                }
            }
        }
    }
}
