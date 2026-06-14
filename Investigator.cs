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
            Items = new List<Item>();
            EvidenceCollected = new List<Evidence>();
            SanityLevel = sanityLevel;
            CurrentRoom = room;
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
        public void SearchRoom(Room room)
        {
            
        }
        public void CollectEvidence()
        {

        }
        public void PickupItem()
        {

        }
        public void ShowInventory()
        {

        }
        public void ShowEvidence()
        {

        }
        public void ReduceSanity()
        {

        }
    }
}
