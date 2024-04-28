using Common.DiabloMod;


class Player : IPlayerEvent
{

    public void DamageGiven(PlayerEvent e)
    {
        var arr = e.data.Split(" ");
        var dmg = int.Parse(arr[1]);
        var entity = arr[0];
        double lifeLeech = 0.0;
        double manaLeech = 0.0;
        e.player.GetInv().m_worn.ToList().ForEach(itemPair =>
        {
            var item = itemPair.Value;
            var customData = item.GetCustomData("DiabloMod");
            var modData = DiabloMod.Deserialize(customData);
            if (modData != null)
            {
                if (modData.Quality == ItemQuality.MAGIC)
                {
                    var modProps = modData.Prefixes.SelectMany(p => p.Props)
                        .Concat(modData.Suffixes.SelectMany(p => p.Props))
                        .ToList();

                    foreach (var p in modProps)
                    {
                        if (p.Prop == ItemDataProperty.LifeLeech)
                        {
                            lifeLeech += p.Computed;
                        }
                        if (p.Prop == ItemDataProperty.ManaLeech)
                        {
                            manaLeech += p.Computed;
                        }
                    }
                }
            }
        });
        if (lifeLeech > 0 || manaLeech > 0)
        {
            var healAmount = (long)(lifeLeech * dmg);
            var manaHealAmount = (long)(manaLeech * dmg);
            string leechStr;
            if (lifeLeech > 0 && manaLeech > 0)
            {
                leechStr = $"Leeched {healAmount} health and {manaHealAmount} mana.";
            }
            else if (lifeLeech > 0 && manaLeech == 0)
            {
                leechStr = $"Leeched {healAmount} health.";
            }
            else
            {
                leechStr = $"Leeched {manaHealAmount} mana.";
            }

            e.player.SetHP(e.player.GetHP() + healAmount);
            e.player.SetMana(e.player.GetMana() + manaHealAmount);
            e.player.Message(questinterface.EQ_Lime, leechStr);
        }
    }
}