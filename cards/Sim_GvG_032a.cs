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

            p.mana = Math.Min(10, p.mana + 1);
            p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
            p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + 1);
            
        }


    }

}