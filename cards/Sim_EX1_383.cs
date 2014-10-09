// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_383.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_383.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_383.
    /// </summary>
    internal class Sim_EX1_383 : SimTemplate
    {
        // tirionfordring
        #region Fields

        /// <summary>
        ///     The card.
        /// </summary>
        private CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_383t);

        #endregion

        // gottesschild/. spott/. todesröcheln:/ legt einen aschenbringer (5/3) an.
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
            p.equipWeapon(this.card, m.own);
        }

        #endregion
    }
}