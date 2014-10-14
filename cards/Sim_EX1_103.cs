// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_103.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_103.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ e x 1_103.
    /// </summary>
    internal class Sim_EX1_103 : SimTemplate
    {
        // Coldlight Seer
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

            foreach (Minion t in temp)
            {
                if ((TAG_RACE)t.handcard.card.race == TAG_RACE.MURLOC)
                {
                    p.minionGetBuffed(t, 0, 2);
                }
            }
        }

        #endregion
    }
}