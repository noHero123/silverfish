// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_093.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_093.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_093.
    /// </summary>
    internal class Sim_CS2_093 : SimTemplate
    {
        // consecration

        // fügt allen feinden $2 schaden zu.
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
            int dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allCharsOfASideGetDamage(!ownplay, dmg);
        }

        #endregion
    }
}