// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_410.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_410.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_410.
    /// </summary>
    class Sim_EX1_410 : SimTemplate
	{
	    // shieldslam

// fügt einem diener für jeden eurer rüstungspunkte 1 schaden zu.

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


            int dmg = ownplay ? p.getSpellDamageDamage(p.ownHero.armor) : p.getEnemySpellDamageDamage(p.enemyHero.armor);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}