// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_014.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_014.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_014.
    /// </summary>
    class Sim_NEW1_014 : SimTemplate
	{
	    // masterofdisguise

// kampfschrei:/ verleiht einem befreundeten diener verstohlenheit/.
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
            if (target != null) target.stealth = true;
		}


	}
}