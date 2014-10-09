// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_006.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_006.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_006.
    /// </summary>
    class Sim_EX1_006 : SimTemplate
	{
	    // alarmobot

// tauscht zu beginn eures zuges diesen diener gegen einen zufälligen diener auf eurer hand aus.

        /// <summary>
        /// The on turn start trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="turnStartOfOwner">
        /// The turn start of owner.
        /// </param>
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner && triggerEffectMinion.own == turnStartOfOwner)
            {
                List<Handmanager.Handcard> temp2 = new List<Handmanager.Handcard>();
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.MOB) temp2.Add(hc);
                }

                temp2.Sort((a, b) => -a.card.Attack.CompareTo(b.card.Attack));// damage the stronges
                foreach (Handmanager.Handcard mins in temp2)
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(mins.card.cardIDenum);
                    p.minionTransform(triggerEffectMinion, c);
                    p.removeCard(mins);
                    p.drawACard(CardDB.cardName.alarmobot, true, true);
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