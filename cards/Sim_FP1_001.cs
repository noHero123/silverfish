// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_001.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_001.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_001.
    /// </summary>
    internal class Sim_FP1_001 : SimTemplate
    {
        // zombiechow

        // todesröcheln:/ stellt beim feindlichen helden 5 leben wieder her.
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
            int heal = m.own ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);

            if (m.own)
            {
                p.minionGetDamageOrHeal(p.enemyHero, -heal);
            }
            else
            {
                p.minionGetDamageOrHeal(p.ownHero, -heal);
            }
        }

        #endregion
    }
}