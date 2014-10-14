// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_023.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_023.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_023.
    /// </summary>
    internal class Sim_CS2_023 : SimTemplate
    {
        // arcaneintellect

        // zieht 2 karten.
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
        }

        #endregion
    }
}