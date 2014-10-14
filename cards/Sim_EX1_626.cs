// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_626.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_626.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_626.
    /// </summary>
    internal class Sim_EX1_626 : SimTemplate
    {
        // massdispel

        // bringt alle feindlichen diener zum schweigen/. zieht eine karte.
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
            p.allMinionsGetSilenced(!ownplay);
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

        #endregion
    }
}