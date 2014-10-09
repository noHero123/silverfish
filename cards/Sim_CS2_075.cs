// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_075.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_075.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_075.
    /// </summary>
    class Sim_CS2_075 : SimTemplate
	{
	    // sinisterstrike

// fügt dem feindlichen helden $3 schaden zu.
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
            int dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            if (ownplay)
            {
                p.minionGetDamageOrHeal(p.enemyHero, dmg);
            }
            else
            {
                p.minionGetDamageOrHeal(p.ownHero, dmg);
            }
                
		}

	}
}