namespace ParanormalEscapeMission
{
    public class Room
    {
        public string Name { get; set; }
        public Ghost? Ghost { get; set; }
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
                Ghost.GetDescription();
            }

            if (Evidence != null)
            {
                foundSomething = true;
                investigator.EvidenceCollected.Add(Evidence);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Evidence discovered: {Evidence.Name}!");
                Console.WriteLine($"You have gained {Evidence.CredibilityScore} credibility score.");
                Console.ResetColor();
                Console.WriteLine("---------------------------------------------------");
                Evidence.ShowDetails();
                Console.WriteLine("---------------------------------------------------");
                // Remove evidence from room
                Evidence = null;
            }

            if (Item != null)
            {
                foundSomething = true;
                investigator.Items.Add(Item);
                Item.UseItem(investigator);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"You found an Item: {Item.Name}!");
                Console.WriteLine($"You have gained {Item.EffectStrength} sanity points.");
                Console.ResetColor();
                Console.WriteLine("---------------------------------------------------");
                Item.ShowDetails();
                Console.WriteLine("---------------------------------------------------");
                // Remove item from room
                Item = null;
            }

            if (!foundSomething)
            {
                Console.WriteLine("Nothing found here!");
            }

            // Added a small break before the menu is shown
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("PRESS \"ENTER\" TO CONTINUE");
            Console.ResetColor();
            Console.ReadLine();
            Console.WriteLine();
        }

        public void ShowRoomInfo()
        {
            Console.WriteLine($"You are in the {Name}.");
            Console.WriteLine();
            if (Ghost != null)
            {
                Console.WriteLine("Something feels off...");
            }
        }
    }
}
