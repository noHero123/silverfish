using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_237 : SimTemplate //starvingbuzzard
	{

//    zieht jedes mal eine karte, wenn ihr ein wildtier herbeiruft.
        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own && (TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.PET)
            {
                p.drawACard(CardDB.cardName.unknown, triggerEffectMinion.own);
            }
        }

	}
}