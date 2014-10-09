// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_124.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_124.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_124.
    /// </summary>
    class Sim_EX1_124 : SimTemplate
	{
	    // eviscerate

// verursacht $2 schaden. combo:/ verursacht stattdessen $4 schaden.
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
            int dmg = ownplay ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            if (p.cardsPlayedThisTurn == 0) dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}