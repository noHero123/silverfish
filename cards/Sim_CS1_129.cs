using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS1_129 : SimTemplate //innerfire
	{

//    setzt den angriff eines dieners auf einen wert, der seinem leben entspricht.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionSetAngrToHP(target);
		}

	}
}