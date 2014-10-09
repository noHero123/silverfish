// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_398.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_398.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_398.
    /// </summary>
    internal class Sim_EX1_398 : SimTemplate
    {
        // Arathi Weaponsmith
        #region Fields

        /// <summary>
        ///     The wcard.
        /// </summary>
        private CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_398t); // battleaxe

        #endregion

        #region Public Methods and Operators

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
            p.equipWeapon(this.wcard, own.own);
        }

        #endregion
    }
}