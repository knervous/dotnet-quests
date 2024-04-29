using System.Reflection;
using System.Text.RegularExpressions;

namespace Common.DiabloMod
{
    public class DiabloMod
    {
        internal enum ModItemTypes
        {
            NONE,
            WEAPON,
            ARMOR,
            JEWELRY,
            SHIELD,
            BAG
        }

        private List<ModItemTypes> ModItemTypeList = [];
        public static Random Rand = new Random();
        int MinLevel { get; set; } = 0;

        public ModData ModData { get; init; }

        public bool IsValid
        {
            get
            {
                return ModItemTypeList.Count > 0;
            }
        }

        public DiabloMod(ItemData itemData, int minLevel)
        {
            var type = (ItemType)itemData.ItemType;
            uint id = itemData.ID;
            var itemClass = (ItemClass)itemData.ItemClass;
            // Weapons
            if (new[] {
                ItemType.ItemType1HBlunt,
                ItemType.ItemType2HBlunt,
                ItemType.ItemType1HSlash,
                ItemType.ItemType2HSlash,
                ItemType.ItemType1HPiercing,
                ItemType.ItemType2HPiercing,
                ItemType.ItemTypeBow,
                ItemType.ItemTypeMartial
            }.Contains(type))
            {

                ModItemTypeList.Add(ModItemTypes.WEAPON);
            }
            // Armor
            if (ItemType.ItemTypeArmor == type)
            {
                ModItemTypeList.Add(ModItemTypes.ARMOR);
            }
            // Shield
            if (ItemType.ItemTypeShield == type)
            {
                ModItemTypeList.Add(ModItemTypes.SHIELD);
            }
            // Jewelry
            // I know these are bitmasks but just calling out when they're only specified for that slot
            if (itemData.Slots == 98304 || itemData.Slots == 32 || itemData.Slots == 18)
            {
                ModItemTypeList.Add(ModItemTypes.JEWELRY);
            }

            // Rings/Amulet
            if (ItemClass.ItemClassBag == itemClass)
            {
                ModItemTypeList.Add(ModItemTypes.BAG);
            }
            ModData = new ModData() { OriginalId = id };
            MinLevel = minLevel;
        }

        public string Serialize()
        {

            var options = new System.Text.Json.JsonSerializerOptions
            {
                Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() },
                IncludeFields = true,

            };
            var serialized = System.Text.Json.JsonSerializer.Serialize(ModData, options);
            
            serialized = serialized.Replace("\\u", "u");
            questinterface.LogSys.QuestDebug($"SERIALIZED: {serialized}");
            return serialized;
        }

