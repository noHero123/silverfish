// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_235.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_235.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_235.
    /// </summary>
    class Sim_CS2_235 : SimTemplate
	{
	    // northshirecleric

// zieht jedes mal eine karte, wenn ein diener geheilt wird.

        /// <summary>
        /// The on a minion got healed trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="ownerOfMinionGotHealed">
        /// The owner of minion got healed.
        /// </param>
        public override void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfMinionGotHealed)
        {
            p.drawACard(CardDB.cardName.unknown, triggerEffectMinion.own);
        }

	}
}