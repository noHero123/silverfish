using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_132_WARLOCK : SimTemplate //lifetap
	{

        //    heldenfähigkeit/\Draw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {

            bool reduceToZero = false;
            if (ownplay && p.anzOwnFizzlebang >= 1)
            {
                reduceToZero = true;
            }
            if (!ownplay && p.anzEnemyFizzlebang >= 1)
            {
                reduceToZero = true;
            }
            p.drawACard(CardDB.cardIDEnum.None, ownplay, false, reduceToZero);

        }


	}
}