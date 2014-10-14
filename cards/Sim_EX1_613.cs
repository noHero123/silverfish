// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_613.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_613.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_613.
    /// </summary>
    internal class Sim_EX1_613 : SimTemplate
    {
        // edwin van cleefe
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
            if (own.own)
            {
                p.minionGetBuffed(own, p.cardsPlayedThisTurn * 2, p.cardsPlayedThisTurn * 2);
            }
            else
            {
                p.minionGetBuffed(own, p.enemyAnzCards * 2, p.enemyAnzCards * 2);
            }
        }

        #endregion
    }
}