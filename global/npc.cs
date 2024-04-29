
using Common.DiabloMod;
using Common;

class ALL_NPC
{
    public void Spawn(NpcEvent e)
    {
        if (!FeatureFlags.RollModNpcLoot) {
            return;
        }
        // This could also be applied on Death
        // And aggregate some type of magic find system from a player's inventory with custom_data
        e.npc.GetLootItems().ToList().ForEach(item =>
        {
            if (DiabloMod.RollMagicLootItem(item, e.npc.GetLevel(), FeatureFlags.RollMagicChance))
            {
                e.QuestDebug($"**** {e.npc.GetName()} has a magic item ****");
            }
        });
        
    }
}

