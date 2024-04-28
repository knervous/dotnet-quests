class Item : IItemEvent {
    public override void ItemClick(ItemEvent e) {
       // e.globals.logSys.QuestDebug($"Item clicked: {e.item.GetItem().Name}");
    }
}