// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_155a.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_155 a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_155 a.
    /// </summary>
    internal class Sim_EX1_155a : SimTemplate
    {
        // markofnature

        // +4 angriff.
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
            p.minionGetBuffed(target, 4, 0);
        }

        #endregion
    }
}