// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_158.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_158.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_158.
    /// </summary>
    class Sim_EX1_158 : SimTemplate
	{
	    // souloftheforest

// verleiht euren dienern „todesröcheln:/ ruft einen treant (2/2) herbei.“

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
            List<Minion> temp = ownplay ? p.ownMinions : p.enemyMinions;

            foreach (Minion m in temp)
            {
                m.souloftheforest++;
            }
		}

	}
}