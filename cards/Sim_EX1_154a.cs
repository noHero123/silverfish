// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_154a.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_154 a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_154 a.
    /// </summary>
    internal class Sim_EX1_154a : SimTemplate
    {
        // wrath

        // fügt einem diener $3 schaden zu.
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
            int damage = 0;
            damage = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);

            p.minionGetDamageOrHeal(target, damage);
        }

        #endregion
    }
}