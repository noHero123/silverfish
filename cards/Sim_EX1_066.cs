using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_066 : SimTemplate //acidicswampooze
	{

//    kampfschrei:/ zerstört die waffe eures gegners.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.lowerWeaponDurability(1000, !own.own);
		}


	}
}