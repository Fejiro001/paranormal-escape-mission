namespace ParanormalEscapeMission
{
    public class HauntedHouse
    {
        private const int REQUIRED_CREDIBILITY = 150;
        private const int ROOM_COUNT = 6;
        private const int STARTING_SANITY = 100;
        private static readonly Random _rng = new Random();
        private readonly string[] RoomNames = new string[ROOM_COUNT] { "Entrance", "Library", "Kitchen", "Basement", "Attic", "Bedroom" };

        public string Name { get; set; }
        public Room[] Rooms { get; private set; }
        public HauntedHouse(string name)
        {
            Name = name;
            Rooms = new Room[ROOM_COUNT]
            {
                new Room(RoomNames[0]),
                new Room(RoomNames[1]),
                new Room(RoomNames[2]),
                new Room(RoomNames[3]),
                new Room(RoomNames[4]),
                new Room(RoomNames[5])
            };
        }

        public bool IsGameOver(Investigator investigator)
        {
            return investigator.GetTotalCredibility() >= REQUIRED_CREDIBILITY || investigator.SanityLevel <= 0;
        }

        private int GetRandomRoomIndex()
        {
            return _rng.Next(1, ROOM_COUNT);
        }

        public void CreateRooms()
        {
            // Clear all rooms
            foreach (var room in Rooms)
            {
                room.Ghost = null;
                room.Item = null;
                room.Evidence = null;
            }

            int room1 = GetRandomRoomIndex();
            Rooms[room1].Evidence = new Evidence("Cold Spot Readings", "Sudden drop in temperature detected in the library.", 60);
            Rooms[room1].Ghost = new Ghost("Blade", 5, Ghost.BehaviorType.Passive);

            int room2;
            do { room2 = GetRandomRoomIndex(); }
            while (room1 == room2);
            Rooms[room2].Item = new Item("EMF Reader", "Detect electromagnetic fluctuations caused by paranormal activity.", 20);

            int room3;
            do { room3 = GetRandomRoomIndex(); }
            while (room3 == room1 || room3 == room2);
            Rooms[room3].Ghost = new Ghost("Pascal", 10, Ghost.BehaviorType.Aggressive);

            int room4;
            do { room4 = GetRandomRoomIndex(); }
            while (room4 == room1 || room4 == room2 || room4 == room3);
            Rooms[room4].Ghost = new Ghost("Jasper", 20, Ghost.BehaviorType.Violent);
            Rooms[room4].Evidence = new Evidence("EVP Recording", "Audio captured faint whispering voices to questions.", 90);
        }

        public void StartInvestigation(Investigator investigator)
        {
            // Reset investigator state
            investigator.SanityLevel = STARTING_SANITY;
            investigator.Items.Clear();
            investigator.EvidenceCollected.Clear();

            CreateRooms();

            // Game Intro
            string welcomeMessage = $"Welcome to {Name}";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("===============================");
            Console.WriteLine(welcomeMessage.ToUpper());
            Console.WriteLine("===============================");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Collect evidence with a total credibility score of {REQUIRED_CREDIBILITY} score or higher to escape.");
            Console.WriteLine();
        }

        public void EndInvestigation(Investigator investigator)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("====================");
            Console.WriteLine("FINAL REPORT");
            Console.WriteLine("====================");
            Console.ResetColor();

            Console.WriteLine();
            if (investigator.GetTotalCredibility() >= REQUIRED_CREDIBILITY && investigator.SanityLevel > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have won the game.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have lost the game.");
            }
            Console.ResetColor();
            Console.WriteLine();

            // All Items Collected
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Items Collected:");
            Console.ResetColor();

            if (investigator.Items.Count > 0)
            {
                foreach (Item item in investigator.Items)
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }
            else
            {
                Console.WriteLine("No items collected.");
            }

            // All Evidence Collected
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Evidence Discovered:");
            Console.ResetColor();

            if (investigator.EvidenceCollected.Count > 0)
            {
                foreach (Evidence evidence in investigator.EvidenceCollected)
                {
                    Console.WriteLine($"- {evidence.Name}");
                }
            }
            else
            {
                Console.WriteLine("No evidence discovered.");
            }

            Console.WriteLine();
            Console.WriteLine($"Final Sanity Level: {investigator.SanityLevel}.");

            Console.WriteLine();
            Console.WriteLine($"Evidence Credibility Score: {investigator.GetTotalCredibility()}.");
            Console.WriteLine();
        }
    }
}
