// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_625.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_625.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_625.
    /// </summary>
    internal class Sim_EX1_625 : SimTemplate
    {
        // shadowform

        // eure heldenfähigkeit wird zu „verursacht 2 schaden“. wenn euer held bereits schattengestalt angenommen hat: 3 schaden.
        #region Fields

        /// <summary>
        ///     The mindspike.
        /// </summary>
        private CardDB.Card mindspike = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_625t);

        /// <summary>
        ///     The shatter.
        /// </summary>
        private CardDB.Card shatter = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_625t2);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The on card play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                if (p.ownHeroAblility.card.cardIDenum == CardDB.cardIDEnum.CS1h_001)
                {
                    // lesser heal becomes mind spike
                    p.ownHeroAblility.card = this.mindspike;
                    p.ownAbilityReady = true;
                }
                else
                {
                    p.ownHeroAblility.card = this.shatter; // mindspike becomes mind shatter
                    p.ownAbilityReady = true;
                }
            }
            else
            {
                if (p.enemyHeroAblility.card.cardIDenum == CardDB.cardIDEnum.CS1h_001)
                {
                    // lesser heal becomes mind spike
                    p.enemyHeroAblility.card = this.mindspike;
                }
                else
                {
                    p.enemyHeroAblility.card = this.shatter; // mindspike becomes mind shatter
                }
            }
        }

        #endregion
    }
}