
public class Soulbinder : INpcEvent
{
    public override void Say(NpcEvent e)
    {
        if (e.data.Contains("Hail"))
        {
            e.npc.Say($"Greetings {e.mob.GetName()}. When a hero of our world is slain their soul returns to the place it was last bound and the body is reincarnated. As a member of the Order of Eternity  it is my duty to [bind your soul] to this location if that is your wish.");
        }
        else if (e.data.Contains("bind your soul") || e.data.Contains("bind my soul"))
        {
            e.npc.Say("Binding your soul. You will return here when you die.");
            e.npc.CastSpell(2049, e.mob.GetID(), 0, 1);
        }
    }
}