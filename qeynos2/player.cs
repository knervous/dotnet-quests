class Player : IPlayerEvent {
    public override void Say(PlayerEvent e) {
       // e.globals.logSys.QuestDebug($"{e.player.GetName()} said: {e.data}");
    }
}