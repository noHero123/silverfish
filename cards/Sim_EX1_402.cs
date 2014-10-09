// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_402.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_402.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_402.
    /// </summary>
    class Sim_EX1_402 : SimTemplate
	{
	    // armorsmith

// erhaltet jedes mal 1 rüstung, wenn ein befreundeter diener schaden erleidet.

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
            if (triggerEffectMinion.own == ownDmgdmin)
            {
                if (triggerEffectMinion.own)
                {
                    p.ownHero.armor  += 1;
                }
                else
                {
                    p.enemyHero.armor += 1;
                }
            }
        }

	}
}