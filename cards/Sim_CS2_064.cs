// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_064.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_064.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_064.
    /// </summary>
    class Sim_CS2_064 : SimTemplate
	{
	    // dreadinfernal

// kampfschrei:/ fügt allen anderen charakteren 1 schaden zu.
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
            p.allCharsGetDamage(dmg); // dreadinfernal is not on board yet!
		}
	}
}