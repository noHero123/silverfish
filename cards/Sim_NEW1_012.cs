// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_012.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_012.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_012.
    /// </summary>
    internal class Sim_NEW1_012 : SimTemplate
    {
        // manawyrm

        // erhält jedes mal +1 angriff, wenn ihr einen zauber wirkt.
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
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL)
            {
                triggerEffectMinion.Angr++;
            }
        }

        #endregion
    }
}