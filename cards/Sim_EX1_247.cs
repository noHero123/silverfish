// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_247.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_247.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_247.
    /// </summary>
    internal class Sim_EX1_247 : SimTemplate
    {
        // stormforgedaxe
        #region Fields

        /// <summary>
        ///     The card.
        /// </summary>
        private CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_247);

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
            p.equipWeapon(this.card, ownplay);
            if (ownplay)
            {
                p.ueberladung ++;
            }
        }

        #endregion
    }
}