using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_097 : SimTemplate //Lil' Exorcist
    {

        //   Taunt Battlecry: Gain +1/+1 for each enemy Deathrattle minion.
        //todo does silenced count?
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.enemyMinions : p.ownMinions;

            int gain = 0;
            foreach (Minion m in temp)
            {
                if (m.handcard.card.deathrattle) gain++;
            }
            if(gain>=1) p.minionGetBuffed(own, gain, gain);
        }

      

    }

}