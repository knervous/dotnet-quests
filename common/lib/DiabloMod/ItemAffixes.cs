
namespace Common.DiabloMod
{
    public class WeaponAffixes : Affixes
    {
        public static List<Affix> Suffixes = new() {
            // +%Attack speed
            new Affix("Readiness", 5, CreateMods(new ModProps(ItemDataProperty.Delay, .9, .9, ModOperation.MULT))),
            new Affix("Alacrity", 25, CreateMods(new ModProps(ItemDataProperty.Delay, .8, .8, ModOperation.MULT))),
            new Affix("Swiftness", 34, CreateMods(new ModProps(ItemDataProperty.Delay, .7, .7, ModOperation.MULT))),
            new Affix("Quickness", 46, CreateMods(new ModProps(ItemDataProperty.Delay, .6, .6, ModOperation.MULT))),

            // + Damage
            new Affix("Craftsmanship", 5, CreateMods(new ModProps(ItemDataProperty.Damage, 1, 1))),
            new Affix("Quality", 15, CreateMods(new ModProps(ItemDataProperty.Damage, 1, 2))),
            new Affix("Maiming", 25, CreateMods(new ModProps(ItemDataProperty.Damage, 2, 3))),
            new Affix("Slaying", 35, CreateMods(new ModProps(ItemDataProperty.Damage, 4, 5))),
            new Affix("Carnage", 45, CreateMods(new ModProps(ItemDataProperty.Damage, 5, 6))),
            new Affix("Slaughter", 55, CreateMods(new ModProps(ItemDataProperty.Damage, 7, 8))),
        };

