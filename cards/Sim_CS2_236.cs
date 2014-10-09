// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_236.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_236.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_236.
    /// </summary>
    internal class Sim_CS2_236 : SimTemplate
    {
        // divinespirit

        // verdoppelt das leben eines dieners.
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
            p.minionGetBuffed(target, 0, target.Hp);
        }

        #endregion
    }
}