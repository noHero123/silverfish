// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_539.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_539.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_539.
    /// </summary>
    internal class Sim_EX1_539 : SimTemplate
    {
        // killcommand

        // verursacht $3 schaden. verursacht stattdessen $5 schaden, wenn ihr ein wildtier besitzt.
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
                bool haspet = false;
                foreach (Minion m in p.ownMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                    {
                        haspet = true;
                        break;
                    }
                }

                int dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
                if (haspet)
                {
                    dmg = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
                }

                p.minionGetDamageOrHeal(target, dmg);
            }
        }

        #endregion
    }
}