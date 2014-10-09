// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_244.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_244.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_244.
    /// </summary>
    class Sim_EX1_244 : SimTemplate
    {
        // totemic might
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
            for (int i = 0; i < temp.Count;i++ )
            {
                if (temp[i].handcard.card.race == 21)
                {
                    // if minion is a totem, buff it
                    p.minionGetBuffed(temp[i], 0, 2);
                }
            }
        }

    }
}
