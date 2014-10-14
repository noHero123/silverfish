// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_016.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_016.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ f p 1_016.
    /// </summary>
    internal class Sim_FP1_016 : SimTemplate
    {
        // wailingsoul

        // kampfschrei:/ bringt eure anderen diener zum schweigen/.
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
            List<Minion> temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                p.minionGetSilenced(m);
            }
        }

        #endregion
    }
}