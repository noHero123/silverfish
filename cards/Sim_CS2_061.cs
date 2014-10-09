// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_061.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_061.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_061.
    /// </summary>
    class Sim_CS2_061 : SimTemplate
	{
	    // drainlife

// verursacht $2 schaden. stellt bei eurem helden #2 leben wieder her.

        /// <summary>
        /// The on card play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            int heal = ownplay ? p.getSpellHeal(2) : p.getEnemySpellHeal(2);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay)
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