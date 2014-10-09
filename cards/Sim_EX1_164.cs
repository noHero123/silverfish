// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_164.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_164.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_164.
    /// </summary>
    internal class Sim_EX1_164 : SimTemplate
    {
        // nourish

        // wählt aus:/ erhaltet 2 manakristalle; oder zieht 3 karten.
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
            if (choice == 1)
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

            if (choice == 2)
            {
                // this.owncarddraw+=3;
                p.drawACard(CardDB.cardName.unknown, ownplay);
                p.drawACard(CardDB.cardName.unknown, ownplay);
                p.drawACard(CardDB.cardName.unknown, ownplay);
            }
        }

        #endregion
    }
}