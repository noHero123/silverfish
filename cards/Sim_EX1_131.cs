// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_131.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_131.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_131.
    /// </summary>
    class Sim_EX1_131 : SimTemplate
    {
        // defiasringleader
        /// <summary>
        /// The card.
        /// </summary>
        private CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_131t);

        // combo:/ ruft einen banditen der defias (2/1) herbei.
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
            if (p.cardsPlayedThisTurn >= 1)
            {
                p.callKid(this.card, own.zonepos, own.own);
            }
        }
    }
}