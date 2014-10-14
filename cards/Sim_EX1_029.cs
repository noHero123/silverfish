// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_029.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_029.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_029.
    /// </summary>
    internal class Sim_EX1_029 : SimTemplate
    {
        // lepergnome

        // todesröcheln:/ fügt dem feindlichen helden 2 schaden zu.
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
            p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, 2);
        }

        #endregion
    }
}