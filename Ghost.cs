namespace ParanormalEscapeMission
{
    public class Ghost
    {
        public string Name { get; set; }
        public int ScareLevel { get; set; }
        public enum BehaviorType { Passive, Aggressive, Violent };
        private BehaviorType Behavior { get; set; }
        public Ghost(string name, int scareLevel, BehaviorType behavior)
        {
            Name = name;
            ScareLevel = scareLevel;
            Behavior = behavior;
        }
        public void Appear()
        {
            Console.WriteLine($"{Name} has appeared!");
        }
        public void Scare(Investigator investigator)
        {
            investigator.SanityLevel -= GiveDamage();
        }
        public string GetDescription()
        {
            return $"Ghost Name: {Name}; Scare Level: {ScareLevel}; Behavior: {Behavior}.";
        }
        public int GiveDamage()
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
