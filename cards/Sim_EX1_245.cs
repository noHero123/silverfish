// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_245.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_245.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_245.
    /// </summary>
    class Sim_EX1_245 : SimTemplate
	{
	    // earthshock

// bringt einen diener zum schweigen/ und fügt ihm dann $1 schaden zu.

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
            p.minionGetSilenced(target);
            int dmg = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}