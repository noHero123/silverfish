// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_141.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_141.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_141.
    /// </summary>
    class Sim_CS2_141 : SimTemplate
	{
	    // ironforgerifleman

// kampfschrei:/ verursacht 1 schaden.
        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int dmg = 1;
            p.minionGetDamageOrHeal(target, dmg);
		}


	}
}