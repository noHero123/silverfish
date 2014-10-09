// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_306.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_306.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_306.
    /// </summary>
    class Sim_EX1_306 : SimTemplate
	{
	    // succubus

// kampfschrei:/ werft eine zufällige karte ab.
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
            if (own.own)
            {
                p.owncarddraw -= Math.Min(1, p.owncards.Count);
                p.owncards.RemoveRange(0, Math.Min(1, p.owncards.Count));
            }
            else
            {
                p.enemycarddraw--;
                p.enemyAnzCards--;
            }
		}

	}
}