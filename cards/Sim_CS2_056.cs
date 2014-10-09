// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_056.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_056.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_056.
    /// </summary>
    internal class Sim_CS2_056 : SimTemplate
    {
        // lifetap

        // heldenfähigkeit/\nzieht eine karte und erleidet 2 schaden.
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
            p.drawACard(CardDB.cardName.unknown, ownplay);

            int dmg = 2;
            if (ownplay)
            {
                if (p.doublepriest >= 1)
                {
                    dmg *= 2 * p.doublepriest;
                }

                p.minionGetDamageOrHeal(p.ownHero, dmg);
            }
            else
            {
                if (p.enemydoublepriest >= 1)
                {
                    dmg *= 2 * p.enemydoublepriest;
                }

                p.minionGetDamageOrHeal(p.enemyHero, dmg);
            }
        }

        #endregion
    }
}