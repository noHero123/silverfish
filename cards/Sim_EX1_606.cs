// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_606.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_606.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_606.
    /// </summary>
    internal class Sim_EX1_606 : SimTemplate
    {
        // shieldblock

        // erhaltet 5 rüstung. zieht eine karte.
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
            if (ownplay)
            {
                p.ownHero.armor += 5;
            }
            else
            {
                p.enemyHero.armor += 5;
            }

            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

        #endregion
    }
}