using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_006 : SimTemplate //alarmobot
	{

//    tauscht zu beginn eures zuges diesen diener gegen einen zufälligen diener auf eurer hand aus.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (p.isServer && triggerEffectMinion.own == turnStartOfOwner)
            {
                List<Handmanager.Handcard> temp2 = new List<Handmanager.Handcard>();
                List<Handmanager.Handcard> hand = (turnStartOfOwner) ? p.owncards : p.EnemyCards;
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (hc.card.type == CardDB.cardtype.MOB) temp2.Add(hc);
                }
                if (temp2.Count == 0) return;

                int random = p.getRandomNumber_SERVER(0, temp2.Count - 1);
                p.minionTransform(triggerEffectMinion, temp2[random].card);
                p.removeCard(temp2[random]);
                p.drawACard(CardDB.cardIDEnum.EX1_006, turnStartOfOwner, true);

                return;
            }


            if (turnStartOfOwner && triggerEffectMinion.own == turnStartOfOwner)
            {
                List<Handmanager.Handcard> temp2 = new List<Handmanager.Handcard>();
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.MOB) temp2.Add(hc);
                }
                temp2.Sort((a, b) => -a.card.Attack.CompareTo(b.card.Attack));//damage the stronges
                foreach (Handmanager.Handcard mins in temp2)
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(mins.card.cardIDenum);
                    p.minionTransform(triggerEffectMinion, c);
                    p.removeCard(mins);
                    p.drawACard(CardDB.cardIDEnum.EX1_006, true, true);
                    break;
                }
                return;
            }

            if (!turnStartOfOwner && triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 4, 4);
                triggerEffectMinion.Hp = triggerEffectMinion.maxHp;
            }
        }
	}
}