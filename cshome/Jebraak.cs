public class Jebraak : INpcEvent
{
    public override void Say(NpcEvent e)
    {
        e.npc.Say($"Greetings, {e.mob.GetName()}. I am glad you are safe! Lanys T'Vyl shattered the Plane of Time after you and your fellow guildmates released Zebuxoruk. She killed Druzzil Ro and has taken Zebuxoruk's knowledge as her own. Norrath as you know it has been altered. We are under Firiona Vie's protection in this long lost plane of Sunset Home. Speak with Firiona Vie regarding the matter. She stands guard over the portal to Norrath.");
    }     
}

