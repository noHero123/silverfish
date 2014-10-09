// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_382.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_382.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_382.
    /// </summary>
    class Sim_EX1_382 : SimTemplate
	{
	    // aldorpeacekeeper

// kampfschrei:/ setzt den angriff eines feindlichen dieners auf 1.
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
            if(target != null) p.minionSetAngrToOne(target);
		}

	}
}