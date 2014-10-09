// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_559.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_559.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_559.
    /// </summary>
    class Sim_EX1_559 : SimTemplate
	{
	    // archmageantonidas

// erhaltet jedes mal einen „feuerball“-zauber auf eure hand, wenn ihr einen zauber wirkt.

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
            if (wasOwnCard == triggerEffectMinion.own && c.type == CardDB.cardtype.SPELL)
            {
                p.drawACard(CardDB.cardName.fireball, wasOwnCard, true);
            }
        }

	}
}