using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_078 : SimTemplate //Mechanical Yeti
    {

        //   Deathrattle: Give each player a Spare Part

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardIDEnum.PART_001, false, true);
            p.drawACard(CardDB.cardIDEnum.PART_001, true, true);
        }


    }

}