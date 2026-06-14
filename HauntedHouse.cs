namespace ParanormalEscapeMission
{
    public class HauntedHouse
    {
        private const int REQUIRED_CREDIBILITY = 150;
        private const int ROOM_COUNT = 6;
        private const int STARTING_SANITY = 100;
        private readonly string[] RoomNames = new string[ROOM_COUNT] { "Entrance", "Library", "Kitchen", "Basement", "Attic", "Bedroom" };
        public string Name { get; set; }
        public Room[] Rooms { get; }

        public HauntedHouse(string name)
        {
            Name = name;
            Rooms = new Room[]
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
            return investigator.GetTotalCredibility() < REQUIRED_CREDIBILITY && investigator.SanityLevel > 0;
        }
        public void StartInvestigation(Investigator investigator)
        {
            // Reset investigator state
            investigator.SanityLevel = STARTING_SANITY;
            investigator.Items.Clear();
            investigator.EvidenceCollected.Clear();

            // Put things in the rooms
            Rooms[1].Evidence = new Evidence("Cold Spot Readings", "Sudden drop in temperature detected in the library.", 70);

            Rooms[2].Item = new Item("EMF Reader", "Detect electromagnetic fluctuatins caused by paranormal activity.", 15);

            Rooms[3].Ghost = new Ghost("Pascal", 20, Ghost.BehaviorType.Passive);

            Rooms[4].Ghost = new Ghost("Jasper", 50, Ghost.BehaviorType.Aggressive);
            Rooms[4].Evidence = new Evidence("EVP Recording", "Audio captured faint whispering voices to questions.", 90);

            // Game Intro
            string welcomeMessage = $"Welcome to {Name}";
            Console.WriteLine("===============================");
            Console.WriteLine(welcomeMessage.ToUpper());
            Console.WriteLine("===============================");
            Console.WriteLine();
            Console.WriteLine($"Collect evidence with a total credibility score of {REQUIRED_CREDIBILITY} score or higher to escape.");
        }

        public void EndInvestigation(Investigator investigator)
        {
            string result = "";

            if (investigator.GetTotalCredibility() >= REQUIRED_CREDIBILITY && investigator.SanityLevel > 0)
            {
                result = "You have won the game.";
            }
            else
            {
                result = "You have lost the game.";
            }

            Console.WriteLine("====================");
            Console.WriteLine("FINAL REPORT");
            Console.WriteLine("====================");

            Console.WriteLine();
            Console.WriteLine(result);
            Console.WriteLine();

            Console.WriteLine("Items Collected:");
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

            Console.WriteLine();
            Console.WriteLine("Evidence Discovered:");
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
            Console.WriteLine($"Sanity Level: {investigator.SanityLevel}.");

            Console.WriteLine();
            Console.WriteLine($"Evidence Credibility Score: {investigator.GetTotalCredibility()}.");

            Console.WriteLine();
        }
    }
}
