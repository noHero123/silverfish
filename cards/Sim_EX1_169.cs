using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_169 : SimTemplate //innervate
	{

//    erhaltet 2 manakristalle nur für diesen zug.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.mana = Math.Min(p.mana + 2, 10);
		}

	}
}