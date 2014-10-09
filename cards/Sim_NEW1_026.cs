// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_026.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_026.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_026.
    /// </summary>
    class Sim_NEW1_026 : SimTemplate
    {
        // Violet Teacher
        /// <summary>
        /// The card.
        /// </summary>
        public CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_026t);

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
        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && c.type == CardDB.cardtype.SPELL)
            {
                int place = wasOwnCard? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(this.card, place, wasOwnCard);
            }
        }

    }

}
