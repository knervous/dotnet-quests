using Common.DiabloMod;

class ZoneLoad
{
    public static void Init()
    {
         // Not 100% working yet but close -- use with caution!
        EQCommands.AddCommand(
            "magicitem",
             "Adds magic affixes to the item on the cursor of the target",
             AccountStatus.Guide,
        (client, separator) =>
        {
            if (client.GetTarget() != null && client.GetTarget().IsClient())
            {
                client = client.GetTarget().CastToClient();
            }
            if (!client.GetInv().CursorEmpty())
            {
                var item = client.GetInv().GetCursorItem();
                DiabloMod.RollMagicItem(item, 50, 100);

               
                var newItem = questinterface.database.CreateItem(item.GetItem(), 1, 0, 0, 0, 0, 0, 0, false, item.GetCustomDataString());
                client.Message(questinterface.EQ_Yellow, $"Magic item rolled: {newItem.GetItem().Name}");

                // TODO get eq client version specific enums for inventory slots
                // This is cursor in RoF
                client.DeleteItemInInventory(33);
                client.PushItemOnCursor(newItem);
                client.SendCursorBuffer();
            }
        });
    }
}