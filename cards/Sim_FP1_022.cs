using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_022 : SimTemplate //voidcaller
	{
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_301);//felguard
//    todesröcheln:/ legt einen zufälligen dämon aus eurer hand auf das schlachtfeld.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.isServer)
            {
                List<Handmanager.Handcard> temp = new List<Handmanager.Handcard>();
                List<Handmanager.Handcard> cards = (m.own) ? p.owncards : p.EnemyCards;

                foreach (Handmanager.Handcard hc in cards)
                {
                    if ((TAG_RACE)hc.card.race == TAG_RACE.DEMON)
                    {
                        temp.Add(hc);
                    }
                }

                if (temp.Count == 0) return;

                int rand = p.getRandomNumber_SERVER(0, temp.Count - 1);

                p.callKid(cards[rand].card, p.ownMinions.Count, m.own);
                p.removeCard_SERVER(cards[rand], m.own);

                return;
            }

            if (m.own)
            {
                List<Handmanager.Handcard> temp = new List<Handmanager.Handcard>();
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if ((TAG_RACE)hc.card.race == TAG_RACE.DEMON)
                    {
                        temp.Add(hc);
                    }
                }

                temp.Sort((x, y) => x.card.Attack.CompareTo(y.card.Attack));

                foreach (Handmanager.Handcard mnn in temp)
                {
                    p.callKid(mnn.card, p.ownMinions.Count, true);
                    p.removeCard(mnn);
                    break;
                }

            }
            else
            {
                if (p.enemyAnzCards >= 1)
                {
                    p.callKid(c, p.enemyMinions.Count , false);
                }
            }
        }

	}
}