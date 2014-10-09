// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_203.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_203.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_203.
    /// </summary>
    class Sim_CS2_203 : SimTemplate
	{
	    // ironbeakowl

// kampfschrei:/ bringt einen diener zum schweigen/.
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
            if (target != null) p.minionGetSilenced(target);
		}


	}
}