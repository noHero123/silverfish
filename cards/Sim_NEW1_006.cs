// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_006.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_006.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_006.
    /// </summary>
    internal class Sim_NEW1_006 : SimTemplate
    {
        // adrenalinerush

        // draw a card. combo:/ draw 2 cards instead.
        #region Public Methods and Operators

        /// <summary>
        /// The on card play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay);
            if (p.cardsPlayedThisTurn >= 1)
            {
                p.drawACard(CardDB.cardName.unknown, ownplay);
            }
        }

        #endregion
    }
}