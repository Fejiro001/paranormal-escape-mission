namespace ParanormalEscapeMission
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EffectStrength { get; set; }
        public Item(string name, string description, int effectStrength)
        {
            Name = name;
            Description = description;
            EffectStrength = effectStrength;
        }
        public void UseItem(Investigator investigator)
        {
            investigator.SanityLevel += EffectStrength;
            if (investigator.SanityLevel > 100)
            {
                investigator.SanityLevel = 100;
            }
        }
        public void ShowDetails()
        {
            Console.WriteLine("Item Information:");
            Console.WriteLine($"- Name: {Name}");
            Console.WriteLine($"- Description: {Description}");
            Console.WriteLine($"- Effect Strength: {EffectStrength}");
        }
    }
}
