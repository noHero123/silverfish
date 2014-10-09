// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_058.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_058.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_058.
    /// </summary>
    class Sim_EX1_058 : SimTemplate
	{
	    // sunfuryprotector

// kampfschrei:/ verleiht benachbarten dienern spott/.
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
                    m.taunt = true;
                }
            }
		}

	}
}