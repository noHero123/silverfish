using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_073 : SimTemplate //coldblood
	{

//    verleiht einem diener +2 angriff. combo:/ stattdessen +4 angriff.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int ag = (p.cardsPlayedThisTurn >= 1 || !ownplay) ? 4 : 2; // we suggest, whether enemy is playing this, it is combo
            p.minionGetBuffed(target, ag, 0);
		}

	}
}