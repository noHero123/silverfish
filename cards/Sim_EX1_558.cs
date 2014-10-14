// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_558.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_558.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_558.
    /// </summary>
    internal class Sim_EX1_558 : SimTemplate
    {
        // harrisonjones

        // kampfschrei:/ zerstört die waffe eures gegners. zieht ihrer haltbarkeit entsprechend karten.
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
                // this.owncarddraw += enemyWeaponDurability;
                for (int i = 0; i < p.enemyWeaponDurability; i++)
                {
                    p.drawACard(CardDB.cardName.unknown, true);
                }

                p.lowerWeaponDurability(1000, false);
            }
            else
            {
                for (int i = 0; i < p.enemyWeaponDurability; i++)
                {
                    p.drawACard(CardDB.cardName.unknown, false);
                }

                p.lowerWeaponDurability(1000, true);
            }
        }

        #endregion
    }
}