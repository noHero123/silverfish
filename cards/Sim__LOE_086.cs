using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_086 : SimTemplate //Summoning Stone
	{

        CardDB.Card kid0 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_231);

        //    Whenever you cast a spell, summon a random minion of the same Cost.
        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL)
            {

                int pos = (wasOwnCard) ? p.ownMinions.Count : p.enemyMinions.Count;

                if (p.isServer)
                {
                    //TODO
                    p.callKid(kid0, pos, wasOwnCard, true);
                    return;
                }

                //summon a wisp ( its a 1/1)
                p.callKid(kid0, pos, wasOwnCard, true);

                Minion newkid = (wasOwnCard) ? p.ownMinions[p.ownMinions.Count-1] : p.enemyMinions[p.enemyMinions.Count - 1];
                //buff the wisp according to average minion attack/health
                if (c.cost == 1)
                {
                    p.minionGetBuffed(newkid, 0, 1);//avg is 1.3 / 1.69
                }
                if (c.cost == 2)
                {
                    p.minionGetBuffed(newkid, 1, 1);//avg is 1.9 / 2.44
                }
                if (c.cost == 3)
                {
                    p.minionGetBuffed(newkid, 2, 2);//avg is 2.6 / 3.1
                }
                if (c.cost == 4)
                {
                    p.minionGetBuffed(newkid, 2, 3); //avg is 3.2 / 4.3
                }
                if (c.cost == 5)
                {
                    p.minionGetBuffed(newkid, 3, 4); //avg is 4.2 / 4.6
                }
                if (c.cost == 6)
                {
                    p.minionGetBuffed(newkid, 4, 4); //avg is 5.2/5.3
                }
                if (c.cost == 7)
                {
                    p.minionGetBuffed(newkid, 5, 5); //avg is 6.1/6.1
                }
                if (c.cost == 8)
                {
                    p.minionGetBuffed(newkid, 5, 6); //avg is 6.2/7.4
                }
                if (c.cost == 9)
                {
                    p.minionGetBuffed(newkid, 6, 7); //avg is 7.1/8.3
                }
                if (c.cost == 10)
                {
                    p.minionGetBuffed(newkid, 8, 8); // avg is 8.75 / 8.75
                }

            }
        }

	}
}