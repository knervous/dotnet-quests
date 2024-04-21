
public static class ClientExtensions
{
    /// <summary>
    /// Can't set DZ options right now through c# interface so sticking to basic expedition
    /// </summary>
    /// <param name="client"></param>
    /// <param name="ei"></param>
    /// <returns></returns>
    public static Expedition CreateExpedition(this Client client, ExpeditionInfo ei)
    {
        DynamicZone dz = new DynamicZone(ei.Instance.ZoneID, ei.Instance.Version, ei.Instance.Duration, DynamicZoneType.Expedition);
        dz.SetName(ei.ExpeditionName);
        dz.SetMinPlayers(ei.MinPlayers);
        dz.SetMaxPlayers(ei.MaxPlayers);
        dz.SetCompass(ei.Compass);
        dz.SetSafeReturn(ei.SafeReturn);
        dz.SetZoneInLocation(ei.ZoneIn);

        return client.CreateExpedition(dz);
        //return exp;
    }

    //public static void MoveZoneGroupSafeCoords(this Client client, string zoneShortname)
    //{
    //    //ZoneStore.GetZoneID("test");
    //    //ZoneStore.GetZoneSafeCoordinates(6);


    //}
    //private static FlagSystem? flags;

    public static bool IsFlagged(this Client client, Flag flag)
    {
        string flagVal = client.GetBucket(flag.Name);
        if (flagVal != string.Empty)
        {
            try
            {
                return Convert.ToBoolean(flagVal);
            }
            catch
            {
                questinterface.LogSys.QuestError($"IsFlagged flagval not a boolean. flagVal = {flagVal}");
            }
        }

        return false;
    }

    /// <summary>
    /// Grants a flag. If the player already has the flag, then returns false
    /// </summary>
    /// <param name="client"></param>
    /// <param name="flag"></param>
    /// <returns>False if player already had the flag, true if they did not</returns>
    public static bool GrantFlag(this Client client, Flag flag)
    {
        if (IsFlagged(client, flag))
            return false;

        client.SetBucket(flag.Name, "true");

        return true;
    }
}

