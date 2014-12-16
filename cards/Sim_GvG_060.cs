using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_060 : SimTemplate //Quartermaster
    {

        //   Battlecry: Give your Silver Hand Recruits +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.name == CardDB.cardName.silverhandrecruit) p.minionGetBuffed(m, 2, 2);
            }
        }

       
    }

}