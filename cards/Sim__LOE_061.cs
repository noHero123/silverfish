using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_061 : SimTemplate// Anubisath Sentinel
    {
        //Deathrattle: Give a random friendly minion +3/+3
        public override void onDeathrattle(Playfield p, Minion m)
        {

            if (p.isServer)
            {
                Minion tempS = p.getRandomMinionFromSide_SERVER(m.own, false);
                if(tempS!=null)p.minionGetBuffed(tempS, 3, 3);
                return;
            }

            List<Minion> temp = new List<Minion>();

            if (m.own)
            {
                List<Minion> temp2 = new List<Minion>(p.ownMinions);
                temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));
                temp.AddRange(temp2);
            }
            else
            {
                List<Minion> temp2 = new List<Minion>(p.enemyMinions);
                temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
                temp.AddRange(temp2);
            }

            if (temp.Count >= 1)
            {
                if (m.own)
                {
                    Minion target = temp[0];
                    if (temp.Count >= 2 && target.taunt && !temp[1].taunt) target = temp[1];
                    p.minionGetBuffed(target, 3, 3);
                }
                else
                {

                    Minion target = temp[0];
                    if (temp.Count >= 2 && !target.taunt && temp[1].taunt) target = temp[1];
                    p.minionGetBuffed(target, 3, 3);
                }
            }

        }
        

            
    }
}
