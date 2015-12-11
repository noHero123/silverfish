using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_019t : SimTemplate //scarab
	{
        //Shuffle the Golden Monkey into your deck. Draw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.isServer)
            {
                if (ownplay)
                {
                    p.ownDeckSize++;
                }
                else
                {
                    p.enemyDeckSize++;
                }
                p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
                return;
            }

            if (ownplay)
            {
                p.ownDeckSize++;
            }
            else
            {
                p.enemyDeckSize++;
            }
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);

        }
	}
}