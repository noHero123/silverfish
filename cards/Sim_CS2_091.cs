// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_091.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_091.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_091.
    /// </summary>
    internal class Sim_CS2_091 : SimTemplate
    {
        // lightsjustice
        #region Fields

        /// <summary>
        ///     The w.
        /// </summary>
        private CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_091);

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
            p.equipWeapon(this.w, ownplay);
        }

        #endregion
    }
}