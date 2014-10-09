// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_029.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_029.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_029.
    /// </summary>
    class Sim_CS2_029 : SimTemplate
	{
	    // fireball

// verursacht $6 schaden.
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
            int dmg = ownplay ? p.getSpellDamageDamage(6) : p.getEnemySpellDamageDamage(6);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}