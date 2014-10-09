// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_303.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_303.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_303.
    /// </summary>
    class Sim_EX1_303 : SimTemplate
	{
	    // shadowflame

// vernichtet einen befreundeten diener und fügt allen feindlichen dienern schaden zu, der seinem angriff entspricht.
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
            int damage1 = ownplay ? p.getSpellDamageDamage(target.Angr) : p.getEnemySpellDamageDamage(target.Angr);

            p.minionGetDestroyed(target);

            p.allMinionOfASideGetDamage(!ownplay, damage1);

		}

	}
}