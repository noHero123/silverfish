// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_013.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_013.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_013.
    /// </summary>
    class Sim_FP1_013 : SimTemplate
	{
	    // kelthuzad

// ruft am ende jedes zuges alle befreundeten diener herbei, die in diesem zug gestorben sind.
        /// <summary>
        /// The on turn ends trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="turnEndOfOwner">
        /// The turn end of owner.
        /// </param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            foreach (GraveYardItem m in p.diedMinions.ToArray())
            {
                // toArray() because a knifejuggler could kill a minion due to the summon :D
                if (triggerEffectMinion.own == m.own)
                {
                    CardDB.Card card = CardDB.Instance.getCardDataFromID(m.cardid);
                    p.callKid(card, p.ownMinions.Count, m.own);
                }
            }
        }

	}

}