// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_088.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_088.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_088.
    /// </summary>
    class Sim_CS2_088 : SimTemplate
	{
	    // guardianofkings

// kampfschrei:/ stellt bei eurem helden 6 leben wieder her.
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
            int heal = own.own ? p.getMinionHeal(6) : p.getEnemyMinionHeal(6);

            if (own.own)
            {
                p.minionGetDamageOrHeal(p.ownHero, -heal);
            }
            else
            {
                p.minionGetDamageOrHeal(p.enemyHero, -heal);
            }
		}


	}
}