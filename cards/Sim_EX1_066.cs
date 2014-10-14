// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_066.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_066.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_066.
    /// </summary>
    internal class Sim_EX1_066 : SimTemplate
    {
        // acidicswampooze

        // kampfschrei:/ zerstört die waffe eures gegners.
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
            p.lowerWeaponDurability(1000, !own.own);
        }

        #endregion
    }
}