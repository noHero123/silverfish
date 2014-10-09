// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_094.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_094.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_094.
    /// </summary>
    class Sim_CS2_094 : SimTemplate
	{
	    // hammerofwrath

// verursacht $3 schaden. zieht eine karte.
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
            p.minionGetDamageOrHeal(target, dmg);
            p.drawACard(CardDB.cardName.unknown, ownplay);
		}

	}
}