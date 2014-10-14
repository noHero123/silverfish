// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_007.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_007.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_007.
    /// </summary>
    internal class Sim_FP1_007 : SimTemplate
    {
        // nerubianegg
        #region Fields

        /// <summary>
        ///     The c.
        /// </summary>
        private CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_007t); // nerubian

        #endregion

        // todesröcheln:/ ruft einen neruber (4/4) herbei.
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
        }

        #endregion
    }
}