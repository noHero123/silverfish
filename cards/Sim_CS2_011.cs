// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_011.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_011.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ c s 2_011.
    /// </summary>
    internal class Sim_CS2_011 : SimTemplate
    {
        // savageroar

        // verleiht euren charakteren +2 angriff in diesem zug.
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
            foreach (Minion t in temp)
            {
                p.minionGetTempBuff(t, 2, 0);
            }

            p.minionGetTempBuff(ownplay ? p.ownHero : p.enemyHero, 2, 0);
        }

        #endregion
    }
}