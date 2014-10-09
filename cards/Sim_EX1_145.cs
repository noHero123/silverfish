// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_145.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_145.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_145.
    /// </summary>
    internal class Sim_EX1_145 : SimTemplate
    {
        // preparation

        // der nächste zauber, den ihr in diesem zug wirkt, kostet (3) weniger.
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
            if (ownplay)
            {
                p.playedPreparation = true;
            }
        }

        #endregion
    }
}