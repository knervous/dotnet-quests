class Spell : ISpellEvent {
    public override void SpellEffectClient (SpellEvent e) {
      //  e.globals.logSys.QuestDebug($"Spell ID fired: {e.spellID}");
    }

    public override void SpellEffectBuffTicClient(SpellEvent e) {
      //  e.globals.logSys.QuestDebug($"Spell ID tic fired: {e.spellID}");
    }
}