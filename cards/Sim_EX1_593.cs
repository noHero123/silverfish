// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_593.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_593.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_593.
    /// </summary>
    internal class Sim_EX1_593 : SimTemplate
    {
        // nightblade

        // kampfschrei: /fügt dem feindlichen helden 3 schaden zu.
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
            if (own.own)
            {
                p.minionGetDamageOrHeal(p.enemyHero, 3);
            }
            else
            {
                p.minionGetDamageOrHeal(p.ownHero, 3);
            }
        }

        #endregion
    }
}