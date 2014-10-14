// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_055.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_055.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_055.
    /// </summary>
    internal class Sim_EX1_055 : SimTemplate
    {
        // manaaddict

        // erhält jedes mal +2 angriff in diesem zug, wenn ihr einen zauber wirkt.
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
                p.minionGetTempBuff(triggerEffectMinion, 2, 0);
            }
        }

        #endregion
    }
}