// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_126.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_126.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ e x 1_126.
    /// </summary>
    internal class Sim_EX1_126 : SimTemplate
    {
        // betrayal

        // zwingt einen feindlichen diener, seinen schaden benachbarten dienern zuzufügen.
        #region Public Methods and Operators

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
            // attack right neightbor
            if (target.Angr > 0)
            {
                int dmg = target.Angr;
                List<Minion> temp = ownplay ? p.enemyMinions : p.ownMinions;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.zonepos + 1 == target.zonepos || m.zonepos - 1 == target.zonepos)
                    {
                        int oldhp = m.Hp;
                        p.minionGetDamageOrHeal(m, dmg);
                        if (!target.silenced && target.handcard.card.name == CardDB.cardName.waterelemental
                            && m.Hp < oldhp)
                        {
                            m.frozen = true;
                        }

                        if (!target.silenced && m.Hp < oldhp && target.poisonous)
                        {
                            p.minionGetDestroyed(m);
                        }
                    }
                }
            }
        }

        #endregion
    }
}