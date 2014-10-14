// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_538.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_538.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_538.
    /// </summary>
    internal class Sim_EX1_538 : SimTemplate
    {
        // unleashthehounds

        // ruft für jeden feindlichen diener einen jagdhund (1/1) mit ansturm/ herbei.
        #region Fields

        /// <summary>
        ///     The kid.
        /// </summary>
        private CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_538t); // hound

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
            int anz = p.enemyMinions.Count;
            int posi = p.ownMinions.Count;

            for (int i = 0; i < anz; i++)
            {
                p.callKid(this.kid, posi, ownplay);
            }
        }

        #endregion
    }
}