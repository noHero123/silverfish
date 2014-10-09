// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_001.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_001.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_001.
    /// </summary>
    class Sim_EX1_001 : SimTemplate
	{
	    // lightwarden

// erhält jedes mal +2 angriff, wenn ein charakter geheilt wird.
        /// <summary>
        /// The on a hero got healed trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="ownerOfHeroGotHealed">
        /// The owner of hero got healed.
        /// </param>
        public override void onAHeroGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfHeroGotHealed)
        {
            p.minionGetBuffed(triggerEffectMinion, 2, 0);
        }

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
            p.minionGetBuffed(triggerEffectMinion, 2, 0);
        }

	}
}