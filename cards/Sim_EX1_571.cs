// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_571.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_571.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_571.
    /// </summary>
    internal class Sim_EX1_571 : SimTemplate
    {
        // forceofnature

        // ruft drei treants (2/2) mit ansturm/ herbei, die am ende des zuges sterben.
        #region Fields

        /// <summary>
        ///     The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk9); // Treant

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
            int posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(this.kid, posi, ownplay);
            p.callKid(this.kid, posi, ownplay);
            p.callKid(this.kid, posi, ownplay);
        }

        #endregion
    }
}