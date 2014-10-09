// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_117.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_117.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_117.
    /// </summary>
    class Sim_CS2_117 : SimTemplate
	{
	    // earthenringfarseer

// kampfschrei:/ stellt 3 leben wieder her.
        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int heal = own.own ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
            p.minionGetDamageOrHeal(target, -heal);
		}

	}
}