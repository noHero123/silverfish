// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_097.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_097.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_097.
    /// </summary>
    internal class Sim_EX1_097 : SimTemplate
    {
        // abomination

        // spott/. todesröcheln:/ fügt allen charakteren 2 schaden zu.
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
            p.allCharsGetDamage(2);
        }

        #endregion
    }
}