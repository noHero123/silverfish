using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_591 : SimTemplate //auchenaisoulpriest
	{

//    eure karten und fähigkeiten, die leben wiederherstellen, verursachen stattdessen nun schaden.
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnAuchenaiSoulpriest++;
            }
            else
            {
                p.anzEnemyAuchenaiSoulpriest++;
            }

        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnAuchenaiSoulpriest--;
            }
            else
            {
                p.anzEnemyAuchenaiSoulpriest--;
            }
        }


	}
}