        public static ModData? Deserialize(string serialized)
        {
            if (serialized == string.Empty)
            {
                return null;
            }
            try
            {
                var options = new System.Text.Json.JsonSerializerOptions
                {
                    Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() },
                    IncludeFields = true,
                };
                // Regex to find patterns like 'u0027' (Unicode escape sequences)
                var regex = new Regex(@"u([0-9A-Fa-f]{4})", RegexOptions.Compiled);

                var rehydratedSerialized = regex.Replace(serialized, match =>
                {
                    var c = (char)Convert.ToInt32(match.Groups[1].Value, 16);
                    return c.ToString();
                });

                return System.Text.Json.JsonSerializer.Deserialize<ModData>(rehydratedSerialized, options);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void ApplyItemChanges(ref ItemData itemData, List<ComputedModProp> modProps)
        {

            int lifeLeech = 0, manaLeech = 0;
            foreach (var prop in modProps)
            {
                if (prop.Prop == ItemDataProperty.LifeLeech)
                {
                    lifeLeech += (int)(prop.Computed * 100);
                }
                else if (prop.Prop == ItemDataProperty.ManaLeech)
                {
                    manaLeech += (int)(prop.Computed * 100);
                }

                var modifier = new Modifier(prop.Op, prop.Computed);
                System.Type itemType = itemData.GetType();
                PropertyInfo? propInfo = itemType?.GetProperty(prop.Prop.ToString());
                if (propInfo != null && propInfo.CanWrite)
                {
                    object currentValue = propInfo.GetValue(itemData);
                    object? newValue = null;

                    if (currentValue is sbyte val_sbyte)
                    {
                        newValue = modifier.Apply(val_sbyte);
                    }
                    else if (currentValue is byte val_byte)
                    {
                        newValue = modifier.Apply(val_byte);
                    }
                    else if (currentValue is uint val_uint)
                    {
                        newValue = modifier.Apply(val_uint);
                    }
                    else if (currentValue is int val_int)
                    {
                        newValue = modifier.Apply(val_int);
                    }
                    else if (currentValue is int val_bool)
                    {
                        newValue = modifier.Apply(val_bool);
                    }
                    else if (currentValue is ushort val_ushort)
                    {
                        newValue = modifier.Apply(val_ushort);
                    }
                    else if (currentValue is short val_short)
                    {
                        newValue = modifier.Apply(val_short);
                    }

                    if (newValue != null)
                    {
                        propInfo.SetValue(itemData, newValue);
                    }
                }
            }

            // Custom applications
            if (lifeLeech > 0 || manaLeech > 0)
            {
                string leechStr;
                if (lifeLeech > 0 && manaLeech > 0)
                {
                    leechStr = $"{lifeLeech}% life and {manaLeech}% mana stolen per hit";
                }
                else if (lifeLeech > 0 && manaLeech == 0)
                {
                    leechStr = $"{lifeLeech}% life stolen per hit";
                }
                else
                {
                    leechStr = $"{manaLeech}% mana stolen per hit";
                }


                if (itemData.Proc.Type < 1)
                {
                    itemData.Proc.Type = 1;
                    itemData.Proc.Effect = 1;
                    itemData.Proc.Level = 1;
                    itemData.Proc.Level2 = 1;
                    itemData.ProcName = leechStr;
                }
                else
                {
                    itemData.ProcName += $". {leechStr}";
                }
            }
        }

        public DiabloMod AddPrefix()
        {
            List<Affix> affixes = [];
            if (ModItemTypeList.Contains(ModItemTypes.WEAPON))
            {
                affixes.AddRange(WeaponAffixes.Prefixes);
            }
            if (ModItemTypeList.Contains(ModItemTypes.ARMOR) && !ModItemTypeList.Contains(ModItemTypes.JEWELRY))
            {
                affixes.AddRange(ArmorAffixes.Prefixes);
            }
            if (ModItemTypeList.Contains(ModItemTypes.SHIELD))
            {
                affixes.AddRange(ShieldAffixes.Prefixes);
            }
            if (ModItemTypeList.Contains(ModItemTypes.JEWELRY))
            {
                affixes.AddRange(RingAmuletAffixes.Prefixes);
            }
            if (ModItemTypeList.Contains(ModItemTypes.BAG))
            {
                affixes.AddRange(BagAffixes.Prefixes);
            }
            var prefix = Affixes.GetPrefix(affixes, MinLevel);
            if (prefix != null)
            {
                ModData.Prefixes.Add(prefix);
            }
            return this;
        }

        public DiabloMod AddSuffix()
        {
            List<Affix> affixes = [];
            if (ModItemTypeList.Contains(ModItemTypes.WEAPON))
            {
                affixes.AddRange(WeaponAffixes.Suffixes);
            }
            if (ModItemTypeList.Contains(ModItemTypes.ARMOR) && !ModItemTypeList.Contains(ModItemTypes.JEWELRY))
            {
                affixes.AddRange(ArmorAffixes.Suffixes);
            }
            if (ModItemTypeList.Contains(ModItemTypes.SHIELD))
            {
                affixes.AddRange(ShieldAffixes.Suffixes);
            }
            if (ModItemTypeList.Contains(ModItemTypes.JEWELRY))
            {
                affixes.AddRange(RingAmuletAffixes.Suffixes);
            }
            if (ModItemTypeList.Contains(ModItemTypes.BAG))
            {
                affixes.AddRange(BagAffixes.Suffixes);
            }
            var suffix = Affixes.GetPrefix(affixes, MinLevel);
            if (suffix != null)
            {
                ModData.Suffixes.Add(suffix);
            }
            return this;
        }

        public DiabloMod CreateMagicItem()
        {
            var roll = Rand.Next(0, 100);
            if (roll < 34)
            {
                AddPrefix();
            }
            else if (roll < 67)
            {
                AddSuffix();
            }
            else
            {
                AddPrefix();
                AddSuffix();
            }
            ModData.Quality = ItemQuality.MAGIC;
            return this;
        }
        public static bool RollMagicLootItem(LootItem item, int minLevel, int chance = 100)
        {
            var itemData = questinterface.database.GetItem(item.item_id);
            var mod = new DiabloMod(itemData, minLevel);
            if (mod.IsValid && Rand.Next(0, 100) > (100 - chance))
            {
                mod.CreateMagicItem();
                if (mod.ModData.Quality == ItemQuality.MAGIC)
                {
                    item.custom_data = $"DiabloMod^{mod.Serialize()}^original_id^{item.item_id}";
                }
                return true;
            }

            return false;
        }

        public static ItemInstance RollMagicItem(ItemInstance item, int minLevel, int chance)
        {
            var id = item.GetID();
            if (item.GetCustomData("original_id").Length > 0) {
                id = uint.Parse(item.GetCustomData("original_id"));
            }
            var itemData = questinterface.database.GetItem(id);
            item.GetItem().Name = itemData.Name;
            item.GetItem().ID = id;
            var mod = new DiabloMod(itemData, minLevel);
            if (mod.IsValid && Rand.Next(0, 100) > (100 - chance))
            {
                mod.CreateMagicItem();
                if (mod.ModData.Quality == ItemQuality.MAGIC)
                {
                    item.SetCustomData("DiabloMod", mod.Serialize());
                    item.SetCustomData("original_id", id);
                }
            }
            return questinterface.database.CreateItem(itemData, 1, 0, 0, 0, 0, 0, 0, false, item.GetCustomDataString());
        }


    }
}
