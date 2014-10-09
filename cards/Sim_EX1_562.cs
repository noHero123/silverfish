// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_562.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_562.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_562.
    /// </summary>
    internal class Sim_EX1_562 : SimTemplate
    {
        // onyxia
        #region Fields

        /// <summary>
        ///     The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_116t); // whelp

        #endregion

        // kampfschrei:/ ruft welplinge (1/1) herbei, bis eure seite des schlachtfelds voll ist.
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
            int kids = 7 - p.ownMinions.Count;

            for (int i = 0; i < kids; i++)
            {
                p.callKid(this.kid, own.zonepos, own.own, true);
            }
        }

        #endregion
    }
}