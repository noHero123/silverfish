// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_624.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_624.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_624.
    /// </summary>
    class Sim_EX1_624 : SimTemplate
	{
	    // holyfire

// verursacht $5 schaden. stellt bei eurem helden #5 leben wieder her.
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
            int dmg = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
            int heal = ownplay ? p.getSpellHeal(5) : p.getEnemySpellHeal(5);
            if (ownplay) p.minionGetDamageOrHeal(p.ownHero, -heal);
            else p.minionGetDamageOrHeal(p.enemyHero, -heal);
		}

	}
}