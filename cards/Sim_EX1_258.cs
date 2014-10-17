using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_258 : SimTemplate//Unbound Elemental
    {
        // <deDE>ErhÃ¤lt jedes Mal +1/+1, wenn Ihr eine Karte mit &lt;b&gt;Ãœberladung&lt;/b&gt; ausspielt.</deDE>
        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && c.Recall)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }

    }
}
