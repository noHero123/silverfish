// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS1_130.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 1_130.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 1_130.
    /// </summary>
    internal class Sim_CS1_130 : SimTemplate
    {
        // holysmite

        // verursacht $2 schaden.
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
            p.minionGetDamageOrHeal(target, dmg);
        }

        #endregion
    }
}