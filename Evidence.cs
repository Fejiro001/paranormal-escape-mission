namespace ParanormalEscapeMission
{
    public class Evidence
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CredibilityScore { get; set; }
        public Evidence(string name, string description, int credibilityScore)
        {
            Name = name;
            Description = description;
            CredibilityScore = credibilityScore;
        }

        public void ShowDetails()
        {
            Console.WriteLine("Evidence Information:");
            Console.WriteLine($"- Name: {Name}");
            Console.WriteLine($"- Description: {Description}");
            Console.WriteLine($"- Credibility Score: {CredibilityScore}");
        }
    }
}
