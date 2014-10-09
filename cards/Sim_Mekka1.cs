// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_Mekka1.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ mekka 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ mekka 1.
    /// </summary>
    class Sim_Mekka1 : SimTemplate
	{
	    // homingchicken

// vernichtet zu beginn eures zuges diesen diener und zieht 3 karten.

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
            if (turnStartOfOwner == triggerEffectMinion.own)
            {
                p.minionGetDestroyed(triggerEffectMinion);
                p.drawACard(CardDB.cardName.unknown, turnStartOfOwner);
                p.drawACard(CardDB.cardName.unknown, turnStartOfOwner);
                p.drawACard(CardDB.cardName.unknown, turnStartOfOwner);
            }
        }

	}
}