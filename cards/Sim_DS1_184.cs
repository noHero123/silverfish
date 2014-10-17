using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DS1_184 : SimTemplate //tracking
	{

//    schaut euch die drei obersten karten eures decks an. zieht eine davon und werft die anderen beiden ab.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            //TODO NOT SUPPORTED YET
            //p.drawACard(CardDB.cardName.unknown, ownplay);
            p.evaluatePenality += 100;
		}

	}
}