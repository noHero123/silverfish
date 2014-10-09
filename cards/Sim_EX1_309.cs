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
    /// The sim_ e x 1_309.
    /// </summary>
    class Sim_EX1_309 : SimTemplate
    {
        // Siphon Soul
        // Vernichtet einen Diener. Stellt bei Eurem Helden #3 Leben wieder her.

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
            if (ownplay)
            {
                p.minionGetDamageOrHeal(p.ownHero, -heal);
            }
            else
            {
                p.minionGetDamageOrHeal(p.enemyHero, -heal);
            }
        }

    }
}
