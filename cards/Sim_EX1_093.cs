// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_093.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_093.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_093.
    /// </summary>
    class Sim_EX1_093 : SimTemplate
	{
	    // defenderofargus

// kampfschrei:/ verleiht benachbarten dienern +1/+1 und spott/.
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
            List<Minion> temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos)
                {
                    // position and position -1 because its not placed jet
                    m.taunt = true;
                    p.minionGetBuffed(m, 1, 1);
                }
            }
		}


	}
}