// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_011.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_011.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_011.
    /// </summary>
    internal class Sim_FP1_011 : SimTemplate
    {
        // webspinner

        // todesröcheln:/ fügt eurer hand ein zufälliges wildtier hinzu.
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
            p.drawACard(CardDB.cardName.rivercrocolisk, m.own, true);
        }

        #endregion
    }
}