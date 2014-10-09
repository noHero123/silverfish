// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_234.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_234.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_234.
    /// </summary>
    internal class Sim_CS2_234 : SimTemplate
    {
        // shadowwordpain

        // vernichtet einen diener mit max. 3 angriff.
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
            p.minionGetDestroyed(target);
        }

        #endregion
    }
}