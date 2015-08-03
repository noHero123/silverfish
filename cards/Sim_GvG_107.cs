using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_107 : SimTemplate //Enhance-o Mechano
    {

        //  Battlecry: Give your other minions Windfury Taunt or Divine Shield

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if (p.isServer)
            {
                List<Minion> temps = (own.own) ? p.ownMinions : p.enemyMinions;

                foreach (Minion m in temps)
                {
                    int random = p.getRandomNumber_SERVER(0, 2);
                    if(random == 0) m.taunt = true;
                    if (random == 1) m.divineshild = true;
                    if (random == 2) m.windfury = true;
                }

                return;
            }

            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;

            foreach (Minion m in temp)
            {
                m.taunt = true;
            }

        }


    }

}