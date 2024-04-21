class Player : IPlayerEvent
{
    public override void Signal(PlayerEvent e)
    {
        int value = Convert.ToInt32(e.data);

        if (value ==(int)CRSignals.PlaySoundFromPC)
        {
            e.player.PlayMP3("eqtheme.mp3");
        }

        if (value == (int)CRSignals.CameraShake)
        {
            e.player.CameraEffect(2000, 1);
        }

        if (value == (int)CRSignals.BankerSpawn)
        {
            e.player.PlayMP3("banker.mp3");
        }

        if (value == (int)CRSignals.StripExpBuff)
        {
            CRExpBuffs.StripExpBuff(e);
        }
    }

    public override void ItemClickClient(PlayerEvent e)
    {
        if (e.itemList[0].GetID() == 1800)
        {
            if (e.player.GrantFlag(CRUtilityFlags.Banker))
                e.questManager.WorldWideMessage(questinterface.EQ_Cyan, $"{e.player.GetName()} found a {e.itemList[0].GetItem().Name}!");
        }
        else if (e.itemList[0].GetID() == 1801)
        {
            if (e.player.GrantFlag(CRUtilityFlags.Merchant))
                e.questManager.WorldWideMessage(questinterface.EQ_Cyan, $"{e.player.GetName()} found a {e.itemList[0].GetItem().Name}!");
        }

        // need to implement buffer
    }
}