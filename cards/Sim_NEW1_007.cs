// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_007.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_007.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_007.
    /// </summary>
    internal class Sim_NEW1_007 : SimTemplate
    {
        // starfall

        // wählt aus:/ fügt einem diener $5 schaden zu; oder fügt allen feindlichen dienern $2 schaden zu.
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
                int dmg = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
                p.minionGetDamageOrHeal(target, dmg);
            }

            if (choice == 2)
            {
                int damage = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
                p.allMinionOfASideGetDamage(!ownplay, damage);
            }
        }

        #endregion
    }
}