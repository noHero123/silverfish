// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_573b.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_573 b.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_573 b.
    /// </summary>
    internal class Sim_EX1_573b : SimTemplate
    {
        // shandoslesson

        // ruft zwei treants (2/2) mit spott/ herbei.
        #region Fields

        /// <summary>
        ///     The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_573t); // special treant

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
            int pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, true);
            p.callKid(this.kid, pos, ownplay, true);
        }

        #endregion
    }
}