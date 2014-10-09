// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_011.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_011.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_011.
    /// </summary>
    class Sim_CS2_011 : SimTemplate
	{
	    // savageroar

// verleiht euren charakteren +2 angriff in diesem zug.
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
            for (int i = 0; i < temp.Count; i++)
            {
                p.minionGetTempBuff(temp[i], 2, 0);
            }

            if (ownplay)
            {
                p.minionGetTempBuff(p.ownHero, 2, 0);
            }
            else
            {
                p.minionGetTempBuff(p.enemyHero, 2, 0);
            }
		}

	}
}