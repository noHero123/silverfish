using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_027 : SimTemplate //Iron Sensei
    {

        //   At the end of your turn, give another friendly Mech +2/+2.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                List<Minion> temp = (turnEndOfOwner) ? p.ownMinions : p.enemyMinions;
                List<Minion> tempmech = new List<Minion>();
                foreach (Minion m in temp)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
                    {
                        tempmech.Add(m);
                    }
                }
                if (tempmech.Count >= 1)
                {
                    if (p.isServer)
                    {
                        int random = p.getRandomNumber_SERVER(0, tempmech.Count - 1);
                        p.minionGetBuffed(tempmech[random], 2, 2);
                        return;
                    }
                    p.minionGetBuffed(p.searchRandomMinion(tempmech, (triggerEffectMinion.own ? Playfield.searchmode.searchLowestHP : Playfield.searchmode.searchHighestHP)), 2, 2);
                }
            }
        }


    }

}