// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_408.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_408.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_408.
    /// </summary>
    class Sim_EX1_408 : SimTemplate
	{
	    // mortalstrike

// verursacht $4 schaden. verursacht stattdessen $6 schaden, wenn euer held max. 12 leben hat.

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
            int dmg = 0;

            if (ownplay)
            {
                dmg = (p.ownHero.Hp <= 12) ? p.getSpellDamageDamage(6) : p.getSpellDamageDamage(4);
            }
            else
            {
                dmg = (p.enemyHero.Hp <= 12) ? p.getEnemySpellDamageDamage(6) : p.getEnemySpellDamageDamage(4);
            }

            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}