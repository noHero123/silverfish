using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_127 : SimTemplate //Nexus-Champion Saraad
    {

        //Inspire: Add a random spell to your hand

        public override void onInspire(Playfield p, Minion m)
        {
            if (p.isServer)
            {
                //TODO
                p.drawACard(CardDB.cardIDEnum.None, m.own, true);
                return;
            }

            p.drawACard(CardDB.cardIDEnum.None, m.own, true); 

        }


       

    }
}