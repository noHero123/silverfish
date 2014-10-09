// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_100.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_100.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_100.
    /// </summary>
    internal class Sim_EX1_100 : SimTemplate
    {
        // lorewalkercho

        // wenn ein spieler einen zauber wirkt, erhält der andere spieler eine kopie desselben auf seine hand.
        #region Public Methods and Operators

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
        public override void onCardIsGoingToBePlayed(
            Playfield p, 
            CardDB.Card c, 
            bool wasOwnCard, 
            Minion triggerEffectMinion)
        {
            if (c.type == CardDB.cardtype.SPELL)
            {
                p.drawACard(c.name, !wasOwnCard, true);
            }
        }

        #endregion
    }
}