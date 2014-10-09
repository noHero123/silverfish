// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_006.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_006.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_006.
    /// </summary>
    internal class Sim_FP1_006 : SimTemplate
    {
        // deathcharger

        // ansturm. todesröcheln:/ fügt eurem helden 3 schaden zu.
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
            if (m.own)
            {
                p.minionGetDamageOrHeal(p.ownHero, 3);
            }
            else
            {
                p.minionGetDamageOrHeal(p.enemyHero, 3);
            }
        }

        #endregion
    }
}