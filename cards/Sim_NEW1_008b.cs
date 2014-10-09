// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_008b.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_008 b.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_008 b.
    /// </summary>
    internal class Sim_NEW1_008b : SimTemplate
    {
        // ancientsecrets

        // stellt 5 leben wieder her.
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
            int heal = own.own ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);
            p.minionGetDamageOrHeal(target, -heal);
        }

        #endregion
    }
}