// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_009.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_009.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_009.
    /// </summary>
    class Sim_NEW1_009 : SimTemplate
	{
	    // healingtotem

// stellt am ende eures zuges bei allen befreundeten dienern 1 leben wieder her.

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
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int heal = triggerEffectMinion.own ? p.getMinionHeal(1) : p.getEnemyMinionHeal(1);
                p.allMinionOfASideGetDamage(turnEndOfOwner, -heal);
            }
        }

	}
}