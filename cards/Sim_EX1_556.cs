// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_556.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_556.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_556.
    /// </summary>
    internal class Sim_EX1_556 : SimTemplate
    {
        // harvestgolem

        // todesröcheln:/ ruft einen beschädigten golem (2/1) herbei.
        #region Fields

        /// <summary>
        ///     The card.
        /// </summary>
        private CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.skele21);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The on deathrattle.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="m">
        /// The m.
        /// </param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(this.card, m.zonepos - 1, m.own);
        }

        #endregion
    }
}