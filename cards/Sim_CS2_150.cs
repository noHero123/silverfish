// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_150.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_150.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_150.
    /// </summary>
    class Sim_CS2_150 : SimTemplate
	{
	    // stormpikecommando

// kampfschrei:/ verursacht 2 schaden.
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
            p.minionGetDamageOrHeal(target, 2);
		}


	}
}