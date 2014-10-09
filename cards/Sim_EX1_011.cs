// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_011.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_011.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_011.
    /// </summary>
    internal class Sim_EX1_011 : SimTemplate
    {
        // voodoodoctor

        // kampfschrei:/ stellt 2 leben wieder her.
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
            int heal = own.own ? p.getMinionHeal(2) : p.getEnemyMinionHeal(2);
            p.minionGetDamageOrHeal(target, -heal);
        }

        #endregion
    }
}