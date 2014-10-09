// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_003.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_003.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_003.
    /// </summary>
    internal class Sim_CS2_003 : SimTemplate
    {
        // Mind Vision
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
            int anz = ownplay ? p.enemyAnzCards : p.owncards.Count;
            if (anz >= 1)
            {
                p.drawACard(CardDB.cardName.unknown, ownplay, true);
            }
        }

        #endregion
    }
}