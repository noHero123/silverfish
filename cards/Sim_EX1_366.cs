using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_366 : SimTemplate //swordofjustice
	{
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_366);

//    jedes mal, wenn ihr einen diener herbeiruft, erhält dieser +1/+1 und diese waffe verliert 1 haltbarkeit.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(card,ownplay);
		}

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own )
            {
                p.minionGetBuffed(summonedMinion, 1, 1);
                p.lowerWeaponDurability(1, triggerEffectMinion.own);
            }
        }
	}
}