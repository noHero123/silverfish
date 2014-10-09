// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_062.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_062.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_062.
    /// </summary>
    internal class Sim_CS2_062 : SimTemplate
    {
        // hellfire

        // fügt allen charakteren $3 schaden zu.
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
            int dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allCharsGetDamage(dmg);
        }

        #endregion
    }
}