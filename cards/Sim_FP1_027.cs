// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_027.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_027.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ f p 1_027.
    /// </summary>
    class Sim_FP1_027 : SimTemplate
	{
	    // stoneskingargoyle

// stellt zu beginn eures zuges das volle leben dieses dieners wieder her.

        /// <summary>
        /// The on turn start trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="turnStartOfOwner">
        /// The turn start of owner.
        /// </param>
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                int heal = triggerEffectMinion.own ? p.getMinionHeal(triggerEffectMinion.maxHp - triggerEffectMinion.Hp) : p.getEnemyMinionHeal(triggerEffectMinion.maxHp - triggerEffectMinion.Hp);
                p.minionGetDamageOrHeal(triggerEffectMinion, -heal);
            }
        }

	}
}