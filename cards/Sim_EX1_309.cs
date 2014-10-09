// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_309.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_309.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_309.
    /// </summary>
    internal class Sim_EX1_309 : SimTemplate
    {
        // Siphon Soul
        // Vernichtet einen Diener. Stellt bei Eurem Helden #3 Leben wieder her.
        #region Public Methods and Operators

        /// <summary>
        /// The on card play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
            int heal = ownplay ? p.getSpellHeal(3) : p.getEnemySpellHeal(3);
            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
        }

        #endregion
    }
}