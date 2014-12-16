using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_094 : SimTemplate //Jeeves
    {

        //   At the end of each player's turn, that player draws until they have 3 cards.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {

            int cardstodraw = 0;
            if (p.owncards.Count <= 2)
            {
                cardstodraw = 3 - p.owncards.Count; 
            }

            for (int i = 0; i < cardstodraw; i++)
            {
                p.drawACard(CardDB.cardName.unknown, true);
            }
            cardstodraw = 0;

            //draw enemys cards...
            if (p.enemyAnzCards <= 2)
            {
                cardstodraw = 3 - p.enemyAnzCards;
            }

            for (int i = 0; i < cardstodraw; i++)
            {
                p.drawACard(CardDB.cardName.unknown, false);
            }

        }


    }

}