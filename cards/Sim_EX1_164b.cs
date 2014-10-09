// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_164b.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_164 b.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_164 b.
    /// </summary>
    internal class Sim_EX1_164b : SimTemplate
    {
        // nourish

        // zieht 3 karten.
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
            p.drawACard(CardDB.cardName.unknown, ownplay);
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

        #endregion
    }
}