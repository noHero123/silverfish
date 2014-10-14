// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_506.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_506.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_506.
    /// </summary>
    internal class Sim_EX1_506 : SimTemplate
    {
        // murloctidehunter
        #region Fields

        /// <summary>
        ///     The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_506a); // murlocscout

        #endregion

        // kampfschrei:/ ruft einen murlocspäher (1/1) herbei.
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
            p.callKid(this.kid, own.zonepos, own.own, true);
        }

        #endregion
    }
}