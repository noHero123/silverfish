// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_251.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_251.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ e x 1_251.
    /// </summary>
    internal class Sim_EX1_251 : SimTemplate
    {
        // forkedlightning

        // fügt zwei zufälligen feindlichen dienern $2 schaden zu. überladung:/ (2)
        // todo list
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
            int damage = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            List<Minion> temp2 = new List<Minion>(p.enemyMinions);
            temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));
            int i = 0;
            foreach (Minion enemy in temp2)
            {
                p.minionGetDamageOrHeal(enemy, damage);
                i++;
                if (i == 2)
                {
                    break;
                }
            }

            if (ownplay)
            {
                p.ueberladung += 2;
            }
        }

        #endregion
    }
}