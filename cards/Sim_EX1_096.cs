// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_096.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_096.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_096.
    /// </summary>
    internal class Sim_EX1_096 : SimTemplate
    {
        // loothoarder

        // todesröcheln:/ zieht eine karte.
        #region Public Methods and Operators

        /// <summary>
        /// The on deathrattle.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.unknown, m.own);
        }

        #endregion
    }
}