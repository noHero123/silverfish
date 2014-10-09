// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_584.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_584.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_584.
    /// </summary>
    class Sim_EX1_584 : SimTemplate
    {
        // ancientmage

        // kampfschrei:/ verleiht benachbarten dienern zauberschaden +1/.
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
                if (m.zonepos == own.zonepos || m.zonepos + 1 == own.zonepos)
                {
                    m.spellpower++;
                    if (own.own)
                    {
                        p.spellpower++;
                    }
                    else
                    {
                        p.enemyspellpower++;
                    }
                }
            }
        }
    }
}