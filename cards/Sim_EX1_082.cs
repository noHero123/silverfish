// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_082.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_082.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_082.
    /// </summary>
    class Sim_EX1_082 : SimTemplate
    {
        // madbomber
        // todo make it better

        // kampfschrei:/ verursacht 3 schaden, der zufällig auf alle anderen charaktere aufgeteilt wird.
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
            int anz = 3;
            for (int i = 0; i < anz; i++)
            {
                if (p.ownHero.Hp <= anz)
                {
                    p.minionGetDamageOrHeal(p.ownHero, 1);
                    continue;
                }

                List<Minion> temp = new List<Minion>(p.enemyMinions);
                if (temp.Count == 0)
                {
                    temp.AddRange(p.ownMinions);
                }

                temp.Sort((a, b) => a.Hp.CompareTo(b.Hp)); // destroys the weakest

                foreach (Minion m in temp)
                {
                    p.minionGetDamageOrHeal(m, 1);
                    break;
                }

                p.minionGetDamageOrHeal(p.enemyHero, 1);
            }
        }
    }
}