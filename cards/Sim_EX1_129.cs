// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_129.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_129.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_129.
    /// </summary>
    class Sim_EX1_129 : SimTemplate
	{
	    // fanofknives

// fügt allen feindlichen dienern $1 schaden zu. zieht eine karte.
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
            p.allMinionOfASideGetDamage(!ownplay, dmg);
            p.drawACard(CardDB.cardName.unknown, ownplay);
		}

	}
}