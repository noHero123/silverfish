// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_621.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_621.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_621.
    /// </summary>
    class Sim_EX1_621 : SimTemplate
	{
	    // circleofhealing

// stellt bei allen dienern #4 leben wieder her.

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
            int heal = ownplay ? p.getSpellHeal(4) : p.getEnemySpellHeal(4);
            p.allMinionsGetDamage(-heal);
		}

	}
}