// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_014.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_014.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_014.
    /// </summary>
    internal class Sim_EX1_014 : SimTemplate
    {
        // kingmukla

        // kampfschrei:/ gebt eurem gegner 2 bananen.
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
            p.drawACard(CardDB.cardName.bananas, !own.own, true);
            if (own.own)
            {
                p.enemycarddraw -= 1;
            }

            p.drawACard(CardDB.cardName.bananas, !own.own, true);
            if (own.own)
            {
                p.enemycarddraw -= 1;
            }
        }

        #endregion
    }
}