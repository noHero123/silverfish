// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_042.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_042.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_042.
    /// </summary>
    class Sim_CS2_042 : SimTemplate
	{
	    // fireelemental

// kampfschrei:/ verursacht 3 schaden.
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
            int dmg = 3;
            p.minionGetDamageOrHeal(target, dmg);
           
		}

	}
}