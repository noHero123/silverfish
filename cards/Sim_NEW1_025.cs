// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_025.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_025.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_025.
    /// </summary>
    internal class Sim_NEW1_025 : SimTemplate
    {
        // bloodsailcorsair

        // kampfschrei:/ zieht 1 haltbarkeit von der waffe eures gegners ab.
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
            p.lowerWeaponDurability(1, !own.own);
        }

        #endregion
    }
}