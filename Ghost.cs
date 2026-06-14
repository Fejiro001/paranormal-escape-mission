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
            Console.WriteLine($"{Name} has appeared!");
            Console.WriteLine();
        }

        public void Scare(Investigator investigator)
        {
            investigator.SanityLevel -= GiveDamage();
            Console.WriteLine($"You have lost {ScareLevel} sanity points.");
            Console.WriteLine();
        }

        public void GetDescription()
        {
            Console.WriteLine($"Ghost Name: {Name}; Scare Level: {ScareLevel}; Behavior: {Behavior}.");
            Console.WriteLine();
        }

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
