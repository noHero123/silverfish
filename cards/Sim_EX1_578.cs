// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_578.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_578.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_578.
    /// </summary>
    class Sim_EX1_578 : SimTemplate
	{
	    // savagery

// fügt einem diener schaden zu, der dem angriff eures helden entspricht.
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
            int dmg = ownplay ? p.getSpellDamageDamage(p.ownHero.Angr) : p.getEnemySpellDamageDamage(p.enemyHero.Angr);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}