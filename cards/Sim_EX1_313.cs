// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_313.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_313.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_313.
    /// </summary>
    class Sim_EX1_313 : SimTemplate
	{
	    // pitlord

// kampfschrei:/ fügt eurem helden 5 schaden zu.
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
            if (own.own)
            {
                p.minionGetDamageOrHeal(p.ownHero, 5);
            }
            else
            {
                p.minionGetDamageOrHeal(p.enemyHero, 5);
            }
		}


	}
}