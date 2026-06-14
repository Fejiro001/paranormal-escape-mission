namespace ParanormalEscapeMission
{
    public class Room
    {
        public string Name { get; set; }
        public Ghost Ghost { get; set; }
        public Item? Item { get; set; }
        public Evidence? Evidence { get; set; }
        public Room(string name)
        {
            Name = name;
        }
        public void SearchRoom(Investigator investigator)
        {
            bool foundSomething = false;
            if (Ghost != null)
            {
                foundSomething = true;
                Ghost.Appear();
                Ghost.Scare(investigator);
            }

            if (Evidence != null)
            {
                foundSomething = true;
                investigator.EvidenceCollected.Add(Evidence);
                Console.WriteLine($"Evidence discovered: {Evidence.Name}!");
                // Remove evidence from room
                Evidence = null;
            }

            if (Item != null)
            {
                foundSomething = true;
                investigator.Items.Add(Item);
                Console.WriteLine($"You found: {Item.Name}!");
                // Remove item from room
                Item = null;
            }

            if (!foundSomething)
            {
                Console.WriteLine("Nothing found here!");
            }
        }
        public void ShowRoomInfo()
        {
            Console.WriteLine($"You are in the {Name}");
            if (Ghost != null)
            {
                Console.WriteLine("Something feels off...");
            }
        }
    }
}
