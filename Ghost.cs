namespace ParanormalEscapeMission
{
    public class Ghost
    {
        public string Name { get; set; }
        public int ScareLevel { get; set; }
        public enum BehaviorType { Passive, Aggressive, Violent };
        public BehaviorType Behavior { get; set; }
        public Ghost(string name, int scareLevel, BehaviorType behavior)
        {
            Name = name;
            ScareLevel = scareLevel;
            Behavior = behavior;
        }

        public void Appear()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Name} has appeared!");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void Scare(Investigator investigator)
        {
            investigator.SanityLevel -= GiveDamage();
            //ScareLevel = GiveDamage();
            Console.WriteLine($"You have lost {GiveDamage()} sanity points.");
            Console.WriteLine();
        }

        public void GetDescription()
        {
            Console.WriteLine($"Ghost Name: {Name}; Scare Level: {GiveDamage()}; Behavior: {Behavior}.");
            Console.WriteLine();
        }

        // Increase Ghost damage to sanity points
        private int GiveDamage()
        {
            switch (Behavior)
            {
                case BehaviorType.Passive:
                    return ScareLevel * 1;

                case BehaviorType.Aggressive:
                    return ScareLevel * 2;

                case BehaviorType.Violent:
                    return ScareLevel * 3;

                default:
                    return ScareLevel;
            }
        }
    }
}
