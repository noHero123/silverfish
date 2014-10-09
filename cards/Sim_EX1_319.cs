// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_319.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_319.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_319.
    /// </summary>
    class Sim_EX1_319 : SimTemplate
	{
	    // flameimp

// kampfschrei:/ fügt eurem helden 3 schaden zu.
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
                p.minionGetDamageOrHeal(p.ownHero, 3);
            }
            else
            {
                p.minionGetDamageOrHeal(p.enemyHero, 3);
            }
		}


	}
}