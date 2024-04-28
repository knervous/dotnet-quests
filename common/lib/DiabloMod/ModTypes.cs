
namespace Common.DiabloMod
{
    public enum ModOperation
    {
        ADD,
        MULT
    }


    public record ModProps(ItemDataProperty Prop, double Low, double High, ModOperation Op = ModOperation.ADD);

    public record ComputedModProp(ItemDataProperty Prop, double Computed, ModOperation Op);


    public enum ItemDataProperty
    {
        MinStatus,
        Comment,
        ItemClass,
        Name,
        Lore,
        IDFile,
        ID,
        Weight,
        NoRent,
        NoDrop,
        Size,
        Slots,
        Price,
        Icon,
        LoreGroup,
        LoreFlag,
        PendingLoreFlag,
        ArtifactFlag,
        SummonedFlag,
        FVNoDrop,
        Favor,
        GuildFavor,
        PointType,
        BagType,
        BagSlots,
        BagSize,
        BagWR,
        BenefitFlag,
        Tradeskills,
        CR,
        DR,
        PR,
        MR,
        FR,
        AStr,
        ASta,
        AAgi,
        ADex,
        ACha,
        AInt,
        AWis,
        HP,
        Mana,
        AC,
        Deity,
        SkillModValue,
        SkillModMax,
        SkillModType,
        BaneDmgRace,
        BaneDmgAmt,
        BaneDmgBody,
        Magic,
        CastTime_,
        ReqLevel,
        BardType,
        BardValue,
        Light,
        Delay,
        RecLevel,
        RecSkill,
        ElemDmgType,
        ElemDmgAmt,
        Range,
        Damage,
        Color,
        Classes,
        Races,
        MaxCharges,
        ItemType,
        SubType,
        Material,
        HerosForgeModel,
        SellRate,
        Fulfilment,
        CastTime,
        EliteMaterial,
        ProcRate,
        CombatEffects,
        Shielding,
        StunResist,
        StrikeThrough,
        ExtraDmgSkill,
        ExtraDmgAmt,
        SpellShield,
        Avoidance,
        Accuracy,
        CharmFileID,
        FactionMod1,
        FactionMod2,
        FactionMod3,
        FactionMod4,
        FactionAmt1,
        FactionAmt2,
        FactionAmt3,
        FactionAmt4,
        CharmFile,
        AugType,
        LDoNTheme,
        LDoNPrice,
        LDoNSold,
        BaneDmgRaceAmt,
        AugRestrict,
        Endur,
        DotShielding,
        Attack,
        Regen,
        ManaRegen,
        EnduranceRegen,
        Haste,
        DamageShield,
        RecastDelay,
        RecastType,
        AugDistiller,
        Attuneable,
        NoPet,
        PotionBelt,
        Stackable,
        NoTransfer,
        QuestItemFlag,
        StackSize,
        PotionBeltSlots,
        Clairvoyance,
        ScriptFileID,
        ExpendableArrow,
        SVCorruption,
        Purity,
        EvolvingItem,
        EvolvingID,
        EvolvingLevel,
        EvolvingMax,
        BackstabDmg,
        DSMitigation,
        HeroicStr,
        HeroicInt,
        HeroicWis,
        HeroicAgi,
        HeroicDex,
        HeroicSta,
        HeroicCha,
        HeroicMR,
        HeroicFR,
        HeroicCR,
        HeroicDR,
        HeroicPR,
        HeroicSVCorrup,
        HealAmt,
        SpellDmg,
        LDoNSellBackRate,


        // CUSTOM
        LifeLeech,
        ManaLeech,
    }

    public enum ItemQuality
    {
        NORMAL,
        MAGIC,
        RARE,
        UNIQUE,
        SET
    }

    public class ModData
    {
        static readonly int VERSION = 1;
        public List<Affix> Prefixes { get; init; } = [];
        public List<Affix> Suffixes { get; init; } = [];
        public uint OriginalId { get; set; } = 0;
        public string NameOverride { get; set; } = "";
        public int Version { get; set; } = VERSION;
        public ItemQuality Quality { get; set; } = ItemQuality.NORMAL;
    }

    public class Modifier
    {
        private ModOperation _operation;
        private double _modificationValue;

        public Modifier(ModOperation operation, double modificationValue)
        {
            _operation = operation;
            _modificationValue = modificationValue;
        }

        public T Apply<T>(T originalValue)
            where T : struct
        {
            double baseValue = Convert.ToDouble(originalValue);
            double newValue = baseValue;

            switch (_operation)
            {
                case ModOperation.ADD:
                    newValue = baseValue + _modificationValue;
                    break;
                case ModOperation.MULT:
                    newValue = baseValue * _modificationValue;
                    break;
            }

            return (T)Convert.ChangeType(newValue, typeof(T));
        }
    }

}