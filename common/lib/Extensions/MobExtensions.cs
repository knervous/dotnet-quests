public static class MobExtensions
{
    public static void QuestSay(this Mob mob, EntityList e, string message)
    {
        Options journalOptions = new Options
        {
            speak_mode = SpeakMode.Say,
            journal_mode = Mode.None,
            language = (sbyte)questinterface.CommonTongue,
            message_type = questinterface.EQ_NPCQuestSay,
            target_spawn_id = mob.GetID()
        };
        e.QuestJournalledSayClose(mob, 200, mob.GetCleanName(), message, journalOptions);
    }

    public static void Tell(this Mob mob, EntityList e, string message)
    {
        Options journalOptions = new Options
        {
            speak_mode = SpeakMode.Say,
            journal_mode = Mode.None,
            language = (sbyte)questinterface.CommonTongue,
            message_type = questinterface.Tell,
            target_spawn_id = mob.GetID()
        };
        e.QuestJournalledSayClose(mob, 200, mob.GetCleanName(), message, journalOptions);
    }
}
