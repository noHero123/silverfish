// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_607.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_607.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_607.
    /// </summary>
    class Sim_EX1_607 : SimTemplate
	{
	    // innerrage

// fügt einem diener $1 schaden zu. der diener erhält +2 angriff.

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
            int dmg = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
            p.minionGetTempBuff(target, 2, 0);
		}

	}
}