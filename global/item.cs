using Common.DiabloMod;

class Item : IItemEvent
{
    public void ItemGenerate(ItemEvent e)
    {
        var item = e.item;
        var itemData = item.GetItem();
        var customData = item.GetCustomData("DiabloMod");
        var modData = DiabloMod.Deserialize(customData);
        if (modData != null)
        {
            if (modData.Quality == ItemQuality.MAGIC)
            {

                var prefix = modData.Prefixes.FirstOrDefault();
                if (prefix != null)
                {
                    itemData.Name = $"{prefix.Name} {itemData.Name}";
                    DiabloMod.ApplyItemChanges(ref itemData, prefix.Props);
                }
                var suffix = modData.Suffixes.FirstOrDefault();
                if (suffix != null)
                {
                    itemData.Name = $"{itemData.Name} of {suffix.Name}";
                    DiabloMod.ApplyItemChanges(ref itemData, suffix.Props);
                }
                itemData.Magic = true;
            }
        }
    }
}