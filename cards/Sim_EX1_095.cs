// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_095.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_095.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_095.
    /// </summary>
    class Sim_EX1_095 : SimTemplate
	{
	    // gadgetzanauctioneer

// zieht jedes mal eine karte, wenn ihr einen zauber wirkt.

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
            if (c.type == CardDB.cardtype.SPELL && wasOwnCard == triggerEffectMinion.own)
            {
                p.drawACard(CardDB.cardName.unknown, wasOwnCard);
            }

        }

	}
}