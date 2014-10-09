// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_304.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_304.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_304.
    /// </summary>
    class Sim_EX1_304 : SimTemplate
	{
	    // voidterror

// kampfschrei:/ vernichtet die benachbarten diener und verleiht ihm deren angriff und leben.
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

            int angr = 0;
            int hp = 0;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos || m.zonepos == own.zonepos - 1)
                {
                    angr += m.Angr;
                    hp += m.Hp;
                    p.minionGetDestroyed(m);
                }
            }

            p.minionGetBuffed(own, angr, hp);
		}


	}
}