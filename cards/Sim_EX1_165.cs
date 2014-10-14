// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_165.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_165.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_165.
    /// </summary>
    internal class Sim_EX1_165 : SimTemplate
    {
        // druidoftheclaw

        // wählt aus:/ ansturm/; oder +2 leben und spott/.
        #region Fields

        /// <summary>
        ///     The bear.
        /// </summary>
        private CardDB.Card bear = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t2);

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
            if (choice == 1)
            {
                p.minionTransform(own, this.cat);
            }

            if (choice == 2)
            {
                p.minionTransform(own, this.bear);
            }
        }

        #endregion
    }
}