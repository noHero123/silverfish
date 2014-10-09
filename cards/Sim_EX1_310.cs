// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_310.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_310.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System;

    /// <summary>
    ///     The sim_ e x 1_310.
    /// </summary>
    internal class Sim_EX1_310 : SimTemplate
    {
        // doomguard

        // ansturm/. kampfschrei:/ werft zwei zufällige karten ab.
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
            if (own.own)
            {
                p.owncarddraw -= Math.Min(2, p.owncards.Count);
                p.owncards.RemoveRange(0, Math.Min(2, p.owncards.Count));
            }
        }

        #endregion
    }
}