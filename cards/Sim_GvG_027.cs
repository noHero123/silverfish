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
                if (temp.Count >= 1)
                {
                    p.minionGetBuffed(p.searchRandomMinion(temp, Playfield.searchmode.searchHighestAttack), 2, 2);
                }
            }
        }


    }

}