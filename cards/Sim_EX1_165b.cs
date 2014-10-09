// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_165b.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_165 b.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_165 b.
    /// </summary>
    internal class Sim_EX1_165b : SimTemplate
    {
        // bearform

        // +2 leben und spott/.
        #region Fields

        /// <summary>
        ///     The bear.
        /// </summary>
        private CardDB.Card bear = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t2);

        #endregion

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
            p.minionTransform(own, this.bear);
        }

        #endregion
    }
}