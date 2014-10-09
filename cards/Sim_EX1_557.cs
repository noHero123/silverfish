// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_557.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_557.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_557.
    /// </summary>
    class Sim_EX1_557 : SimTemplate
	{
	    // natpagle

// zu beginn eures zuges besteht eine chance von 50%, dass ihr eine zusätzliche karte zieht.
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
                p.drawACard(CardDB.cardName.unknown, turnStartOfOwner);
            }
        }

	}
}