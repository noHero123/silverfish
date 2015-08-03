using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_082 : SimTemplate //Clockwork Gnome
    {

        //   Deathrattle: Add a Spare Part card to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.isServer)
            {
                p.drawACard(p.getRandomSparePart_SERVER(), m.own, true);
                return;
            }

            p.drawACard(CardDB.cardIDEnum.PART_001, m.own, true);
        }

    }

}