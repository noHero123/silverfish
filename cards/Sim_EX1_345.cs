using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_345 : SimTemplate //mindgames
	{

//    legt eine kopie eines zufälligen dieners aus dem deck eures gegners auf das schlachtfeld.

        CardDB.Card copymin = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_182); // we take a icewindjety :D

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.callKid(copymin, p.ownMinions.Count, true);
		}

	}
}