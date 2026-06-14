namespace ParanormalEscapeMission
{
    public class Investigator
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }
        public List<Evidence> EvidenceCollected { get; set; }
        public int SanityLevel { get; set; }
        public Room CurrentRoom { get; set; }
        public Investigator(string name, Room room, int sanityLevel)
        {
            Name = name;
            CurrentRoom = room;
            SanityLevel = sanityLevel;
            Items = new List<Item>();
            EvidenceCollected = new List<Evidence>();
        }
        public int GetTotalCredibility()
        {
            int total = 0;
            foreach (Evidence evidence in EvidenceCollected)
            {
                total += evidence.CredibilityScore;
            }
            return total;
        }
        public void MoveToRoom(Room room)
        {
            CurrentRoom = room;
            room.ShowRoomInfo();
        }
        public void ShowStatus()
        {
            Console.WriteLine($"Investigator: {Name}");
            Console.WriteLine($"Current Room: {CurrentRoom.Name}");
            Console.WriteLine($"Sanity: {SanityLevel}");
            Console.WriteLine($"Credibility Score: {GetTotalCredibility()}");
            Console.WriteLine();
        }
        public void ShowInventory()
        {
            Console.WriteLine("Currently in your inventory:");
            Console.WriteLine();

            if (Items.Count > 0)
            {
                foreach (Item item in Items)
                {
                    item.ShowDetails();
                }
            }
            else
            {
                Console.WriteLine("Inventory is currently empty");
            }
        }
        public void ShowEvidence()
        {
            Console.WriteLine("Evidence discovered so far:");
            Console.WriteLine();

            if (EvidenceCollected.Count > 0)
            {
                foreach (Evidence e in EvidenceCollected)
                {
                    e.ShowDetails();
                }
            }
            else
            {
                Console.WriteLine("No evidence collected so far");
            }
            Console.WriteLine();
            Console.WriteLine($"Total Credibility Score: {GetTotalCredibility()}");
            Console.WriteLine();
        }
    }
}
