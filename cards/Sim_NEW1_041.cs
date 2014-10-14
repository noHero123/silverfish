// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_041.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_041.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ ne w 1_041.
    /// </summary>
    internal class Sim_NEW1_041 : SimTemplate
    {
        // Stampeding Kodo
        // todo list
        #region Public Methods and Operators

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
            List<Minion> temp2 = own.own ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
            temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp)); // destroys the weakest
            foreach (Minion enemy in temp2)
            {
                if (enemy.Angr <= 2)
                {
                    p.minionGetDestroyed(enemy);
                    break;
                }
            }
        }

        #endregion
    }
}