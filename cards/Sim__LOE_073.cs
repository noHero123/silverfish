using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_073 : SimTemplate //Fossilized devilsaur
	{
        //BC: if you control a beast, gain taunt

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.handcard.card.race == TAG_RACE.PET)
                {
                    own.taunt = true;
                    break;
                }
            }
        }

	}

}
