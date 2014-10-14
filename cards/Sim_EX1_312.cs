// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_312.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_312.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_312.
    /// </summary>
    internal class Sim_EX1_312 : SimTemplate
    {
        // twistingnether

        // vernichtet alle diener.
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
            p.allMinionsGetDestroyed();
        }

        #endregion
    }
}