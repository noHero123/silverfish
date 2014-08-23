using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_606 : SimTemplate //shieldblock
	{

//    erhaltet 5 rüstung. zieht eine karte.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.ownHero.armor += 5;
            }
            else
            {
                p.enemyHero.armor += 5;
            }
            p.drawACard(CardDB.cardName.unknown, ownplay);
		}

	}
}