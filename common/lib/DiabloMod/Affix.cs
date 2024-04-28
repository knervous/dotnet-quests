namespace Common.DiabloMod
{
    public class Affix
    {
        public string Name { get; init; }
        public int MinLevel { get; init; }
        public int Weight {get; init; }
        public List<ComputedModProp> Props { get; init; }
        public Affix(string Name, int MinLevel, List<ModProps> ModProps, int Weight = 1)
        {
            this.Name = Name;
            this.MinLevel = MinLevel;
            this.Weight = Weight;
            Props = [];
            foreach (var p in ModProps)
            {
                Props.Add(new ComputedModProp(p.Prop, Math.Round(DiabloMod.Rand.NextDouble() * (p.High - p.Low) + p.Low, 2), p.Op));
            }
        }

        public Affix()
        {
            Name = "";
            Props = [];
            Weight = 1;
        }
    };

    public class Affixes
    {
        protected static List<ModProps> CreateMods(params ModProps[] mods)
        {
            return new List<ModProps>(mods);
        }

        public static Affix? GetPrefix(List<Affix> affixes, int minLevel)
        {
            var validPrefixes = affixes.Where(p => minLevel >= p.MinLevel).ToList();

            if (validPrefixes.Count == 0)
            {
                return null;
            }
            var weightedListItems = new WeightedList<Affix>(
                validPrefixes.Select(p => new WeightedListItem<Affix>(p, p.Weight)).ToList());
            return weightedListItems.Next();
        }

        public static Affix? GetSuffix(List<Affix> affixes, int minLevel)
        {
            var validSuffixes = affixes.Where(p => minLevel >= p.MinLevel).ToList();

            if (validSuffixes.Count == 0)
            {
                return null;
            }

            var weightedListItems = new WeightedList<Affix>(
                validSuffixes.Select(p => new WeightedListItem<Affix>(p, p.Weight)).ToList());
            return weightedListItems.Next();
        }
    }
}