// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_617.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_617.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ e x 1_617.
    /// </summary>
    internal class Sim_EX1_617 : SimTemplate
    {
        // deadlyshot

        // vernichtet einen zufälligen feindlichen diener.
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
            List<Minion> temp2 = ownplay ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
            temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
            foreach (Minion enemy in temp2)
            {
                p.minionGetDestroyed(enemy);
                break;
            }
        }

        #endregion
    }
}