
namespace Common {
    public class FeatureFlags {
        /**
        This flag will control whether modded items are generated
        when NPCs spawn
        */
        public static bool RollModNpcLoot = false;
        /**
        This flag will control if item mods are applied. The item mods
        can still exist latently without being applied in game if this is false.
        */
        public static bool ApplyItemMods = true;
        /**
        This flag controls the percent chance of an item being modified
        */
        public static int RollMagicChance = 100;
    }
}