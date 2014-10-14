// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_164a.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_164 a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_164 a.
    /// </summary>
    internal class Sim_EX1_164a : SimTemplate
    {
        // nourish

        // erhaltet 2 manakristalle.
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
                if (p.ownMaxMana >= 10)
                {
                    // p.drawACard(CardDB.cardName.excessmana, true);
                    p.mana++;
                }
                else
                {
                    p.ownMaxMana++;
                    p.mana++;
                }

                if (p.ownMaxMana >= 10)
                {
                    // this.owncarddraw++;
                    // p.drawACard(CardDB.cardName.excessmana, true);
                    p.mana++;
                }
                else
                {
                    p.ownMaxMana++;
                    p.mana++;
                }
            }
            else
            {
                if (p.enemyMaxMana == 10)
                {
                    // p.drawACard(CardDB.cardName.excessmana, false);
                }
                else
                {
                    p.enemyMaxMana++;
                }

                if (p.enemyMaxMana == 10)
                {
                    // this.owncarddraw++;
                    // p.drawACard(CardDB.cardName.excessmana, false);
                }
                else
                {
                    p.enemyMaxMana++;
                }
            }
        }

        #endregion
    }
}