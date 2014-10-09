// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_279.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_279.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_279.
    /// </summary>
    class Sim_EX1_279 : SimTemplate
	{
	    // pyroblast

// verursacht $10 schaden.

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
            int dmg = ownplay ? p.getSpellDamageDamage(10) : p.getEnemySpellDamageDamage(10);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}