using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_035 : SimTemplate //Malorne
    {

        //    Deathrattle:&lt;/b&gt; Shuffle this minion into your deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.ownDeckSize++;
            }
            else
            {
                p.enemyDeckSize++;
            }
        }


    }

}