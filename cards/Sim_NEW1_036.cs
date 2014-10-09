// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_036.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_036.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ ne w 1_036.
    /// </summary>
    internal class Sim_NEW1_036 : SimTemplate
    {
        // commanding shout
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
            for (int i = 0; i < temp.Count; i++)
            {
                temp[i].cantLowerHPbelowONE = true;
            }

            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

        #endregion
    }
}