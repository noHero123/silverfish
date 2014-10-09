// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_178a.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_178 a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_178 a.
    /// </summary>
    class Sim_EX1_178a : SimTemplate
	{
	    // rooted

// +5 leben und spott/.
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
            p.minionGetBuffed(own, 0, 5);
            own.taunt = true;
		}


	}
}