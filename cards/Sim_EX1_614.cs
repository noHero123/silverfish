// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_614.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_614.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_614.
    /// </summary>
    internal class Sim_EX1_614 : SimTemplate
    {
        // illidanstormrage
        #region Fields

        /// <summary>
        ///     The d.
        /// </summary>
        private CardDB.Card d = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_614t); // flameofazzinoth

        #endregion

        // beschwört jedes mal eine flamme von azzinoth (2/1), wenn ihr eine karte ausspielt.
        #region Public Methods and Operators

        /// <summary>
        /// The on card is going to be played.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <param name="wasOwnCard">
        /// The was own card.
        /// </param>
        /// <param name="triggerEffectMinion">
        /// The trigger effect minion.
        /// </param>
        public override void onCardIsGoingToBePlayed(
            Playfield p, 
            CardDB.Card c, 
            bool wasOwnCard, 
            Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own)
            {
                p.callKid(this.d, triggerEffectMinion.zonepos, triggerEffectMinion.own);
            }
        }

        #endregion
    }
}