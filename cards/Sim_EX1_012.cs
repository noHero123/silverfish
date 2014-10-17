using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_012 : SimTemplate//bloodmage thalnos
    {
        public override void onAuraStarts(Playfield p, Minion own)
        {
           
            if (own.own)
            {
                p.spellpower++;
            }
            else
            {
                p.enemyspellpower++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower--;
            }
            else
            {
                p.enemyspellpower--;
            }
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.unknown, m.own);
        }

    }
}
