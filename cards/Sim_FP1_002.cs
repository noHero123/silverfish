// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_002.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_002.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_002.
    /// </summary>
    internal class Sim_FP1_002 : SimTemplate
    {
        // hauntedcreeper
        #region Fields

        /// <summary>
        ///     The c.
        /// </summary>
        private CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_002t);

        #endregion

        // todesröcheln:/ ruft zwei spektrale spinnen (1/1) herbei.
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