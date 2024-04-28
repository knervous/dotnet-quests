class Guard_Gehnus : AI_NPC 
{
    public override void Spawn(NpcEvent e)
    {
        e.npc.Say($"Spawned"); 
    }
}
