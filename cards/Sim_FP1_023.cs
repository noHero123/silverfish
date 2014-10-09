// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_023.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_023.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ f p 1_023.
    /// </summary>
    internal class Sim_FP1_023 : SimTemplate
    {
        // dark cultist
        // todo list
        #region Public Methods and Operators

        /// <summary>
        /// The on deathrattle.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            List<Minion> temp = new List<Minion>();

            if (m.own)
            {
                List<Minion> temp2 = new List<Minion>(p.ownMinions);
                temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));
                temp.AddRange(temp2);
            }
            else
            {
                List<Minion> temp2 = new List<Minion>(p.enemyMinions);
                temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
                temp.AddRange(temp2);
            }

            if (temp.Count >= 1)
            {
                if (m.own)
                {
                    Minion target = temp[0];
                    if (temp.Count >= 2 && target.taunt && !temp[1].taunt)
                    {
                        target = temp[1];
                    }

                    p.minionGetBuffed(target, 0, 3);
                }
                else
                {
                    Minion target = temp[0];
                    if (temp.Count >= 2 && !target.taunt && temp[1].taunt)
                    {
                        target = temp[1];
                    }

                    p.minionGetBuffed(target, 0, 3);
                }
            }
        }

        #endregion
    }
}