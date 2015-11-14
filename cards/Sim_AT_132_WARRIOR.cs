using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_132_WARRIOR : SimTemplate //armorup
	{

        //    heldenfähigkeit Gain 4 Armor.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 4);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 4);
            }
		}

	}
}