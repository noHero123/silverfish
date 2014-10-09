// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_534.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_534.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_534.
    /// </summary>
    internal class Sim_EX1_534 : SimTemplate
    {
        // savannahhighmane

        // todesröcheln:/ ruft zwei hyänen (2/2) herbei.#
        #region Fields

        /// <summary>
        ///     The c.
        /// </summary>
        private CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_534t); // hyena

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
            p.callKid(this.c, m.zonepos - 1, m.own);
            p.callKid(this.c, m.zonepos - 1, m.own);
        }

        #endregion
    }
}