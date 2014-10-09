// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_044.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_044.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_044.
    /// </summary>
    class Sim_EX1_044 : SimTemplate
	{
	    // questingadventurer

// erhält jedes mal +1/+1, wenn ihr eine karte ausspielt.
        /// <summary>
        /// The on card is going to be played.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <param name="wasOwnCard">
        /// The was own card.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }
	}
}