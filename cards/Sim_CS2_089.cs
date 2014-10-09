// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_089.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_089.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_089.
    /// </summary>
    internal class Sim_CS2_089 : SimTemplate
    {
        // holylight

        // stellt #6 leben wieder her.
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
            int heal = ownplay ? p.getSpellHeal(6) : p.getEnemySpellHeal(6);
            p.minionGetDamageOrHeal(target, -heal);
        }

        #endregion
    }
}