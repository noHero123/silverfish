// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_046.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_046.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ c s 2_046.
    /// </summary>
    internal class Sim_CS2_046 : SimTemplate
    {
        // bloodlust

        // verleiht euren dienern +3 angriff in diesem zug.
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
                p.minionGetTempBuff(m, 3, 0);
            }
        }

        #endregion
    }
}