using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_339 : SimTemplate //thoughtsteal
	{

//    kopiert 2 karten aus dem deck eures gegners und fügt sie eurer hand hinzu.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (p.isServer)
            {
                foreach (CardDB.cardIDEnum cie in p.copyRandomCardFromDeck_SERVER(!ownplay))
                {
                    p.drawACard(cie, ownplay, true);
                }

                return;
            }

            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
		}

	}
}