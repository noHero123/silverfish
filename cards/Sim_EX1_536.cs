// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_536.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_536.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_536.
    /// </summary>
    internal class Sim_EX1_536 : SimTemplate
    {
        // eaglehornbow

        // erhält jedes mal +1 haltbarkeit, wenn ein eigenes geheimnis/ aufgedeckt wird.
        #region Fields

        /// <summary>
        ///     The weapon.
        /// </summary>
        private CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_536);

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
            p.equipWeapon(this.weapon, ownplay);
        }

        #endregion
    }
}