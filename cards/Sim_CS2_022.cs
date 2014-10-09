// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_022.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_022.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_022.
    /// </summary>
    internal class Sim_CS2_022 : SimTemplate
    {
        // Polymorph
        #region Fields

        /// <summary>
        ///     The sheep.
        /// </summary>
        private CardDB.Card sheep = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_tk1);

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
            p.minionTransform(target, this.sheep);
        }

        #endregion
    }
}