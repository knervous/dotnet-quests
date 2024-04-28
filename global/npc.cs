
using Common.DiabloMod;

class ALL_NPC
{
    public void Spawn(NpcEvent e)
    {
        e.npc.GetLootItems().ToList().ForEach(item =>
        {
            if (DiabloMod.RollMagicLootItem(item, e.npc.GetLevel(), 100))
            {
                e.QuestDebug($"**** {e.npc.GetName()} has a magic item ****");
            }
        });
    }
}

