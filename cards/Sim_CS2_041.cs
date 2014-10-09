// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_041.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_041.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_041.
    /// </summary>
    class Sim_CS2_041 : SimTemplate
	{
	    // ancestralhealing

// stellt das volle leben eines dieners wieder her und verleiht ihm spott/.
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
            target.taunt = true;
            int heal = ownplay? p.getSpellHeal(target.maxHp - target.Hp) : p.getEnemySpellHeal(target.maxHp - target.Hp);
            p.minionGetDamageOrHeal(target, heal);
		}

	}
}