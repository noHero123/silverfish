// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_188.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_188.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_188.
    /// </summary>
    internal class Sim_CS2_188 : SimTemplate
    {
        // abusivesergeant

        // kampfschrei:/ verleiht einem diener +2 angriff in diesem zug.
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
            if (target != null)
            {
                p.minionGetTempBuff(target, 2, 0);
            }
        }

        #endregion
    }
}