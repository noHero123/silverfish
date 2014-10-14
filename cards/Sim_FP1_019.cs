// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_FP1_019.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ f p 1_019.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ f p 1_019.
    /// </summary>
    internal class Sim_FP1_019 : SimTemplate
    {
        // poisonseeds
        #region Fields

        /// <summary>
        ///     The d.
        /// </summary>
        private CardDB.Card d = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);

        #endregion

        // vernichtet alle diener und ruft für jeden einen treant (2/2) als ersatz herbei.
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
            int ownanz = p.ownMinions.Count;
            int enemanz = p.enemyMinions.Count;
            p.allMinionsGetDestroyed();
            for (int i = 0; i < ownanz; i++)
            {
                p.callKid(this.d, 1, true);
            }

            for (int i = 0; i < enemanz; i++)
            {
                p.callKid(this.d, 1, false);
            }
        }

        #endregion
    }
}