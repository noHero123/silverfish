// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_165a.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_165 a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_165 a.
    /// </summary>
    internal class Sim_EX1_165a : SimTemplate
    {
        // catform

        // ansturm/
        #region Fields

        /// <summary>
        ///     The cat.
        /// </summary>
        private CardDB.Card cat = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t1);

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
            p.minionTransform(own, this.cat);
        }

        #endregion
    }
}