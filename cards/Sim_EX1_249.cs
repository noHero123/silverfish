// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_249.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_249.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_249.
    /// </summary>
    internal class Sim_EX1_249 : SimTemplate
    {
        // barongeddon

        // fügt am ende eures zuges allen anderen charakteren 2 schaden zu.
        #region Public Methods and Operators

        /// <summary>
        /// The on turn ends trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="turnEndOfOwner">
        /// The turn end of owner.
        /// </param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (triggerEffectMinion.entitiyID != m.entitiyID)
                    {
                        p.minionGetDamageOrHeal(m, 2);
                    }
                }

                foreach (Minion m in p.ownMinions)
                {
                    if (triggerEffectMinion.entitiyID != m.entitiyID)
                    {
                        p.minionGetDamageOrHeal(m, 2);
                    }
                }

                p.minionGetDamageOrHeal(p.ownHero, 2);
                p.minionGetDamageOrHeal(p.enemyHero, 2);
            }
        }

        #endregion
    }
}