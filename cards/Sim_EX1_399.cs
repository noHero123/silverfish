// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_399.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_399.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_399.
    /// </summary>
    class Sim_EX1_399 : SimTemplate
	{
	    // gurubashiberserker

// erhält jedes mal +3 angriff, wenn dieser diener schaden erleidet.
        /// <summary>
        /// The on minion got dmg trigger.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        /// <param name="ownDmgdmin">
        /// The own dmgdmin.
        /// </param>
        public override void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, bool ownDmgdmin)
        {
            if (triggerEffectMinion.anzGotDmg>=1)
            {
                triggerEffectMinion.Angr += 3 * triggerEffectMinion.anzGotDmg;
                triggerEffectMinion.anzGotDmg = 0;
            }
        }

	}
}