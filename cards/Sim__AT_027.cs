using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_027 : SimTemplate //Wilfred Fizzlebang
    {

        //Cards you draw from your Hero Power cost (0).

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnFizzlebang++;
            }
            else
            {
                p.anzEnemyFizzlebang++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnFizzlebang--;
            }
            else
            {
                p.anzEnemyFizzlebang--;
            }
        }

       

    }
}