        public static List<Affix> Prefixes = new() {

            // +Attack Rating
            new Affix("Bronze", 1, CreateMods(new ModProps(ItemDataProperty.Accuracy, 1, 2))),
            new Affix("Iron", 12, CreateMods(new ModProps(ItemDataProperty.Accuracy, 2, 3))),
            new Affix("Steel", 24, CreateMods(new ModProps(ItemDataProperty.Accuracy, 3, 4))),
            new Affix("Silver", 32, CreateMods(new ModProps(ItemDataProperty.Accuracy, 3, 4))),
            new Affix("Gold", 40, CreateMods(new ModProps(ItemDataProperty.Accuracy, 4, 5))),
            new Affix("Platinum", 50, CreateMods(new ModProps(ItemDataProperty.Accuracy, 5, 7))),

            // +%Enhanced Damage
            new Affix("Jagged", 1, CreateMods(new ModProps(ItemDataProperty.Damage, 1.05, 1.1, ModOperation.MULT))),
            new Affix("Deadly", 5, CreateMods(new ModProps(ItemDataProperty.Damage, 1.1, 1.15, ModOperation.MULT))),
            new Affix("Vicious", 8, CreateMods(new ModProps(ItemDataProperty.Damage, 1.15, 1.2, ModOperation.MULT))),
            new Affix("Brutal", 14, CreateMods(new ModProps(ItemDataProperty.Damage, 1.25, 1.3, ModOperation.MULT))),
            new Affix("Massive", 20, CreateMods(new ModProps(ItemDataProperty.Damage, 1.35, 1.4, ModOperation.MULT))),
            new Affix("Savage", 26, CreateMods(new ModProps(ItemDataProperty.Damage, 1.4, 1.5, ModOperation.MULT))),
            new Affix("Merciless", 32, CreateMods(new ModProps(ItemDataProperty.Damage, 1.5, 1.6, ModOperation.MULT))),
            new Affix("Ferocious", 41, CreateMods(new ModProps(ItemDataProperty.Damage, 1.6, 1.7, ModOperation.MULT))),
            new Affix("Cruel", 50, CreateMods(new ModProps(ItemDataProperty.Damage, 1.8, 1.9, ModOperation.MULT))),



            // +Attack Rating and Enhanced Damage
            new Affix("Sharp", 5, CreateMods(
                new ModProps(ItemDataProperty.Accuracy, 1, 1),
                new ModProps(ItemDataProperty.Damage, 1.05, 1.1, ModOperation.MULT)
            )),
            new Affix("Fine", 10, CreateMods(
                new ModProps(ItemDataProperty.Accuracy, 1, 2),
                new ModProps(ItemDataProperty.Damage, 1.1, 1.15, ModOperation.MULT)
            )),
            new Affix("Warrior's", 20, CreateMods(
                new ModProps(ItemDataProperty.Accuracy, 2, 3),
                new ModProps(ItemDataProperty.Damage, 1.15, 1.2, ModOperation.MULT)
            )),
            new Affix("Soldier's", 30, CreateMods(
                new ModProps(ItemDataProperty.Accuracy, 3, 4),
                new ModProps(ItemDataProperty.Damage, 1.2, 1.25, ModOperation.MULT)
            )),
            new Affix("Knight's", 35, CreateMods(
                new ModProps(ItemDataProperty.Accuracy, 4, 5),
                new ModProps(ItemDataProperty.Damage, 1.25, 1.3, ModOperation.MULT)
            )),
            new Affix("Lord's", 40, CreateMods(
                new ModProps(ItemDataProperty.Accuracy, 5, 6),
                new ModProps(ItemDataProperty.Damage, 1.25, 1.3, ModOperation.MULT)
            )),
            new Affix("King's", 50, CreateMods(
                new ModProps(ItemDataProperty.Accuracy, 7, 8),
                new ModProps(ItemDataProperty.Damage, 1.35, 1.5, ModOperation.MULT)
            )),

            // +Elemental Damage
            // Cold
            new Affix("Snowy", 25, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 1, 2), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_COLD, (double)RESISTTYPE.RESIST_COLD))),
            new Affix("Shivering", 35, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 3, 4), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_COLD, (double)RESISTTYPE.RESIST_COLD))),
            new Affix("Boreal", 45, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 4, 5), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_COLD, (double)RESISTTYPE.RESIST_COLD))),
            new Affix("Hibernal", 55, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 5, 6), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_COLD, (double)RESISTTYPE.RESIST_COLD))),
            // Fire
            new Affix("Fiery", 25, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 1, 2), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_FIRE, (double)RESISTTYPE.RESIST_FIRE))),
            new Affix("Smoldering", 35, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 3, 4), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_FIRE, (double)RESISTTYPE.RESIST_FIRE))),
            new Affix("Smoking", 45, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 4, 5), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_FIRE, (double)RESISTTYPE.RESIST_FIRE))),
            new Affix("Flaming", 55, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 5, 6), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_FIRE, (double)RESISTTYPE.RESIST_FIRE))),
            // Magic/Lightning
            new Affix("Static", 25, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 1, 2), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_MAGIC, (double)RESISTTYPE.RESIST_MAGIC))),
            new Affix("Glowing", 35, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 3, 4), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_MAGIC, (double)RESISTTYPE.RESIST_MAGIC))),
            new Affix("Buzzing", 45, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 4, 5), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_MAGIC, (double)RESISTTYPE.RESIST_MAGIC))),
            new Affix("Arcing", 55, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 5, 6), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_MAGIC, (double)RESISTTYPE.RESIST_MAGIC))),
             // Poison
            new Affix("Septic", 25, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 1, 2), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_POISON, (double)RESISTTYPE.RESIST_POISON))),
            new Affix("Foul", 35, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 3, 4), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_POISON, (double)RESISTTYPE.RESIST_POISON))),
            new Affix("Corrosive", 45, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 4, 5), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_POISON, (double)RESISTTYPE.RESIST_POISON))),
            new Affix("Pestilent", 55, CreateMods(new ModProps(ItemDataProperty.ElemDmgAmt, 5, 6), new ModProps(ItemDataProperty.ElemDmgType, (double)RESISTTYPE.RESIST_POISON, (double)RESISTTYPE.RESIST_POISON))),


        };

    }

    public class BagAffixes : Affixes
    {
        public static List<Affix> Prefixes = new() {
            new Affix("Lightweight", 1, CreateMods(new ModProps(ItemDataProperty.BagWR, 10, 20))),
            new Affix("Featherlight", 20, CreateMods(new ModProps(ItemDataProperty.BagWR, 20, 30))),
            new Affix("Ethereal", 35, CreateMods(new ModProps(ItemDataProperty.BagWR, 40, 50))),
            new Affix("Weightless", 50, CreateMods(new ModProps(ItemDataProperty.BagWR, 60, 100))),
        };

        public static List<Affix> Suffixes = new() {
        // +Damage Shield
        new Affix("Expansion", 1, CreateMods(new ModProps(ItemDataProperty.BagSlots, 1, 2))),
        new Affix("Capacity", 20, CreateMods(new ModProps(ItemDataProperty.BagSlots, 2, 3))),
        new Affix("Storage", 35, CreateMods(new ModProps(ItemDataProperty.BagSlots, 3, 4))),
        new Affix("Infinity", 50, CreateMods(new ModProps(ItemDataProperty.BagSlots, 5, 6))),
    };
    }

    public class RingAmuletAffixes : Affixes
    {
        public static List<Affix> Prefixes = new()
    {
          // Mana
            new Affix("Lizard's", 5, CreateMods(new ModProps(ItemDataProperty.Mana, 1, 5))),
            new Affix("Snake's", 15, CreateMods(new ModProps(ItemDataProperty.Mana, 6, 10))),
            new Affix("Serpent's", 25, CreateMods(new ModProps(ItemDataProperty.Mana, 11, 20))),
            new Affix("Drake's", 35, CreateMods(new ModProps(ItemDataProperty.Mana, 35, 50))),
            new Affix("Dragon's", 35, CreateMods(new ModProps(ItemDataProperty.Mana, 50, 80))),
    };

        public static List<Affix> Suffixes = new() {
        // LifeLeech/ManaLeech
        new Affix("the Leech", 1, CreateMods(new ModProps(ItemDataProperty.LifeLeech, 0.02, 0.05))),
        new Affix("the Locust", 20, CreateMods(new ModProps(ItemDataProperty.LifeLeech, 0.04, 0.07))),
        new Affix("the Lamprey", 40, CreateMods(new ModProps(ItemDataProperty.LifeLeech, 0.06, 0.09))),
        new Affix("the Bat", 1, CreateMods(new ModProps(ItemDataProperty.ManaLeech, 0.02, 0.05))),
        new Affix("the Wraith", 20, CreateMods(new ModProps(ItemDataProperty.ManaLeech, 0.04, 0.07))),
        new Affix("the Vampire", 40, CreateMods(new ModProps(ItemDataProperty.ManaLeech, 0.06, 0.09))),
    };
    }

    public class ArmorAffixes : Affixes
    {
        public static List<Affix> Prefixes = new() {
            // +Defense
            new Affix("Sturdy", 1, CreateMods(new ModProps(ItemDataProperty.AC, 1.1, 1.3, ModOperation.MULT))),
            new Affix("Strong", 10, CreateMods(new ModProps(ItemDataProperty.AC, 1.3, 1.4, ModOperation.MULT))),
            new Affix("Glorious", 20, CreateMods(new ModProps(ItemDataProperty.AC, 1.4, 1.5, ModOperation.MULT))),
            new Affix("Blessed", 30, CreateMods(new ModProps(ItemDataProperty.AC, 1.5, 1.65, ModOperation.MULT))),
            new Affix("Saintly", 40, CreateMods(new ModProps(ItemDataProperty.AC, 1.66, 1.8, ModOperation.MULT))),
            new Affix("Holy", 45, CreateMods(new ModProps(ItemDataProperty.AC, 1.8, 2, ModOperation.MULT))),
            new Affix("Godly", 50, CreateMods(new ModProps(ItemDataProperty.AC, 2, 3, ModOperation.MULT))),

            // +Elemental Resist
            // Cold
            new Affix("Azure", 5, CreateMods(new ModProps(ItemDataProperty.CR, 2, 5))),
            new Affix("Lapis", 15, CreateMods(new ModProps(ItemDataProperty.CR, 5, 10))),
            new Affix("Cobalt", 25, CreateMods(new ModProps(ItemDataProperty.CR, 10, 15))),
            new Affix("Sapphire", 45, CreateMods(new ModProps(ItemDataProperty.CR, 16, 20))),
            // Fire
            new Affix("Crimson", 5, CreateMods(new ModProps(ItemDataProperty.FR, 2, 5))),
            new Affix("Russet", 15, CreateMods(new ModProps(ItemDataProperty.FR, 5, 10))),
            new Affix("Garnet", 25, CreateMods(new ModProps(ItemDataProperty.FR, 10, 15))),
            new Affix("Ruby", 45, CreateMods(new ModProps(ItemDataProperty.FR, 16, 20))),
            // Magic
            new Affix("Tangerine", 5, CreateMods(new ModProps(ItemDataProperty.MR, 2, 5))),
            new Affix("Ocher", 15, CreateMods(new ModProps(ItemDataProperty.MR, 5, 10))),
            new Affix("Coral", 25, CreateMods(new ModProps(ItemDataProperty.MR, 10, 15))),
            new Affix("Amber", 45, CreateMods(new ModProps(ItemDataProperty.MR, 16, 20))),
            // Poison
            new Affix("Beryl", 5, CreateMods(new ModProps(ItemDataProperty.PR, 2, 5), new ModProps(ItemDataProperty.DR, 2, 5))),
            new Affix("Viridian", 15, CreateMods(new ModProps(ItemDataProperty.PR, 5, 10), new ModProps(ItemDataProperty.DR, 5, 10))),
            new Affix("Coral", 25, CreateMods(new ModProps(ItemDataProperty.PR, 10, 15), new ModProps(ItemDataProperty.DR, 10, 15))),
            new Affix("Amber", 45, CreateMods(new ModProps(ItemDataProperty.PR, 16, 20), new ModProps(ItemDataProperty.DR, 16, 20))),

            // Light/vision
            new Affix("Glowing", 5, CreateMods(new ModProps(ItemDataProperty.Light, 2, 3))),

            // Mana
            new Affix("Lizard's", 5, CreateMods(new ModProps(ItemDataProperty.Mana, 1, 5))),
            new Affix("Snake's", 15, CreateMods(new ModProps(ItemDataProperty.Mana, 6, 10))),
            new Affix("Serpent's", 25, CreateMods(new ModProps(ItemDataProperty.Mana, 11, 20))),
            new Affix("Drake's", 35, CreateMods(new ModProps(ItemDataProperty.Mana, 35, 50))),
            new Affix("Dragon's", 35, CreateMods(new ModProps(ItemDataProperty.Mana, 50, 80))),

        };

        public static List<Affix> Suffixes = new() {
        // +Damage Shield
        new Affix("Thorns", 5, CreateMods(new ModProps(ItemDataProperty.DamageShield, 1, 3))),
        new Affix("Malice", 20, CreateMods(new ModProps(ItemDataProperty.DamageShield, 4, 6))),
        new Affix("Razors", 34, CreateMods(new ModProps(ItemDataProperty.DamageShield, 7, 9))),
        new Affix("Swords", 47, CreateMods(new ModProps(ItemDataProperty.DamageShield, 10, 20))),

        // +Health Regen
        new Affix("Honor", 8, CreateMods(new ModProps(ItemDataProperty.Regen, 1, 4))),
        new Affix("Regeneration", 30, CreateMods(new ModProps(ItemDataProperty.Regen, 3, 5))),
        new Affix("Regrowth", 40, CreateMods(new ModProps(ItemDataProperty.Regen, 6, 10))),
        new Affix("Revivification", 50, CreateMods(new ModProps(ItemDataProperty.Regen, 11, 15))),

        // +Stats
        // Dex
        new Affix("Dexterity", 5, CreateMods(new ModProps(ItemDataProperty.HeroicDex, 1, 3))),
        new Affix("Skill", 15, CreateMods(new ModProps(ItemDataProperty.HeroicDex, 3, 5))),
        new Affix("Accuracy", 25, CreateMods(new ModProps(ItemDataProperty.HeroicDex, 6, 9))),
        new Affix("Precision", 35, CreateMods(new ModProps(ItemDataProperty.HeroicDex, 10, 15))),
        new Affix("Perfection", 45, CreateMods(new ModProps(ItemDataProperty.HeroicDex, 16, 20))),
        new Affix("Nirvana", 50, CreateMods(new ModProps(ItemDataProperty.HeroicDex, 21, 30))),

        // Wisdom
        new Affix("Wisdom", 5, CreateMods(new ModProps(ItemDataProperty.HeroicWis, 1, 3))),
        new Affix("Insight", 15, CreateMods(new ModProps(ItemDataProperty.HeroicWis, 3, 5))),
        new Affix("Sagacity", 25, CreateMods(new ModProps(ItemDataProperty.HeroicWis, 6, 9))),
        new Affix("Foresight", 35, CreateMods(new ModProps(ItemDataProperty.HeroicWis, 10, 15))),
        new Affix("Omniscience", 45, CreateMods(new ModProps(ItemDataProperty.HeroicWis, 16, 20))),
        new Affix("Enlightenment", 50, CreateMods(new ModProps(ItemDataProperty.HeroicWis, 21, 30))),

        // Int
        new Affix("Intelligence", 5, CreateMods(new ModProps(ItemDataProperty.HeroicInt, 1, 3))),
        new Affix("Knowledge", 15, CreateMods(new ModProps(ItemDataProperty.HeroicInt, 3, 5))),
        new Affix("Scholarship", 25, CreateMods(new ModProps(ItemDataProperty.HeroicInt, 6, 9))),
        new Affix("Savant", 35, CreateMods(new ModProps(ItemDataProperty.HeroicInt, 10, 15))),
        new Affix("Genius", 45, CreateMods(new ModProps(ItemDataProperty.HeroicInt, 16, 20))),
        new Affix("Ascendancy", 50, CreateMods(new ModProps(ItemDataProperty.HeroicInt, 21, 30))),

        // Agility
        new Affix("Agility", 5, CreateMods(new ModProps(ItemDataProperty.HeroicAgi, 1, 3))),
        new Affix("Nimbleness", 15, CreateMods(new ModProps(ItemDataProperty.HeroicAgi, 3, 5))),
        new Affix("Quickness", 25, CreateMods(new ModProps(ItemDataProperty.HeroicAgi, 6, 9))),
        new Affix("Swiftness", 35, CreateMods(new ModProps(ItemDataProperty.HeroicAgi, 10, 15))),
        new Affix("Alacrity", 45, CreateMods(new ModProps(ItemDataProperty.HeroicAgi, 16, 20))),
        new Affix("Celerity", 50, CreateMods(new ModProps(ItemDataProperty.HeroicAgi, 21, 30))),

        // Strength
        new Affix("Strength", 5, CreateMods(new ModProps(ItemDataProperty.HeroicStr, 1, 3))),
        new Affix("Might", 15, CreateMods(new ModProps(ItemDataProperty.HeroicStr, 3, 5))),
        new Affix("Power", 25, CreateMods(new ModProps(ItemDataProperty.HeroicStr, 6, 9))),
        new Affix("Force", 35, CreateMods(new ModProps(ItemDataProperty.HeroicStr, 10, 15))),
        new Affix("Vigor", 45, CreateMods(new ModProps(ItemDataProperty.HeroicStr, 16, 20))),
        new Affix("Ferocity", 50, CreateMods(new ModProps(ItemDataProperty.HeroicStr, 21, 30))),

        // Stamina
        new Affix("Stamina", 5, CreateMods(new ModProps(ItemDataProperty.HeroicSta, 1, 3))),
        new Affix("Endurance", 15, CreateMods(new ModProps(ItemDataProperty.HeroicSta, 3, 5))),
        new Affix("Resilience", 25, CreateMods(new ModProps(ItemDataProperty.HeroicSta, 6, 9))),
        new Affix("Durability", 35, CreateMods(new ModProps(ItemDataProperty.HeroicSta, 10, 15))),
        new Affix("Vitality", 45, CreateMods(new ModProps(ItemDataProperty.HeroicSta, 16, 20))),
        new Affix("Tenacity", 50, CreateMods(new ModProps(ItemDataProperty.HeroicSta, 21, 30))),

        // Charisma
        new Affix("Charisma", 5, CreateMods(new ModProps(ItemDataProperty.HeroicCha, 1, 3))),
        new Affix("Charm", 15, CreateMods(new ModProps(ItemDataProperty.HeroicCha, 3, 5))),
        new Affix("Influence", 25, CreateMods(new ModProps(ItemDataProperty.HeroicCha, 6, 9))),
        new Affix("Presence", 35, CreateMods(new ModProps(ItemDataProperty.HeroicCha, 10, 15))),
        new Affix("Aura", 45, CreateMods(new ModProps(ItemDataProperty.HeroicCha, 16, 20))),
        new Affix("Majesty", 50, CreateMods(new ModProps(ItemDataProperty.HeroicCha, 21, 30))),

        // HP
        new Affix("Health", 5, CreateMods(new ModProps(ItemDataProperty.HP, 5, 15))),
        new Affix("Vitality", 15, CreateMods(new ModProps(ItemDataProperty.HP, 16, 30))),
        new Affix("Vigor", 25, CreateMods(new ModProps(ItemDataProperty.HP, 31, 50))),
        new Affix("Robustness", 35, CreateMods(new ModProps(ItemDataProperty.HP, 51, 75))),
        new Affix("Fortitude", 45, CreateMods(new ModProps(ItemDataProperty.HP, 76, 105))),
        new Affix("Immortality", 50, CreateMods(new ModProps(ItemDataProperty.HP, 106, 150))),



    };
    }

    public class ShieldAffixes : Affixes
    {
        public static List<Affix> Prefixes = new() {
            // +Elemental Resistances
            // All
            new Affix("Shimmering", 6, CreateMods(
                new ModProps(ItemDataProperty.MR, 3, 7),
                new ModProps(ItemDataProperty.DR, 3, 7),
                new ModProps(ItemDataProperty.PR, 3, 7),
                new ModProps(ItemDataProperty.CR, 3, 7),
                new ModProps(ItemDataProperty.FR, 3, 7)
            )),
            new Affix("Rainbow", 18, CreateMods(
                new ModProps(ItemDataProperty.MR, 8, 11),
                new ModProps(ItemDataProperty.DR, 8, 11),
                new ModProps(ItemDataProperty.PR, 8, 11),
                new ModProps(ItemDataProperty.CR, 8, 11),
                new ModProps(ItemDataProperty.FR, 8, 11)
            )),
            new Affix("Scintillating", 28, CreateMods(
                new ModProps(ItemDataProperty.MR, 11, 15),
                new ModProps(ItemDataProperty.DR, 11, 15),
                new ModProps(ItemDataProperty.PR, 11, 15),
                new ModProps(ItemDataProperty.CR, 11, 15),
                new ModProps(ItemDataProperty.FR, 11, 15)
            )),
            new Affix("Prismatic", 39, CreateMods(
                new ModProps(ItemDataProperty.MR, 16, 20),
                new ModProps(ItemDataProperty.DR, 16, 20),
                new ModProps(ItemDataProperty.PR, 16, 20),
                new ModProps(ItemDataProperty.CR, 16, 20),
                new ModProps(ItemDataProperty.FR, 16, 20)
            )),
            new Affix("Chromatic", 50, CreateMods(
                new ModProps(ItemDataProperty.MR, 21, 30),
                new ModProps(ItemDataProperty.DR, 21, 30),
                new ModProps(ItemDataProperty.PR, 21, 30),
                new ModProps(ItemDataProperty.CR, 21, 30),
                new ModProps(ItemDataProperty.FR, 21, 30)
            )),
    };

        public static List<Affix> Suffixes = new()
        {

        };
    }

}