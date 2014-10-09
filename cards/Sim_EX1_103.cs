// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_103.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_103.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_103.
    /// </summary>
    class Sim_EX1_103 : SimTemplate
    {
        // Coldlight Seer

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

            for (int i = 0; i < temp.Count; i++)
            {
                if((TAG_RACE)temp[i].handcard.card.race == TAG_RACE.MURLOC) p.minionGetBuffed(temp[i], 0, 2);
            }
        }
    }
}
