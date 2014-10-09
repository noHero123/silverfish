// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_050.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_050.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_050.
    /// </summary>
    internal class Sim_EX1_050 : SimTemplate
    {
        // coldlightoracle

        // kampfschrei:/ jeder spieler zieht 2 karten.
        #region Public Methods and Operators

        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, true);
            p.drawACard(CardDB.cardName.unknown, true);
            p.drawACard(CardDB.cardName.unknown, false);
            p.drawACard(CardDB.cardName.unknown, false);
        }

        #endregion
    }
}