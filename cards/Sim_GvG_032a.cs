using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_032a : SimTemplate //Grove Tender
    {

        //   Give each player a Mana Crystal.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

                p.mana++;
                p.ownMaxMana++;
                p.enemyMaxMana++;
            
        }


    }

}