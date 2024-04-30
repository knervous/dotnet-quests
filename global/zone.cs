using Common.DiabloMod;

class ZoneLoad
{
    public static void Init()
    {
        EQCommands.AddCommand(
            "moditem",
             "[MinLevel] [Pct Chance 0-100] Rolls magic properties to the item on the cursor of the target",
             AccountStatus.Guide,
        (client, msg) =>
        {
            var minLevel = 50;
            var chance = 100;
            var args = msg.Split(" ");
            var originalClient = client;
            if (args.Length > 1) {
                int.TryParse(args[1], out minLevel);
            }
            if (args.Length > 2) {
                int.TryParse(args[2], out chance);
            }
            
            if (client.GetTarget() != null && client.GetTarget().IsClient())
            {
                client = client.GetTarget().CastToClient();
            } 

            if (!client.GetInv().CursorEmpty())

            {
                var item = client.GetInv().GetCursorItem();
                var newItem = DiabloMod.RollMagicItem(item, minLevel, chance);
     
                client.Message(questinterface.EQ_Yellow, $"Magic item rolled: {newItem.GetItem().Name}.");
                if (client != originalClient) {
                    originalClient.Message(questinterface.EQ_Yellow, $"Magic item rolled: {newItem.GetItem().Name}.");
                }
                client.MoveItemToInventory(newItem, true);
                client.DeleteItemInInventory(33, 1, true, true);
            }
        });
    }

    public static void Dispose() { 
        EQCommands.FlushCommands(); 
    }
}