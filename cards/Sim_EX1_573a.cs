// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_573a.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_573 a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ e x 1_573 a.
    /// </summary>
    internal class Sim_EX1_573a : SimTemplate
    {
        // demigodsfavor

        // verleiht euren anderen dienern +2/+2.
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
            List<Minion> temp = ownplay ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                p.minionGetBuffed(m, 2, 2);
            }
        }

        #endregion
    }
}