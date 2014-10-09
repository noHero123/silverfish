// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_032.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_032.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_032.
    /// </summary>
    class Sim_CS2_032 : SimTemplate
	{
	    // flamestrike

// fügt allen feindlichen dienern $4 schaden zu.
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
            p.allMinionOfASideGetDamage(!ownplay, dmg);
		}

	}
}